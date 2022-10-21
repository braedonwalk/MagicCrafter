using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{
    
    List<List<Spell>> recipeList = new List<List<Spell>>();

    // Spells/Elements
    [SerializeField] Spell empty;

    // elements
    [SerializeField] Spell fire;
    [SerializeField] Spell earth;
    [SerializeField] Spell water;

    // crafted spells
    [SerializeField] Spell fireProjectile;
    [SerializeField] Spell fireAOE;
    [SerializeField] Spell fireSelf;

    
    [SerializeField] Spell waterProjectile;
    [SerializeField] Spell waterAOE;
    [SerializeField] Spell waterSelf;

    
    [SerializeField] Spell earthProjectile;
    [SerializeField] Spell earthAOE;
    [SerializeField] Spell earthSelf;

    [SerializeField] Spell lava;
    [SerializeField] Spell steam;
    [SerializeField] Spell mud;

    // Modifiers
    [SerializeField] Spell projectile;
    [SerializeField] Spell aoe;
    [SerializeField] Spell self;
    





    Spell currentSpell;
    Image image;
    Sprite defaultSprite;

    SpellDisplay spellDisplay;


    void setupRecipes()
    {
        // spells made from element and modifier
        recipeList.Add(new List<Spell> {fire, empty, projectile, fireProjectile});

        recipeList.Add(new List<Spell> {fire, empty, aoe, fireAOE});

        recipeList.Add(new List<Spell> {fire, empty, self, fireSelf});

        recipeList.Add(new List<Spell> {water, empty, projectile, waterProjectile});

        recipeList.Add(new List<Spell> {water, empty, aoe, waterAOE});

        recipeList.Add(new List<Spell> {water, empty, self, waterSelf});

        recipeList.Add(new List<Spell> {earth, empty, projectile, earthProjectile});

        recipeList.Add(new List<Spell> {earth, empty, aoe, earthAOE});

        recipeList.Add(new List<Spell> {earth, empty, self, earthSelf});


        // spells made from double of same element and modifier

        // spells made from different elements and modifier
        
        recipeList.Add(new List<Spell> {fire, earth, projectile, lava});
        recipeList.Add(new List<Spell> {fire, water, aoe, steam});
        recipeList.Add(new List<Spell> {water, earth, self, mud});
    }
                                
        void Start()
    {
        setupRecipes();

        spellDisplay = this.GetComponent<SpellDisplay>();

        currentSpell = empty;
        image = this.GetComponent<Image>();
        defaultSprite = image.sprite;
    }

    public void getResult(Spell spell1, Spell spell2, Spell modifier)
    {

        foreach (List<Spell> subList in recipeList)
        {
            Spell ingredient1 = subList[0];
            Spell ingredient2 = subList[1];
            Spell ingredient3 = subList[2];
            Spell result = subList[3];

            if ( ((ingredient1 == spell1 && ingredient2 == spell2)  || (ingredient2 == spell1 && ingredient1 == spell2)) && (ingredient3 == modifier))
            {
                spellDisplay.setSpell(result);
            }
        }
    }
}
