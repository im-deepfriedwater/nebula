using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelComponent : ModelConstruct
{
  private readonly ComponentType componentType;
  private readonly ModelBlock parent;
  public ComponentType ComponentType
  {
    get { return componentType; }
  }
  // Internal Value that is used to determine the starting value 
  // for Parameters without an entering Link. Default value is null.
  private int? initializeValue;
  public int? InitializeValue
  {
    get { return initializeValue; }
    set { initializeValue = value; }
  }
  private readonly HashSet<ModelLink> links;

  public ModelComponent(ComponentType componentType, Vector3 position, ModelBlock parent, string id = null, int? initializeValue = null)
  {
    this.componentType = componentType;
    this.Position = position;
    this.links = new HashSet<ModelLink>();
    this.parent = parent;
    this.Id = id;
    this.InitializeValue = initializeValue;
  }

  public void Delete()
  {
    this.parent.DeleteComponent(this);
  }
}
