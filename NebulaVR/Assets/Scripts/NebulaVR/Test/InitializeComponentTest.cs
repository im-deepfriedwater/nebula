using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeComponentTest : MonoBehaviour {
    [SerializeField]
    ViewModelLayer vml;

    [SerializeField]
    GameObject tl;

    [SerializeField]
    ModelEnvironment me;
    // Use this for initialization
    public void SpawnBlock()
    {
        vml.ConstructAndBindViewBlock(new Vector3(0, 0, 0), PremadeBlock.AddFunction);
        vml.ConstructAndBindViewBlock(new Vector3(0, 5, 5), PremadeBlock.AddFunction);
    }
    void Start ()
    {
        SpawnBlock();
        TestInitializeValue();
        StartCoroutine("DelayedCallback");
    }

    void TestInitializeValue()
    {
        var addComponent = FindObjectOfType<ViewComponent>().GetComponent<ViewComponent>();
        addComponent.InitializeValue = 5;
        addComponent.binding.mc.InitializeValue == 5;
    }

    IEnumerator DelayedCallback()
    {
        yield return new WaitForSeconds(5f);
    
    }
}
