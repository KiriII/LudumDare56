using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDeath : LaserState
{
    private Action<double> _laserShot;
    private Action<double> _other;
    public LaserDeath(Action<double> laserShot, Action<double> other) : base(laserShot, other)
    {
        _laserShot = laserShot;
        _other = other;
    }

    public override void LaserShot(double time)
    {
        _laserShot?.Invoke(time);
    }

    public override LaserState OtherState()
    {
        return new MagnifierState(_other, _laserShot);
    }
}
