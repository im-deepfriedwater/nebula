using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllButtonsMockScript : MonoBehaviour
{
    public int typed;
    public Button button_0, button_1, button_2, button_3, button_4, button_5,
           button_6, button_7, button_8, button_9, button_hello, button_clear;

    void Start()
    {
        button_0.onClick.AddListener(TaskOnClick0);
        button_1.onClick.AddListener(TaskOnClick1);
        button_2.onClick.AddListener(TaskOnClick2);
        button_3.onClick.AddListener(TaskOnClick3);
        button_4.onClick.AddListener(TaskOnClick4);
        button_5.onClick.AddListener(TaskOnClick5);
        button_6.onClick.AddListener(TaskOnClick6);
        button_7.onClick.AddListener(TaskOnClick7);
        button_8.onClick.AddListener(TaskOnClick8);
        button_9.onClick.AddListener(TaskOnClick9);
        button_clear.onClick.AddListener(TaskOnClickClear);
        typed = 0;
    }

    void TaskOnClick0()
    {
        typed = typed * 10 + 0;
    }

    void TaskOnClick1()
    {
        typed = typed * 10 + 1;
    }

    void TaskOnClick2()
    {
        typed = typed * 10 + 2;
    }

    void TaskOnClick3()
    {
        typed = typed * 10 + 3;
    }

    void TaskOnClick4()
    {
        typed = typed * 10 + 4;
    }

    void TaskOnClick5()
    {
        typed = typed * 10 + 5;
    }

    void TaskOnClick6()
    {
        typed = typed * 10 + 6;
    }

    void TaskOnClick7()
    {
        typed = typed * 10 + 7;
    }

    void TaskOnClick8()
    {
        typed = typed * 10 + 8;
    }

    void TaskOnClick9()
    {
        typed = typed * 10 + 9;
    }


    void TaskOnClickClear()
    {
        typed = 0;
    }
}
