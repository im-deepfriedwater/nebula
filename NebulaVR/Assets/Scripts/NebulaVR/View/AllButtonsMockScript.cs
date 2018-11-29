using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllButtonsMockScript : MonoBehaviour {

    public GameObject addFunctionPrefab;
    [SerializeField]
    public GameObject fakeTextOutput;
	public Button button_1, button_2, button_3, button_4, left, right;
	// Use this for initialization
	void Start () {
		button_1.onClick.AddListener(TaskOnClick1);
		button_2.onClick.AddListener(TaskOnClick2);
		button_3.onClick.AddListener(TaskOnClick3);
		button_4.onClick.AddListener(TaskOnClick4);
		left.onClick.AddListener(TaskOnClickLeft);
		right.onClick.AddListener(TaskOnClickRight);
	}
	

	void TaskOnClick1(){
        Instantiate(addFunctionPrefab, new Vector3(-2, 0, -2), Quaternion.identity);
	}

	void TaskOnClick2(){
        fakeTextOutput.SetActive(true);
	}

	void TaskOnClick3(){
		Debug.Log("Button 3 clicked!");
	}

	void TaskOnClick4(){
		Debug.Log("Button 4 clicked!");
	}

	void TaskOnClickLeft(){
		Debug.Log("Go Left");
	}
	
	void TaskOnClickRight(){
		Debug.Log("Go Right");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
