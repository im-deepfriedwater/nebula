using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllButtonsMockScript : MonoBehaviour
{
    public static string typed;
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
        button_hello.onClick.AddListener(TaskOnClickHello);
        button_clear.onClick.AddListener(TaskOnClickClear);
        typed = "";
    }

    void TaskOnClick0()
    {
        typed += "0";
    }

    void TaskOnClick1()
    {
        typed += "1";
    }

    void TaskOnClick2()
    {
        typed += "2";
    }

    void TaskOnClick3()
    {
        typed += "3";
    }

    void TaskOnClick4()
    {
        typed += "4";
    }

    void TaskOnClick5()
    {
        typed += "5";
    }

    void TaskOnClick6()
    {
        typed += "6";
    }

    void TaskOnClick7()
    {
        typed += "7";
    }

    void TaskOnClick8()
    {
        typed += "8";
    }

    void TaskOnClick9()
    {
        typed += "9";
    }

    void TaskOnClickHello()
    {
        typed = "Hello, World!";
    }

    void TaskOnClickClear()
    {
        typed = "";
    }
}
