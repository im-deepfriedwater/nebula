using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewModelLayer : MonoBehaviour
{
  public GameObject viewBlockPrefab;
  public ModelEnvironment me;
  private Vector3 defaultPosition = new Vector3(0, 0, 0);
  private readonly HashSet<Binding> bindings = new HashSet<Binding>();
  private readonly UnityEvent environmentChanged = new UnityEvent();

  public void Start()
  {
    environmentChanged.AddListener(Test);
  }

  private void Test()
  {
    Debug.Log("Lol");
    //me.TriggerCompliation();
  }

  private void AddToModel(ModelBlock modelBlock)
  {
    me.AddBlock(modelBlock);
  }

  public void Delete(Binding binding)
  {
    binding.DeleteFromViewAndModel(me);
    bindings.Remove(binding);
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

  public ModelBlock ConvertViewBlockToModelBlock(GameObject gameObjectViewBlock)
  {
    HashSet<ModelComponent> modelComponents = new HashSet<ModelComponent>();
    Vector3 viewPosition = gameObjectViewBlock.transform.position;
    foreach (ViewComponent vc in gameObjectViewBlock.GetComponentsInChildren<ViewComponent>())
    {
      modelComponents.Add(new ModelComponent(vc.componentType, vc.Position));
    } // TODO should components have references to their parents?
    return new ModelBlock(viewPosition, modelComponents);
  }
}
