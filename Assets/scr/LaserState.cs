using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LaserState
{
    private Action<double> _laserShot;

    public LaserState(Action<double> laserShot, Action<double> other)
    {
    }

    public abstract LaserState OtherState();

    public abstract void LaserShot(double time);
}
