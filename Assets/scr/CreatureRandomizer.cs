using System;
using System.Collections;
using System.Collections.Generic;

public static class CreatureRandomizer 
{
    private static readonly int MIN_SCALE = 10;
    private static readonly int MAX_SCALE = 50;
    private static readonly int MAX_SKIN_COUNT = 7;

    public static Creature GenerateCreature()
    {
        Random rand1 = new();
        var scale = rand1.Next(MIN_SCALE, MAX_SCALE);
        Random rand2 = new();
        var color = rand2.Next(MAX_SKIN_COUNT);
        Random rand3 = new();
        var glaza = rand3.Next(MAX_SKIN_COUNT);
        Random rand4 = new();
        var smile = rand4.Next(MAX_SKIN_COUNT);
        Random rand5 = new();
        var hat = rand4.Next(MAX_SKIN_COUNT);

        return new Creature((float)scale, color, glaza, smile, hat);
    }
}
