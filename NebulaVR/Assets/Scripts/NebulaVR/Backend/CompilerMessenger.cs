using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using SimpleJSON;
using graphQLClient;

public class CompilerMessenger : MonoBehaviour
{
  public static string CompileConstructsWithLinks = @"
    query CompileConstructsWithLinks {
      compile(constructs: ""$constructs^"", links: ""$links^"") {
        program
        output
        stdout
      }
    }
  ";

  public static string ParseProgram = @"
    query ParseProgram {
      parse(program: ""$program^"") {
        constructs
        links
      }
    }
  ";

  void Start()
  {
    GraphQuery.url = "http://localhost:5050/graphql/";
    SendQueryToBackend();
  }
  public void SendQueryToBackend()
  {
    GraphQuery.onQueryComplete += DisplayResult;

    GraphQuery.variable["constructs"] = TestData.GetSampleContructs().Replace("\"", "\\\"");
    GraphQuery.variable["links"] = TestData.GetSampleLinks().Replace("\"", "\\\"");
    GraphQuery.POST(CompileConstructsWithLinks);

    GraphQuery.variable["program"] = TestData.HELLO_WORLD;
    GraphQuery.POST(ParseProgram);
  }

  public void DisplayResult()
  {
    Debug.Log(GraphQuery.queryReturn);
  }

  void OnDisable()
  {
    GraphQuery.onQueryComplete -= DisplayResult;
  }

  public static Construct[] ConvertModelBlocksToDSConstructs(HashSet<ModelBlock> blocks)
  {
    Construct[] result = new Construct[] { };
    foreach (ModelBlock block in blocks)
    {
      Construct[] children = new Construct[] { };
      foreach (ModelComponent component in block.Components)
      {
        string childName = component.ComponentType.ToString();
        Position childPos = new Position(component.Position.x, component.Position.y, component.Position.z);
        ConstructInfo childInfo = new ConstructInfo();
        Construct child = new Construct(childName, new Construct[] { }, childPos, childInfo);
      }
      string name = block.isOrigin ? ComponentType.Origin.ToString() : ComponentType.Function.ToString();
      Position pos = new Position(block.Position.x, block.Position.y, block.Position.z);
      ConstructInfo info = new ConstructInfo();
      Construct construct = new Construct(name, children, pos, info);
    }
    return result;
  }

  public static Link[] ConvertModelLinksToDSLinks(HashSet<ModelLink> links)
  {
    Link[] result = new Link[] { };
    foreach (ModelLink link in links)
    {
      Position from = new Position(link.from.x, link.from.y, link.from.z);
      Position to = new Position(link.to.x, link.to.y, link.to.z);
      Link newLink = new Link(from, to);
    }
    return result;
  }
}


public class Position
{
  public float x;
  public float y;
  public float z;
  public Position(float x = 0, float y = 0, float z = 0)
  {
    this.x = x;
    this.y = y;
    this.z = z;
  }
}

public class ConstructInfo
{
  public bool @default;
  public string id;
  public string type;
  public string init;
  public ConstructInfo(bool @default = false, string id = null, string type = null, string init = null)
  {
    this.@default = @default;
    this.id = id;
    this.type = type;
    this.init = init;
  }
}

public class Construct
{
  public string name;
  public Construct[] children;
  public Position pos;
  public ConstructInfo info;

  public Construct(string name, Construct[] children, Position pos, ConstructInfo info)
  {
    this.name = name;
    this.children = children;
    this.pos = pos;
    this.info = info;
  }
}

public class Link
{
  public Position from;
  public Position to;

  public Link(Position from, Position to)
  {
    this.from = from;
    this.to = to;
  }
}

class TestData
{
  public static string HELLO_WORLD = @"
    Origin default ""hello"" (3, 3)
      Result void (5, 5)

    Function ""print"" (10, 5)
      Parameter ""message"" (10, 7)
        initialize string ""Hello, world!""
      Return (8, 5)

    Link (8, 5) (5, 5)
  ";

  public static string GetSampleContructs()
  {
    var c2 = new Construct(
      name: "Result",
      children: new Construct[] { },
      pos: new Position(5, 5),
      info: new ConstructInfo(type: "void")
    );
    var c4 = new Construct(
      name: "Parameter",
      children: new Construct[] { },
      pos: new Position(10, 7),
      info: new ConstructInfo(id: "message", type: "string", init: "Hello, world!")
    );
    var c5 = new Construct(
      name: "Return",
      children: new Construct[] { },
      pos: new Position(8, 5),
      info: new ConstructInfo(type: "void")
    );

    var c1 = new Construct(
      name: "Origin",
      children: new Construct[] { c2 },
      pos: new Position(3, 3),
      info: new ConstructInfo(@default: true, id: "hello")
    );
    var c3 = new Construct(
      name: "Function",
      children: new Construct[] { c4, c5 },
      pos: new Position(10, 5),
      info: new ConstructInfo(id: "print")
    );
    return Newtonsoft.Json.JsonConvert.SerializeObject(new Construct[] { c1, c3 });
  }

  public static string GetSampleLinks()
  {
    var l1 = new Link(
      from: new Position(8, 5),
      to: new Position(5, 5)
    );
    return Newtonsoft.Json.JsonConvert.SerializeObject(new Link[] { l1 });
  }
}