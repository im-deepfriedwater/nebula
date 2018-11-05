using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of components in their physicality. 
// Listens for changes in the environment and 
// Triggers a compilation if so.
public class ModelNebulaEnvironment : MonoBehaviour
{
	LinkedList<ModelBlock> blocks = new LinkedList<ModelBlock>();
    LinkedList<ModelLink> links = new LinkedList<ModelLink>();

    public void TriggerCompliation()
    {
        throw new System.NotImplementedException();
    }

    public void AddBlock(ModelBlock mb)
    {
        blocks.AddLast(mb);
    }

    public void RemoveBlock()
    {
        throw new System.NotImplementedException();
    }

    public void AddLink(ModelLink ml)
    {
        links.AddLast(ml);
    }

    public void RemoveLink()
    {
        throw new System.NotImplementedException();
    }
}