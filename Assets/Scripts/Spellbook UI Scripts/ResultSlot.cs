using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
    
    List<List<Spell>> recipeList = new List<List<Spell>>();

    [SerializeField] Spell empty;
    [SerializeField] Spell fire;
    [SerializeField] Spell rock;
    [SerializeField] Spell water;
    [SerializeField] Spell lava;
    [SerializeField] Spell steam;
    [SerializeField] Spell mud;

    Spell currentSpell;
    Image image;
    Sprite defaultSprite;


    void setupRecipes()
    {
        recipeList.Add(new List<Spell> {fire, rock, lava});
        recipeList.Add(new List<Spell> {fire, water, steam});
        recipeList.Add(new List<Spell> {water, rock, mud});
    }
                                
        void Start()
    {
        setupRecipes();

        currentSpell = empty;
        image = this.GetComponent<Image>();
        defaultSprite = image.sprite;
    }

    public void getResult(Spell spell1, Spell spell2)
    {

        foreach (List<Spell> subList in recipeList)
        {
            Spell ingredient1 = subList[0];
            Spell ingredient2 = subList[1];
            Spell result = subList[2];

            if ( (ingredient1 == spell1 && ingredient2 == spell2)  || (ingredient2 == spell1 && ingredient1 == spell2) )
            {
                currentSpell = result;
                image.sprite = result.sprite;
            }
        }
    }

    public Spell getCurrentSpell()
    {
        return currentSpell;
    }

    public void setCurrentSpell(Spell newSpell)
    {
        currentSpell = newSpell;
    }

    public Spell getEmptySpell()
    {
        return empty;
    }

    public void setSprite()
    {
        image.sprite = defaultSprite;
    }

}
