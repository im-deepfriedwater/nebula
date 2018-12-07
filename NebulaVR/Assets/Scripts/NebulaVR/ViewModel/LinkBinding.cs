using UnityEngine.Events;
using UnityEngine;

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
        ml.to = new Vector3(vl.to.x, vl.to.y, vl.to.z);
        ml.from = new Vector3(vl.from.x, vl.from.y, vl.from.z);
        environmentChanged.Invoke();
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        this.vl.Delete();
        me.RemoveLink(ml);
    }
}
