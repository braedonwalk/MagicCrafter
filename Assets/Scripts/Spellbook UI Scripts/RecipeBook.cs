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

    //EXM Spells
    [SerializeField] Spell fireProjectile;
    [SerializeField] Spell fireAOE;
    [SerializeField] Spell fireSelf;

    [SerializeField] Spell waterProjectile;
    [SerializeField] Spell waterAOE;
    [SerializeField] Spell waterSelf;

    [SerializeField] Spell earthProjectile;
    [SerializeField] Spell earthAOE;
    [SerializeField] Spell earthSelf;

    // EEM spells with identical E's
    [SerializeField] Spell fireFireProj;
    [SerializeField] Spell waterWaterProj;
    [SerializeField] Spell earthEarthProj;
    [SerializeField] Spell fireFireAOE;
    [SerializeField] Spell waterWaterAOE;
    [SerializeField] Spell earthEarthAOE;
    [SerializeField] Spell fireFireSelf;
    [SerializeField] Spell waterWaterSelf;
    [SerializeField] Spell earthEarthSelf;

    // EEM spells with different E's 

    [SerializeField] Spell fireWaterProj;
    [SerializeField] Spell fireWaterAOE;
    [SerializeField] Spell fireWaterSelf;
    [SerializeField] Spell waterEarthProj;
    [SerializeField] Spell waterEarthAOE;
    [SerializeField] Spell waterEarthSelf;
    [SerializeField] Spell fireEarthProj;
    [SerializeField] Spell fireEarthAOE;
    [SerializeField] Spell fireEarthSelf;

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


        // spells made from double of same element and 
        recipeList.Add(new List<Spell> {fire, fire, projectile, fireFireProj});
        recipeList.Add(new List<Spell> {fire, fire, aoe, fireFireAOE});
        recipeList.Add(new List<Spell> {fire, fire, self, fireFireSelf});
        recipeList.Add(new List<Spell> {water, water, projectile, waterWaterProj});
        recipeList.Add(new List<Spell> {water, water, aoe, waterWaterAOE});
        recipeList.Add(new List<Spell> {water, water, self, waterWaterSelf});
        recipeList.Add(new List<Spell> {earth, earth, projectile, earthEarthProj});
        recipeList.Add(new List<Spell> {earth, earth, aoe, earthEarthAOE});
        recipeList.Add(new List<Spell> {earth, earth, self, earthEarthSelf});

        // spells made from different elements and modifier
        
        recipeList.Add(new List<Spell> {fire, water, projectile, fireWaterProj});
        recipeList.Add(new List<Spell> {fire, water, aoe, fireWaterAOE});
        recipeList.Add(new List<Spell> {fire, water, self, fireWaterSelf});
        recipeList.Add(new List<Spell> {water, earth, projectile, waterEarthProj});
        recipeList.Add(new List<Spell> {water, earth, aoe, waterEarthAOE});
        recipeList.Add(new List<Spell> {water, earth, self, waterEarthSelf});
        recipeList.Add(new List<Spell> {fire, earth, projectile, fireEarthProj});
        recipeList.Add(new List<Spell> {fire, earth, aoe, fireEarthAOE});
        recipeList.Add(new List<Spell> {fire, earth, self, fireEarthSelf});
        
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
                Debug.Log(result.spellName);
                spellDisplay.setSpell(result);
            }      
        }
    }
}
