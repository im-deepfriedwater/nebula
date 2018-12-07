using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewModelLayer : MonoBehaviour
{
    public GameObject viewBlockPrefab;
    [SerializeField]
    public GameObject linkPrefab;
    public ModelEnvironment me;
    private Vector3 defaultPosition = new Vector3(0, 0, 0);
    public readonly HashSet<Binding> bindings = new HashSet<Binding>();
    public readonly HashSet<ComponentBinding> componentBindings = new HashSet<ComponentBinding>();
    public readonly HashSet<LinkBinding> linkBindings = new HashSet<LinkBinding>();
    private readonly UnityEvent environmentChanged = new UnityEvent();

    public void Start()
    {
        environmentChanged.AddListener(Test);
    }

    private void Test()
    {
        me.TriggerCompliation();
        Debug.Log("Hello");
    }

    private void AddToModel(ModelBlock modelBlock)
    {
        me.AddBlock(modelBlock);
    }

    public void Delete(Binding binding)
    {
        foreach (ViewComponent vc in binding.vb.GetComponentsInChildren<ViewComponent>())
        {
            componentBindings.Remove(vc.binding);
            vc.Delete();
        }

        var listToDeleteComponent = new List<ModelComponent>();
        foreach (ModelComponent mc in binding.mb.Components)
        {
            me.RemoveComponent(mc);
            listToDeleteComponent.Add(mc);
        }

        foreach (ModelComponent mc in listToDeleteComponent)
        {
            mc.Delete();
        }

        binding.DeleteFromViewAndModel(me);
        bindings.Remove(binding);
    }

    public void DeleteComponent(ComponentBinding binding)
    {
        binding.DeleteFromViewAndModel(me);
        componentBindings.Remove(binding);
        me.RemoveComponent(binding.mc);
    }

    public void DeleteLink(LinkBinding binding)
    {
        binding.DeleteFromViewAndModel(me);
        linkBindings.Remove(binding);
        me.RemoveLink(binding.ml);
    }

    public void ConstructAndBindViewLink(Vector3 to, Vector3 from)
    {   
        var gameObjectLink = Instantiate(linkPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        var viewLink = gameObjectLink.GetComponent<ViewLink>();
        var modelLink = new ModelLink(to, from);
        var linkBinding = new LinkBinding(viewLink, modelLink, environmentChanged);
        linkBindings.Add(linkBinding);
        me.AddLink(modelLink);
        viewLink.Initialize(to, from, linkBinding);
    }

    public void ConstructAndBindViewBlock(Vector3 position, PremadeBlock blockType)
    {   
        var gameObjectViewBlock = Instantiate(viewBlockPrefab, position, Quaternion.identity, me.transform) as GameObject;
        var viewBlock = gameObjectViewBlock.GetComponent(typeof(ViewBlock)) as ViewBlock;
        var modelBlock = ConvertViewBlockToModelBlock(gameObjectViewBlock);
        var binding = new Binding(viewBlock, modelBlock, environmentChanged);
        viewBlock.Initialize(binding);
        AddToModel(modelBlock);
        bindings.Add(binding);
    }

    public void ConstructAndBindViewComponent(ViewComponent vc, ModelBlock parent)
    {
        var modelPosition = new Vector3(vc.Position.x, vc.Position.y, vc.Position.z);
        var mc = new ModelComponent(vc.componentType, modelPosition, parent);
        var binding = new ComponentBinding(vc, mc, environmentChanged);
        componentBindings.Add(binding);
        me.AddComponent(mc);
    }

    public ModelBlock ConvertViewBlockToModelBlock(GameObject gameObjectViewBlock)
    {
        HashSet<ModelComponent> modelComponents = new HashSet<ModelComponent>();
        Vector3 viewPosition = gameObjectViewBlock.transform.position;
        string viewName = gameObjectViewBlock.GetComponent<ViewBlock>().id;
        var resultModelBlock = new ModelBlock(viewPosition, modelComponents, viewName);
        foreach (ViewComponent vc in gameObjectViewBlock.GetComponentsInChildren<ViewComponent>())
        {    
            var mc = new ModelComponent(vc.componentType, vc.Position, resultModelBlock);
            var binding = new ComponentBinding(vc, mc, environmentChanged);
            vc.Initialize(gameObjectViewBlock.GetComponent<ViewBlock>(), binding);
            modelComponents.Add(mc);
            componentBindings.Add(binding);
            me.AddComponent(mc);
        }

        return resultModelBlock;
    }
}
