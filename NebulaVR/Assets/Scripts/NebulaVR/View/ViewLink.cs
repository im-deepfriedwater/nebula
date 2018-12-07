using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLink : MonoBehaviour {
    public Vector3 to;
    public Vector3 from;
    public LinkBinding binding;
      
    public void SetTargets(Vector3 to, Vector3 from)
    {
        this.to = to;
        this.from = from;
    }

    public void Initialize(Vector3 to, Vector3 from, LinkBinding binding)
    {
        SetTargets(to, from);
        this.binding = binding;
    }

    public void Delete()
    {
        Destroy(this);
    }

    public void SignifyChange()
    {
        binding.PropagateChange();
    }
}
