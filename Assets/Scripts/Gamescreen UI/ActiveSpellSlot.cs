using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellSlot : MonoBehaviour
{
    
    Image image;
    [SerializeField] Spell spell = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        image = this.GetComponent<Image>();
        
        if (spell != null)
        {
            image.sprite = spell.sprite;
        }
    }


public void setSpell(Spell newSpell)
{
    spell = newSpell;
    image.sprite = newSpell.sprite;
}

public Spell getSpell()
{
    return spell;
}

}
