using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModelEnvironment
{
    ModelEnvironment me;

    public TestModelEnvironment()
    {
        var printComponents = new HashSet<ModelComponent>();
        var print = new ModelBlock(new Vector3(10, 10, 10), printComponents, "print");
        var printAccessor = new ModelComponent(ComponentType.Accessor, new Vector3(10, 10, 15), print);
        var printReturn = new ModelComponent(ComponentType.Return, new Vector3(10, 10, 5), print);
        printComponents.Add(printAccessor);
        printComponents.Add(printReturn);
        me.AddBlock(print);

        var originComponents = new HashSet<ModelComponent>();
        var originBlock = new ModelBlock(new Vector3(0, 0, 0), originComponents, "origin", isOrigin: true);
        var originParameter = new ModelComponent(ComponentType.Parameter, new Vector3(0, 0, 5), originBlock);
        var originReturn = new ModelComponent(ComponentType.Return, new Vector3(0, 0, -5), originBlock);
        originComponents.Add(originParameter);
        originComponents.Add(originReturn);
        me.AddBlock(originBlock);
 
        // LINKS ARE WIP
        // This might not make sense.
        var link = new ModelLink(new Vector3(10, 10, 5), new Vector3(0, 0, -5));
        me.AddLink(link);
    }

}
