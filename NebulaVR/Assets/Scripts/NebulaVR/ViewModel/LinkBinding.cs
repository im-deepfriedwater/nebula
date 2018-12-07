using UnityEngine.Events;

public class LinkBinding {

    private readonly ViewLink vl;
    private readonly ModelLink ml;
    readonly UnityEvent environmentChanged;

    public LinkBinding(ViewLink vl, ModelLink ml, UnityEvent viewModelEvent)
    {
        this.vl = vl;
        this.ml = ml;
        this.environmentChanged = viewModelEvent;
    }

    public void PropagateChange()
    {
        this.environmentChanged.Invoke();
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        this.vl.Delete();
        me.RemoveLink(ml);
    }
}
