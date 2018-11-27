using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModelEnvironment
{
    ModelEnvironment me;

    public TestModelEnvironment()
    {

        var printAccessor = new ModelComponent(ComponentType.Accessor, new Vector3(10, 10, 15));
        var printReturn = new ModelComponent(ComponentType.Return, new Vector3(10, 10, 5));
 
        var printComponents = new HashSet<ModelComponent>
        {
            printAccessor,
            printReturn
        };
 
        var print = new ModelBlock(new Vector3(10, 10, 10), printComponents);

        me.AddBlock(print);
        me.AddComponent(printAccessor);
        me.AddComponent(printReturn);

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

        me.AddLink(link);
    }

}
