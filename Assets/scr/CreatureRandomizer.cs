using System;
using System.Collections;
using System.Collections.Generic;

public static class CreatureRandomizer 
{
    private static readonly int MIN_SCALE = 10;
    private static readonly int MAX_SCALE = 50;
    private static readonly int MAX_SKIN_COUNT = 7;

    public static Creature GenerateCreature(Creature curCreature)
    {
        Random rand1 = new();
        var scale = rand1.Next(MIN_SCALE, MAX_SCALE);
        Random rand2 = new();
        var color = rand2.Next(0, MAX_SKIN_COUNT);
        if (color == curCreature.skin)
        {
            if (color == MAX_SKIN_COUNT) color = 0;
            else color++;
        }
        Random rand3 = new();
        var glaza = rand3.Next(0, MAX_SKIN_COUNT);
        if (glaza == curCreature.glaza)
        {
            if (glaza == MAX_SKIN_COUNT) glaza = 0;
            else glaza++;
        }
        Random rand4 = new();
        var smile = rand4.Next(0, MAX_SKIN_COUNT);
        if (smile == curCreature.smile)
        {
            if (smile == MAX_SKIN_COUNT) smile = 0;
            else smile++;
        }
        Random rand5 = new();
        var hat = rand5.Next(0, MAX_SKIN_COUNT);
        if (hat == curCreature.hat)
        {
            if (hat == MAX_SKIN_COUNT) hat = 0;
            else hat++;
        }

        return new Creature((float)scale, color, glaza, smile, hat);
    }
}
