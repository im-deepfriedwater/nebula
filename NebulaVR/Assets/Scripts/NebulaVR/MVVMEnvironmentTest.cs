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
        Debug.Log("Trying to add");
        var addBlock = FindObjectOfType<ViewBlock>();
        addBlock.transform.position = new Vector3(10, 0, 10);
        addBlock.GetComponent<ViewBlock>().SignifyChange();
    }

    private void DeleteBlockTest()
    {
        Debug.Log("Trying to delete");
        var addBlock = FindObjectOfType<ViewBlock>();
        vml.Delete(addBlock.binding);
        addBlock.Delete();
        Debug.Assert(me.BlocksLength == 1);
    }

    private void DeleteComponentTest()
    {
        var addComponent = FindObjectOfType<ViewComponent>();
        throw new System.NotImplementedException();
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
    }
}
