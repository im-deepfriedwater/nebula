using UnityEngine.Events;
using UnityEngine;

public class ComponentBinding
{
    private readonly ViewComponent vc;
    public readonly ModelComponent mc;
    readonly UnityEvent environmentChanged;

    public ComponentBinding(ViewComponent vc, ModelComponent mc, UnityEvent viewModelEvent)
	{
        this.vc = vc;
        this.mc = mc;
        environmentChanged = viewModelEvent;
    }

    public void PropagateChange()
    {
        mc.Position = new Vector3(vc.Position.x, vc.Position.y, vc.Position.z);
        this.environmentChanged.Invoke();
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        vc.Delete();
        me.RemoveComponent(mc);
    }
}
