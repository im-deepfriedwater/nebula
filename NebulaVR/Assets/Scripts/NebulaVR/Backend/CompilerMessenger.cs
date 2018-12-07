using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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

    public static string result;

  void Start()
  {
    // Test Query
    SendQueryToBackend(TestData.GetSampleModelBlocks(), TestData.GetSampleModelLinks());
  }
  public static void SendQueryToBackend(HashSet<ModelBlock> modelBlocks, HashSet<ModelLink> modelLinks)
  {
    GraphQuery.onQueryComplete += DisplayResult;

    GraphQuery.url = "http://localhost:5050/graphql/";

    Construct[] constructs = ConvertModelBlocksToDSConstructs(modelBlocks);
    Link[] links = ConvertModelLinksToDSLinks(modelLinks);

    GraphQuery.variable["constructs"] = Newtonsoft.Json.JsonConvert.SerializeObject(constructs).Replace("\"", "\\\"");
    GraphQuery.variable["links"] = Newtonsoft.Json.JsonConvert.SerializeObject(links).Replace("\"", "\\\"");
    GraphQuery.POST(CompileConstructsWithLinks);
  }

  public static void DisplayResult()
  {
    Debug.Log(GraphQuery.queryReturn);

        if (GraphQuery.queryReturn != "")
        {
            GameObject.Find("ConsoleText").GetComponent<UnityEngine.UI.Text>().text = GraphQuery.queryReturn;
        }

        GraphQuery.onQueryComplete -= DisplayResult;
  }

  void OnDisable()
  {
    GraphQuery.onQueryComplete -= DisplayResult;
  }

  public static Construct[] ConvertModelBlocksToDSConstructs(HashSet<ModelBlock> blocks)
  {
    int resultIndex = 0;
    Construct[] result = new Construct[blocks.Count];
    foreach (ModelBlock block in blocks)
    {
      int childIndex = 0;
      string name = block.isOrigin ? ComponentType.Origin.ToString() : ComponentType.Function.ToString();
      Position pos = new Position(block.Position.x, block.Position.y, block.Position.z);
      ConstructInfo2 info = new ConstructInfo2(block.isOrigin, block.Id);
      Construct[] children = new Construct[block.Components.Count];
      foreach (ModelComponent component in block.Components)
      {
        string childName = component.ComponentType.ToString();
        if (block.isOrigin && component.ComponentType == ComponentType.Return)
        {
          childName = "Result";
        }
                Debug.Log(component.InitializeValue);
                Debug.Log(component.Id);

                Position childPos = new Position(component.Position.x, component.Position.y, component.Position.z);
        ConstructInfo2 childInfo = new ConstructInfo2(false, component.Id, "number", component.InitializeValue);
        Construct child = new Construct(childName, new Construct[] { }, childPos, childInfo);
        children[childIndex++] = child;
      }
      Construct construct = new Construct(name, children, pos, info);
      result[resultIndex++] = construct;
    }
    return result;
  }

  public static Link[] ConvertModelLinksToDSLinks(HashSet<ModelLink> links)
  {
    Link[] result = new Link[links.Count];
    int resultIndex = 0;
    foreach (ModelLink link in links)
    {
      Position from = new Position(link.from.x, link.from.y, link.from.z);
      Position to = new Position(link.to.x, link.to.y, link.to.z);
      Link newLink = new Link(from, to);
      result[resultIndex++] = newLink;
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
  public int? init;
  public ConstructInfo2(bool @default = false, string id = null, string type = null, int? init = null)
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

  public static HashSet<ModelBlock> GetSampleModelBlocks()
  {
    var multiplyBlock = new ModelBlock(new Vector3(10, 5, 0), new HashSet<ModelComponent> { }, "multiply");

    var multiplyParameter1 = new ModelComponent(ComponentType.Parameter, new Vector3(10, 7, 0), multiplyBlock, id: "p1", initializeValue: 2);
    var multiplyParameter2 = new ModelComponent(ComponentType.Parameter, new Vector3(10, 8, 0), multiplyBlock, id: "p2", initializeValue: 3);
    var multiplyReturn = new ModelComponent(ComponentType.Return, new Vector3(8, 5, 0), multiplyBlock);

    multiplyBlock.AddComponent(multiplyParameter1);
    multiplyBlock.AddComponent(multiplyParameter2);
    multiplyBlock.AddComponent(multiplyReturn);


    var originBlock = new ModelBlock(new Vector3(3, 3, 0), new HashSet<ModelComponent> { }, "hello", isOrigin: true);

    var originReturn = new ModelComponent(ComponentType.Return, new Vector3(5, 5, 0), originBlock);

    originBlock.AddComponent(originReturn);

    return new HashSet<ModelBlock> { multiplyBlock, originBlock };
  }

  public static HashSet<ModelLink> GetSampleModelLinks()
  {
    var link = new ModelLink(new Vector3(5, 5, 0), new Vector3(8, 5, 0));

    return new HashSet<ModelLink> { link };
  }
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
      info: new ConstructInfo2(id: "message", type: "number", init: 2)
    );
    var c5 = new Construct(
      name: "Parameter",
      children: new Construct[] { },
      pos: new Position(10, 7),
      info: new ConstructInfo2(id: "message", type: "number", init: 3)
    );
    var c6 = new Construct(
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
      children: new Construct[] { c4, c5, c6 },
      pos: new Position(10, 5),
      info: new ConstructInfo2(id: "multiply")
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