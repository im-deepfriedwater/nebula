using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using SimpleJSON;
using graphQLClient;

public class CompilerMessenger : MonoBehaviour
{
  [TextArea]
  public string getPokemonDetails;

  [TextArea]
  public string textProgram;

  // Use this for initialization
  void Start()
  {
    GraphQuery.url = "http://localhost:5050/graphql/";
    GetPikachuDetails();
    // SetupClient();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void GetPikachuDetails()
  {
    GraphQuery.onQueryComplete += DisplayResult;

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

    var l1 = new Link(
      from: new Position(8, 5),
      to: new Position(5, 5)
    );

    GraphQuery.variable["constructs"] = Newtonsoft.Json.JsonConvert.SerializeObject(new Construct[] { c1, c3 }).Replace("\"", "\\\"");
    GraphQuery.variable["links"] = Newtonsoft.Json.JsonConvert.SerializeObject(new Link[] { l1 }).Replace("\"", "\\\"");
    GraphQuery.variable["program"] = textProgram;
    GraphQuery.POST(getPokemonDetails);
  }

  public void DisplayResult()
  {
    Debug.Log(GraphQuery.queryReturn);
  }

  void OnDisable()
  {
    GraphQuery.onQueryComplete -= DisplayResult;
  }

  public void SetupClient()
  {
    var ws = new WebSocket("ws://localhost:5050");
    ws.OnMessage += (sender, e) =>
      Debug.Log("Recieved from Server: " + e.Data);
    ws.Connect();


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

    var l1 = new Link(
      new Position(8, 5),
      new Position(5, 5)
    );

    var obj = new
    {
      constructs = new Construct[] { c1, c3 },
      links = new Link[] { l1 }
    };
    ws.Send(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
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