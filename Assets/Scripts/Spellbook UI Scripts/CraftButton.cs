using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    
    [SerializeField] SpellDisplay spellSlot1;
    [SerializeField] SpellDisplay spellSlot2;
    [SerializeField] SpellDisplay modifierSlot;
    [SerializeField] RecipeBook recipeBook;
    

    public void craft()
    {
        Spell spell1 = spellSlot1.getSpell();
        Spell spell2 = spellSlot2.getSpell();
        Spell modifier = modifierSlot.getSpell();

        if (spell1 != null && spell2 != null && modifier != null)
        {
            recipeBook.getResult(spell1, spell2, modifier);
        }
    }

}
