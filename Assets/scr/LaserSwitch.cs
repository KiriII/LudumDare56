using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSwitch : MonoBehaviour
{
    public GameObject squer;
    public Text text;

    private Action _switcher;

    public void init(Action switcher)
    {
        _switcher = switcher;
        squer.GetComponent<Image>().color = Color.white; 
    }

    private void OnMouseDown()
    {
        _switcher?.Invoke();
        SwitchSquerColor();
    }

    public void SwitchSquerColor()
    {
        var color = squer.GetComponent<Image>().color;
        if (color == Color.white)
        {
            squer.GetComponent<Image>().color = Color.black;
            text.text = "Killer";
            text.color = Color.white;
        }
        else
        {
            squer.GetComponent<Image>().color = Color.white;
            text.text = "Increaser";
            text.color = Color.black;
        }
    }
}
