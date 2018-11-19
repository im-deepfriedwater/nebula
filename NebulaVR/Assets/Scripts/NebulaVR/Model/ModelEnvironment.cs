using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of components in their physicality. 
// Listens for changes in the environment and 
// Triggers a compilation if so.
public class ModelEnvironment : MonoBehaviour
{
	HashSet<ModelBlock> blocks = new HashSet<ModelBlock>();
    HashSet<ModelLink> links = new HashSet<ModelLink>();

    public void TriggerCompliation()
    {   
        // TODO to slot in with server implementation.
        throw new System.NotImplementedException();
    }

    public void AddBlock(ModelBlock mb)
    {
        blocks.Add(mb);
    }

    public void RemoveBlock(ModelBlock mb)
    {
        blocks.Remove(mb);
    }

    public void AddLink(ModelLink ml)
    {
        links.Add(ml);
    }

    public void RemoveLink(ModelLink ml)
    {
        links.Remove(ml);
    }
}