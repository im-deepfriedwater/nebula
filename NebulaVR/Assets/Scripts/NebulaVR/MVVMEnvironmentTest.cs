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

    public ViewBlock ohman;
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
        var newPosition = new Vector3(10, 0, 10);
        addBlock.transform.position = new Vector3(10, 0, 10);
        addBlock.GetComponent<ViewBlock>().SignifyChange();
        Debug.Assert(newPosition == addBlock.transform.position);
        Debug.Assert(addBlock.binding.mb.Position == newPosition);
    }

    private void MoveComponentTest()
    {
        var addComponent = FindObjectOfType<ViewComponent>();
        var newPosition = new Vector3(20, 20, 20);
        addComponent.transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
        addComponent.SignifyChange();
        Debug.Assert(newPosition == addComponent.transform.position);
        Debug.Assert(addComponent.binding.mc.Position == newPosition);
    }

    private void DeleteBlockTest()
    {
        var addBlock = FindObjectOfType<ViewBlock>();
        ohman = addBlock;
        Debug.Assert(me.ComponentsLength == 6);
        Debug.Assert(vml.componentBindings.Count == 6);
        Debug.Assert(me.BlocksLength == 2);
        vml.Delete(addBlock.binding);
        Debug.Assert(me.BlocksLength == 1);
        Debug.Assert(me.ComponentsLength == 3);
    }

    private void DeleteBlockTestEmpty()
    {
        var addBlock = FindObjectOfType<ViewBlock>();
        Debug.Assert(me.ComponentsLength == 3);
        Debug.Assert(vml.componentBindings.Count == 3);
        vml.Delete(addBlock.binding);
        Debug.Assert(me.BlocksLength == 0);
        Debug.Assert(me.ComponentsLength == 0);
    }

    // Unneeded for final presentation.
    private void DeleteComponentTest()
    {
        Debug.Assert(me.ComponentsLength == 3);
        var addComponent = FindObjectOfType<ViewComponent>();
        Debug.Log(FindObjectsOfType<ViewComponent>().Length);
        vml.DeleteComponent(addComponent.binding);
        Debug.Assert(me.BlocksLength == 1);
        Debug.Assert(me.ComponentsLength == 2);
        Debug.Assert(vml.componentBindings.Count == 2);
    }

    private void ModelInitializationTest()
    {
        Debug.Assert(me.BlocksLength == 2);
        Debug.Assert(me.LinksLength == 0);
    }

    private void TestLinkCreation()
    {
        throw new System.NotImplementedException();
    }

    private void TestLinkPropagateChange()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator DelayedCallback()
    {
        yield return new WaitForSeconds(5f);
        ModelInitializationTest();
        MoveBlockTest();
        MoveComponentTest();
        DeleteBlockTest();
        yield return new WaitForEndOfFrame();
        DeleteBlockTestEmpty();
        // DeleteComponentTest();
        TestLinkCreation();
        TestLinkPropagateChange();
    }
}
