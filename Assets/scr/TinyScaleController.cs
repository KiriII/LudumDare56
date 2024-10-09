using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyScaleController 
{
    public static int CountScaleResult(float needScale, float currentScale)
    {
        var delta = Mathf.Abs(needScale - currentScale) * 10;
        Debug.Log($"{nameof(needScale)}: {needScale}, {nameof(currentScale)}: {currentScale} = {(int)delta / 1}");
        var currentDelta = (int)delta / 1;
        for (int i = 0; i < 11; i++)
        {
            currentDelta = currentDelta - (20 + i);
            if (currentDelta <= 0)
            {
                return 10 - i;
            }
        }
        return 0;
    }
}
