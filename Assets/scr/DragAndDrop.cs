using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas _canvas;
    public GameObject cameraObj;
    public GameObject textBubble;
    public Text text;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector3 startPostion;
    private GameObject _raycastHit;

    // delegate
    private Func<string> _getText;

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            _raycastHit = hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
            _raycastHit = null;
        }
    }

    public void init(Canvas canvas, Func<string> getText)
    {
        _canvas = canvas;
        _getText = getText;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        startPostion = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        HideTextBubble();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_raycastHit is not null)
        {
            if (string.Equals(_raycastHit.name, "CreatureForMagnifierGlass"))
            {
                ShowTextBubble();
            }
        }

        cameraObj.transform.localPosition = new Vector3(0, -10000, 50);
        _canvasGroup.blocksRaycasts = true;
        transform.localPosition = startPostion;
    }

    private void ShowTextBubble()
    {
        textBubble.SetActive(true);
        text.text = _getText.Invoke();
    }

    public void HideTextBubble()
    {
        cameraObj.transform.localPosition = new Vector3(0, 0, 50);
        textBubble.SetActive(false);
    }
}
