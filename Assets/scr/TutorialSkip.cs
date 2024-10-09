using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkip : MonoBehaviour
{
    void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }
}
