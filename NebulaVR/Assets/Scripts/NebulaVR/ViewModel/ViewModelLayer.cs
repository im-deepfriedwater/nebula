using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewModelLayer : MonoBehaviour
{

    // TODO refactor for a more elegant way so we can decouple this.
    // Maybe through Eventlisteners or delegates?
    public GameObject viewBlockPrefab;
    public ModelEnvironment me;
    private Vector3 defaultPosition = new Vector3(0, 0, 0);
    private readonly HashSet<Binding> bindings = new HashSet<Binding>();
    private readonly UnityEvent environmentChanged;

    private void AddToModel(ModelBlock modelBlock)
    {
        me.AddBlock(modelBlock);
    }

    public void Delete(Binding binding)
    {
        bindings.Remove(binding);
    }

    public void ConstructAndBindViewBlock(Vector3 position, PremadeBlock blockType)
    {
        var gameObjectViewBlock = Instantiate(viewBlockPrefab, defaultPosition, Quaternion.identity) as GameObject;
        var viewBlock = gameObjectViewBlock.GetComponent(typeof(ViewBlock)) as ViewBlock;
        var modelBlock = ConvertViewBlockToModelBlock(gameObjectViewBlock);
        var binding = new Binding(viewBlock, modelBlock, environmentChanged);
        viewBlock.Initialize(binding);
        AddToModel(modelBlock);
        bindings.Add(binding);
    }

    public ModelBlock ConvertViewBlockToModelBlock(GameObject gameObjectViewBlock)
    {
        List<ModelComponent> modelComponents = new List<ModelComponent>();
        Vector3 viewPosition = gameObjectViewBlock.transform.position; 
        foreach (ViewComponent vc in gameObjectViewBlock.GetComponentsInChildren<ViewComponent>())
        {
            modelComponents.Add(new ModelComponent(vc.componentType, vc.Position));
        } // TODO should components have references to their parents?
        return new ModelBlock(viewPosition, modelComponents);
    }
}
