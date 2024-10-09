using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCreature : MonoBehaviour
{
    private Action<bool> _next;
    private Action _monster;

    public void init(Action<bool> next)
    {
        _next = next;
    }

    private void OnMouseDown()
    {
        _next?.Invoke(false);
    }
}
