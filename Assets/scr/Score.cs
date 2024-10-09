using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Score 
{
    public string header;
    public string stats;
    public string comment;
    public bool reason;

    public Score(string h, string s, string c, bool r)
    {
        header = h;
        stats = s;
        comment = c;
        reason = r;
    }
}
