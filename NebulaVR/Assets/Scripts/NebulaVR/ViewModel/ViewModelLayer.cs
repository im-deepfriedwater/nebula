using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewModelLayer : MonoBehaviour
{
    // TODO refactor for a more elegant way so we can decouple this.
    // Maybe through Eventlisteners or delegates
    public GameObject viewBlockPrefab;
    public ModelEnvironment me;
    private Vector3 defaultPosition = new Vector3(0, 0, 0);
    private readonly HashSet<Binding> bindings = new HashSet<Binding>();
    private readonly UnityEvent environmentChanged;

    private void Add(ModelBlock modelBlock)
    {
        me.AddBlock(modelBlock);
        throw new System.NotImplementedException();
    }

    public void Delete(Binding binding)
    {
        bindings.Remove(binding);
    }

    public void ConstructAndBindViewBlock(Vector3 position, ConstructInfo constructInfo)
    {
        var gameObject = Instantiate(viewBlockPrefab, defaultPosition, Quaternion.identity) as GameObject;
        var viewBlock = gameObject.GetComponent(typeof(ViewBlock)) as ViewBlock;
        var modelBlock = new ModelBlock(defaultPosition, constructInfo);
        var binding = new Binding(viewBlock, modelBlock, environmentChanged);

        viewBlock.Initialize(binding);
        Add(modelBlock);
    }
}
