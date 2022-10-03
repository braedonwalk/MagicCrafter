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

    }
     public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;  // check on this- WHAT IS IT????????
    }

     public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = startingPos;
    }

     public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }


}
