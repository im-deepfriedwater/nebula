using UnityEngine.Events;
using UnityEngine;

public class LinkBinding {

    public readonly ViewLink vl;
    public readonly ModelLink ml;
    readonly UnityEvent environmentChanged;

    public LinkBinding(ViewLink vl, ModelLink ml, UnityEvent viewModelEvent)
    {
        this.vl = vl;
        this.ml = ml;
        this.environmentChanged = viewModelEvent;
    }

    public void PropagateChange()
    {
        var dlb = vl.gameObject.GetComponent<DrawLinkBehaviour>();
        var momPos = dlb.mom.transform.position;
        var dadPos = dlb.dad.transform.position;
        ml.to = new Vector3(momPos.x, momPos.y, momPos.z);
        ml.from = new Vector3(dadPos.x, dadPos.y, dadPos.z);
    }

    public void DeleteFromViewAndModel(ModelEnvironment me)
    {
        this.vl.Delete();
        me.RemoveLink(ml);
    }
}
