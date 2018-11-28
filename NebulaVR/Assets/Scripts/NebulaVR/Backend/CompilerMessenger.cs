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
}


class Position
{
  public int x;
  public int y;
  public Position(int x, int y)
  {
    this.x = x;
    this.y = y;
  }
}

class ConstructInfo
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

class Construct
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

class Link
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