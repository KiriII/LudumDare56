using System;
using UnityEngine;
using UnityEngine.UI;

public class LaserCharger : MonoBehaviour
{
    public Slider chargeSlider; 

    private readonly float MAX_CHARGE = 2f;
    private bool charge = false;

    private float _timeCurrent;
    private float _timeAtButtonDown;
    private float _timeAtButtonUp;

    private Action<double> _laserCharged;

    void Update()
    {
        _timeCurrent = Time.fixedTime;
        if (charge && chargeSlider.value < MAX_CHARGE)
        {
            chargeSlider.value += Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        charge = true;
        _timeAtButtonDown = _timeCurrent;
        //Debug.Log($"time at button down {_timeAtButtonDown}");
    }

    private void OnMouseUp()
    {
        charge = false;
        chargeSlider.value = 0;
        _timeAtButtonUp = _timeCurrent;
        OnCharged(_timeAtButtonUp - _timeAtButtonDown);
        //Debug.Log($"time at button up {_timeAtButtonUp}");
    }

    private void OnCharged(double time)
    {
        _laserCharged?.Invoke(time);
    }
     
    public void EnableChargedListener(Action<double> method)
    {
        _laserCharged += method;
    }
}
