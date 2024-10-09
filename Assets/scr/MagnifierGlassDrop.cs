using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagnifierGlassDrop : MonoBehaviour, IDropHandler, IPointerUpHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"Drop {eventData.pointerDrag}");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"Drop {eventData.pointerDrag}");
    }
}
