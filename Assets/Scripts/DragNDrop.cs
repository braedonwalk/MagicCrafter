using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private Vector2 startingPos;
    private CanvasGroup canvasGroup;

    private void Start() {
        rectTransform = this.GetComponent<RectTransform>();
        startingPos = rectTransform.anchoredPosition;

        canvasGroup = this.GetComponent<CanvasGroup>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("mouse down");
    }
     public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(("start drag"));
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;  // check on this- WHAT IS IT????????
    }

     public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(("end drag"));
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = startingPos;
    }

     public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(("dragging"));
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }


}
