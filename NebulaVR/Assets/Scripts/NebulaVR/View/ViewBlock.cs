using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBlock : ViewConstruct
{
    [SerializeField]
    public string id;
    public Binding binding;
    public bool isOrigin;

  public void Initialize(Binding binding)
  {
    this.binding = binding;
  }

  // This should be called whenever this block is modified.
  override public void SignifyChange()
  {
    this.binding.PropagateChange();
  }

  public override void Delete()
  {
    foreach (ViewComponent vc in gameObject.GetComponentsInChildren<ViewComponent>())
    {
      vc.Delete();
    }
    Destroy(this.gameObject);
  }
}
