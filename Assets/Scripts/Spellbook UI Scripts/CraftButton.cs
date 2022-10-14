using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftButton : MonoBehaviour
{
    
    [SerializeField] SpellDisplay spellSlot1;
    [SerializeField] SpellDisplay spellSlot2;
    [SerializeField] RecipeBook recipeBook;

    Spell spell1;
    Spell spell2;
    

    public void craft()
    {
        spell1 = spellSlot1.getSpell();
        spell2 = spellSlot2.getSpell();

        if (spell1 != null && spell2 != null)
        {
            recipeBook.getResult(spell1, spell2);
        }
    }

}
