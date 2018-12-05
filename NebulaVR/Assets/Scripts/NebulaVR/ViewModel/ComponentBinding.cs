using UnityEngine.Events;

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
        this.environmentChanged.Invoke();
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        this.vc.Delete();
        me.RemoveComponent(mc);
    }
}
