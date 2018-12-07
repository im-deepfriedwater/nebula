using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBlock : ModelConstruct
{
  private readonly HashSet<ModelComponent> components;
  public HashSet<ModelComponent> Components
  {
    get { return components; }
  }
  public bool isOrigin;

  public ModelBlock(Vector3 position, HashSet<ModelComponent> components, string id, bool isOrigin = false)
  {
    this.Position = position;
    this.components = components;
    this.Id = id;
    this.isOrigin = isOrigin;
  }

  public void Delete()
  {
    var toDelete = new List<ModelComponent>();
    foreach (ModelComponent mc in components)
    {
      toDelete.Add(mc);
    }

    foreach (ModelComponent mc in toDelete)
    {
      components.Remove(mc);
    }
  }

  public void DeleteComponent(ModelComponent componentToDelete)
  {
    components.Remove(componentToDelete);
  }

  public void AddComponent(ModelComponent componentToAdd)
  {
    components.Add(componentToAdd);
  }

}
