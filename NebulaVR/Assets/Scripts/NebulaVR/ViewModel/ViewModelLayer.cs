using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelLayer : MonoBehaviour
{
    // TODO refactor this for a more elegant way so we can decouple this.
    public ModelEnvironment me;
    private LinkedList<Binding> bindings = new LinkedList<Binding>();

    public void add(ViewConstruct construct)
    {
        //me.add();
        throw new System.NotImplementedException();
    }

    public void delete(int index)
    {
        throw new System.NotImplementedException();
    }
}
