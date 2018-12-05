using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVVMEnvironmentTest : MonoBehaviour {
    // It is entirely possible do unit testing on the
    // view. But for now, a spot check in the editor will
    // do alongside unit testing the model.
    [SerializeField]
    ViewModelLayer vml;

    [SerializeField]
    GameObject tl;

    [SerializeField]
    ModelEnvironment me;

    public void SpawnBlock()
    {
        vml.ConstructAndBindViewBlock(new Vector3(0, 0, 0), PremadeBlock.AddFunction);
        vml.ConstructAndBindViewBlock(new Vector3(0, 5, 5), PremadeBlock.AddFunction);
    }

    public void Start()
    {
        SpawnBlock();
        StartCoroutine("DelayedCallback");
    }

    private void MoveBlockTest()
    {
        var addBlock = FindObjectOfType<ViewBlock>();
        addBlock.transform.position = new Vector3(10, 0, 10);
        addBlock.GetComponent<ViewBlock>().SignifyChange();
    }

    private void DeleteBlockTest()
    {
        var addBlock = FindObjectOfType<ViewBlock>();

        vml.Delete(addBlock.binding);

        Debug.Assert(me.BlocksLength == 1);
        Debug.Assert(me.ComponentsLength == 3);
    }

    private void DeleteComponentTest()
    {
        Debug.Assert(me.ComponentsLength == 3);
        var addComponent = FindObjectOfType<ViewComponent>().GetComponent<ViewComponent>();
        Debug.Log(me.components.Contains(addComponent.binding.mc));

        vml.DeleteComponent(addComponent.binding);

    }

    private void ModelInitializationTest()
    {
        Debug.Assert(me.BlocksLength == 2);
        Debug.Assert(me.LinksLength == 0);
    }

    IEnumerator DelayedCallback()
    {
        yield return new WaitForSeconds(5f);
        ModelInitializationTest();
        MoveBlockTest();
        DeleteBlockTest();
        DeleteComponentTest();
    }
}
