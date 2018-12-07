using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewMenuBehavior : MonoBehaviour {

    [SerializeField]
    GameObject[] prefabs;

    [SerializeField]
    ViewModelLayer vml;
    [SerializeField]
    GameObject console;
    private int page;
    public Button button_0, button_1, button_2, button_3, 
                  button_left, button_right;
    public Text text_0, text_1, text_2, text_3;

    private Vector3 defaultSpawn = new Vector3(2, 0, 0);

    void Start()
    {
        page = 0;
        button_0.onClick.AddListener(TaskOnClick0);
        button_1.onClick.AddListener(TaskOnClick1);
        button_2.onClick.AddListener(TaskOnClick2);
        button_3.onClick.AddListener(TaskOnClick3);
        button_left.onClick.AddListener(TaskOnClickLeft);
        button_right.onClick.AddListener(TaskOnClickRight);
        updateTextFields();
    }

    void TaskOnClick0()
    {
        if (page == 0)
        {
            //Function 1
            Debug.Log("1");
            vml.ConstructAndBindViewBlock(defaultSpawn, prefabs[0]);
        }
        if(page == 1)
        {
            //Function 5
            Debug.Log("5");
        }
        if(page == 2)
        {
            //Function 9
            Debug.Log("9");
        }
        //vml.Constru...
    }

    void TaskOnClick1()
    {
        if (page == 0)
        {
            //Function 2
            Debug.Log("2");
        }
        if (page == 1)
        {
            //Function 6
            if (!console.activeSelf)
            {
                console.SetActive(true);
            }
            else
            {
                console.SetActive(false);
            }
        }
        if (page == 2)
        {
            //Function 10
            Debug.Log("10");
        }
    }

    void TaskOnClick2()
    {
        if (page == 0)
        {
            //Function 3
            Debug.Log("3");
        }
        if (page == 1)
        {
            //Function 7
            vml.Test();
        }
        if (page == 2)
        {
            //Function 11
            Debug.Log("11");
        }
    }

    void TaskOnClick3()
    {
        if (page == 0)
        {
            //Function 4
            Debug.Log("4");
        }
        if (page == 1)
        {
            //Function 8
            Debug.Log("8");
        }
        if (page == 2)
        {
            //Function 12
            Debug.Log("12");
        }
    }

    
    void TaskOnClickLeft()
    {
        page += 2;
        page %= 3;
        updateTextFields();
    }

    void TaskOnClickRight()
    {
        page += 1;
        page %= 3;
        updateTextFields();
    }


    void updateTextFields()
    {
        if (page == 0)
        {
            text_0.text = "Add Function";
            text_1.text = "Subtract Function";
            text_2.text = "Multiply Function";
            text_3.text = "Divide Function";
        };
        if (page == 1)
        {
            text_0.text = "Ternary Function";
            text_1.text = "Open Console";
            text_2.text = "Compile";
            text_3.text = "Function 8";
        }
        if (page == 2)
        {
            text_0.text = "Function 9";
            text_1.text = "Function 10";
            text_2.text = "Function 11";
            text_3.text = "Function 12";
        }
    }
}
