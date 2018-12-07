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

    var printAccessor = new ModelComponent(ComponentType.Accessor, new Vector3(10, 10, 15));
    var printReturn = new ModelComponent(ComponentType.Return, new Vector3(10, 10, 5));

    var printComponents = new HashSet<ModelComponent>
    {
        printAccessor,
        printReturn
    };

    var print = new ModelBlock(new Vector3(10, 10, 10), printComponents);

    var originParameter = new ModelComponent(ComponentType.Parameter, new Vector3(0, 0, 5));
    var originReturn = new ModelComponent(ComponentType.Return, new Vector3(0, 0, -5));

    var originComponents = new HashSet<ModelComponent>
        {
            originParameter,
            originReturn
        };

    var originBlock = new ModelBlock(new Vector3(0, 0, 0), originComponents, isOrigin: true);

    // LINKS ARE WIP
    // This might not make sense.
    var link = new ModelLink(new Vector3(10, 10, 5), new Vector3(0, 0, -5));

    HashSet<ModelBlock> modelBlocks = new HashSet<ModelBlock> { print, originBlock };
    HashSet<ModelLink> modelLinks = new HashSet<ModelLink> { link };

    Construct[] constructs = ConvertModelBlocksToDSConstructs(modelBlocks);
    Link[] links = ConvertModelLinksToDSLinks(modelLinks);

    GraphQuery.variable["constructs"] = Newtonsoft.Json.JsonConvert.SerializeObject(constructs).Replace("\"", "\\\"");
    GraphQuery.variable["links"] = Newtonsoft.Json.JsonConvert.SerializeObject(links).Replace("\"", "\\\"");
    GraphQuery.POST(CompileConstructsWithLinks);

    // GraphQuery.variable["constructs"] = TestData.GetSampleContructs().Replace("\"", "\\\"");
    // GraphQuery.variable["links"] = TestData.GetSampleLinks().Replace("\"", "\\\"");
    // GraphQuery.POST(CompileConstructsWithLinks);

    // GraphQuery.variable["program"] = TestData.HELLO_WORLD;
    // GraphQuery.POST(ParseProgram);
  }

  public void DisplayResult()
  {
    Debug.Log(GraphQuery.queryReturn);
    GraphQuery.onQueryComplete -= DisplayResult;
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
        ConstructInfo2 childInfo = new ConstructInfo2(false);
        Construct child = new Construct(childName, new Construct[] { }, childPos, childInfo);
      }
      string name = block.isOrigin ? ComponentType.Origin.ToString() : ComponentType.Function.ToString();
      Position pos = new Position(block.Position.x, block.Position.y, block.Position.z);
      ConstructInfo2 info = new ConstructInfo2(block.isOrigin);
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

public class ConstructInfo2
{
  public bool @default;
  public string id;
  public string type;
  public string init;
  public ConstructInfo2(bool @default = false, string id = null, string type = null, string init = null)
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
  public ConstructInfo2 info;

  public Construct(string name, Construct[] children, Position pos, ConstructInfo2 info)
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
      info: new ConstructInfo2(type: "void")
    );
    var c4 = new Construct(
      name: "Parameter",
      children: new Construct[] { },
      pos: new Position(10, 7),
      info: new ConstructInfo2(id: "message", type: "string", init: "Hello, world!")
    );
    var c5 = new Construct(
      name: "Return",
      children: new Construct[] { },
      pos: new Position(8, 5),
      info: new ConstructInfo2(type: "void")
    );

    var c1 = new Construct(
      name: "Origin",
      children: new Construct[] { c2 },
      pos: new Position(3, 3),
      info: new ConstructInfo2(@default: true, id: "hello")
    );
    var c3 = new Construct(
      name: "Function",
      children: new Construct[] { c4, c5 },
      pos: new Position(10, 5),
      info: new ConstructInfo2(id: "print")
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