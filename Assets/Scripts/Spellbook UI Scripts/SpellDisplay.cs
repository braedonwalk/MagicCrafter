using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    
    [SerializeField] Spell spell;
    [SerializeField] Spell emptySpell;

    Image image;

    public static SpellDisplay Instance {get; private set;} // not used now

    
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        image.sprite = spell.sprite;
    }

    public Spell getSpell()
    {
        return spell;
    }

    public void setSpell(Spell newSpell)
    {
        this.spell = newSpell;
        this.image.sprite = newSpell.sprite;
    }

    public Spell getEmptySpell()
    {
        return emptySpell;
    }

}
