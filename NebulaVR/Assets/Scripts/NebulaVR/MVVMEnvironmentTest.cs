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
        Debug.Assert(me.LinksLength == 0);
        Debug.Assert(vml.linkBindings.Count == 0);
        var testTo = new Vector3(2.7f, 2.7f, 2.7f);
        var testFrom = new Vector3(19, 19, 19);
        vml.ConstructAndBindViewLink(testTo, testFrom);
        Debug.Assert(me.LinksLength == 1);
        Debug.Assert(vml.linkBindings.Count == 1);
    }

    private void TestLinkPropagateChange()
    {
        var testTo = new Vector3(99, 99, 99);
        var testFrom = new Vector3(9, 9, 9);
        var testLink = FindObjectOfType<ViewLink>();
        testLink.SetTargets(testTo, testFrom);
        testLink.SignifyChange();
        Debug.Assert(testLink.binding.vl.to == testTo);
        Debug.Assert(testLink.binding.ml.to == testTo);
        Debug.Assert(testLink.binding.vl.from == testFrom);
        Debug.Assert(testLink.binding.ml.from == testFrom);
    }

    private void TestLinkDeletion()
    {
        var testLink = FindObjectOfType<ViewLink>();
        vml.DeleteLink(testLink.binding);
        Debug.Assert(vml.linkBindings.Count == 0);
        Debug.Assert(me.links.Count == 0);
    }

    private void TestLinkMultipleCreation()
    {
        Debug.Assert(me.LinksLength == 0);
        Debug.Assert(vml.linkBindings.Count == 0);
        var testTo = new Vector3(2.7f, 2.7f, 2.7f);
        var testFrom = new Vector3(19, 19, 19);
        vml.ConstructAndBindViewLink(testTo, testFrom);

        testTo = new Vector3(10, 10, 10);
        testFrom = new Vector3(20, 20, 20);
        vml.ConstructAndBindViewLink(testTo, testFrom);

        testTo = new Vector3(40, 40, 40);
        testFrom = new Vector3(20, 30, 20);
        vml.ConstructAndBindViewLink(testTo, testFrom);

        Debug.Assert(me.LinksLength == 3);
        Debug.Assert(vml.linkBindings.Count == 3);
    }

    private void DeleteTestMultiple()
    {
        var toDelete = GameObject.FindObjectOfType<ViewLink>();
        vml.DeleteLink(toDelete.binding);
        Debug.Assert(me.LinksLength == 2);
        Debug.Assert(vml.linkBindings.Count == 2);
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
        TestLinkDeletion();
        TestLinkMultipleCreation();
    }
}
