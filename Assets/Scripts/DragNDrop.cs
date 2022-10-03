using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    [SerializeField] private Canvas canvas;
    [SerializeField] Spell emptySpell;

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
        if (isElement(this.gameObject) || isValidResult(this.gameObject) || isKnownSpell(this.gameObject))        
            {
                canvasGroup.alpha = 0.6f;
                canvasGroup.blocksRaycasts = false;  // check on this- WHAT IS IT????????
            }
    }

     public void OnEndDrag(PointerEventData eventData)
    {
        if (isElement(this.gameObject) || isValidResult(this.gameObject) || isKnownSpell(this.gameObject))        
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = startingPos;

            if (isValidResult(this.gameObject))
            {
                this.gameObject.GetComponent<ResultSlot>().setCurrentSpell(this.gameObject.GetComponent<ResultSlot>().getEmptySpell());
                this.gameObject.GetComponent<ResultSlot>().setSprite();
            }

            if (isKnownSpell(this.gameObject))
            {
                // change equipped spell appearance
            }
        }
    }

     public void OnDrag(PointerEventData eventData)
    {
        if (isElement(this.gameObject) || isValidResult(this.gameObject) || isKnownSpell(this.gameObject) )
        {
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }
    }


    bool isElement(GameObject aGameObject)
    {
        if (aGameObject.tag == "Element")
        {
            return true;
        }
        
        return false;
    }

    bool isValidResult(GameObject aGameObject)
    {
        if (aGameObject.tag == "ResultSpell" && aGameObject.GetComponent<ResultSlot>().getCurrentSpell() != aGameObject.GetComponent<ResultSlot>().getEmptySpell())
        {
            return true;
        }
        
        return false;
    }

    bool isKnownSpell(GameObject aGameObject)
    {
        if (aGameObject.tag == "KnownSpell" && aGameObject.GetComponent<KnownSpellSlot>().getSpell() != emptySpell)
        {
            return true;
        }

        return false;
    }

    public Spell getEmptySpell()
    {
        return emptySpell;
    }
}
