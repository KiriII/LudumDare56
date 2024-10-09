using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatureMagnifier : MonoBehaviour
{
    private readonly double MIN_INERTION = 0.3;
    private readonly double MAX_SCALE = 60;

    public Vector3 scaleChange = new Vector3(5f, 5f, 0);

    public GameObject creature;
    public GameObject creatureForMagnifierGlass;
    public double inertion;

    //DEBUG 
    public Vector3 DebugScale = new Vector3(5f, 5f, 0);

    private Vector3 _positionChange;
    private double _scaleInertion;
    private double _currentInertion;
    private bool _active;
    private bool _magnified;

    // delegate
    private Action<float> _magnifierEnds;

    void Start()
    {
        _positionChange = new Vector3(0f, scaleChange.y / 2, 0f);
        _active = true;
        _magnified = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            //creature.layer = LayerMask.NameToLayer("Default");
            creature.SetActive(true);
            _scaleInertion = 0;
            creature.transform.localScale = DebugScale;
            creature.transform.localPosition = new Vector3(0, DebugScale.y / 2, 0);
        }
        if (!_active && !_magnified)
        {
            if (_scaleInertion > 0 && creature.transform.localScale.y < MAX_SCALE)
            {
                _scaleInertion -= _currentInertion;
                if (_currentInertion > MIN_INERTION)
                {
                    _currentInertion -= 0.02;
                }
                creature.transform.localScale += scaleChange;
                creature.transform.localPosition = new Vector3(0f, creature.transform.localScale.y / 2, 0f);
                //Debug.Log(creature.transform.localScale.y);
            }
            else
            {
                _magnified = true;
                OnMagnifierEnds(creature.transform.localScale.y);
            }
        }
    }

    public void StartMagnify(double timeCharged)
    {
        if (creature is not null)
        {
            //creature.layer = LayerMask.NameToLayer("Default");
            creature.SetActive(true);
            _scaleInertion = timeCharged * 30;
            _currentInertion = inertion;
            _active = false;
        }
    }

    public void SetText(string text)
    {
        //textObject.text = text;
    }

    private void OnMagnifierEnds(float scale)
    {
        _magnifierEnds?.Invoke(scale);
        _magnifierEnds = null;
    }

    public void EnableMagnifierEndsListener(Action<float> method)
    {
        _magnifierEnds += method;
    }
}
