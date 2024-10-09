using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature 
{
    public readonly float needScale;
    public readonly int skin;
    public readonly int glaza;
    public readonly int smile;
    public readonly int hat;

    public Creature(float needScale, int skin, int glaza, int smile, int hat)
    {
        this.needScale = needScale;
        this.skin = skin;
        this.glaza = glaza;
        this.smile = smile;
        this.hat = hat;
    }
}
