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
        if (isDraggable())        
            {
                canvasGroup.alpha = 0.6f;
                canvasGroup.blocksRaycasts = false;  // check on this- WHAT IS IT????????
            }
    }

     public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggable())        
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = startingPos;

            // if it is  result spell that is dragged, then put it back to the empty spell
            if (isValidDraggableObject(this.gameObject, "ResultSpell"))
            {
                this.gameObject.GetComponent<SpellDisplay>().setSpell(this.gameObject.GetComponent<SpellDisplay>().getEmptySpell());
            }
        }
    }

     public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable())
        {
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }
    }

    bool isDraggable()
    {
        // return isElement(this.gameObject) || isValidResult(this.gameObject) || isKnownSpell(this.gameObject);
        GameObject currentGameObject = this.gameObject;
        string[] draggableTags = {"Element", "Modifier", "ResultSpell", "KnownSpell"};

        foreach (string tag in draggableTags)
        {
            if (isValidDraggableObject(currentGameObject, tag))
            {
                return true;
            }
        }

        return false;
    }

    bool isValidDraggableObject(GameObject gameObject, string tag)
    {
        if (gameObject.tag == tag && gameObject.GetComponent<SpellDisplay>().getSpell() != gameObject.GetComponent<SpellDisplay>().getEmptySpell())
        {
            return true;
        }

        return false;
    }
}
