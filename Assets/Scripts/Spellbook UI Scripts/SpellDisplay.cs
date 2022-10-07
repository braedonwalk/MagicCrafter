using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDisplay : MonoBehaviour
{
    
    [SerializeField] Spell spell;

    // [SerializeField] Text spellName;
    [SerializeField] Image image;

    public static SpellDisplay Instance {get; private set;} // not used now

    
    // Start is called before the first frame update
    void Start()
    {
        image.sprite = spell.sprite;
    }

    public Spell getSpell()
    {
        return spell;
    }


}
