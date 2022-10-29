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
    [SerializeField] Spell fireBlast;
    [SerializeField] Spell bubble;
    [SerializeField] Spell rockRoll;
    [SerializeField] Spell explosion;
    [SerializeField] Spell wave;
    [SerializeField] Spell earthquake;
    [SerializeField] Spell burningSpeed;
    [SerializeField] Spell heal;
    [SerializeField] Spell rockArmor;

    // EEM spells with different E's 

    [SerializeField] Spell steam;
    [SerializeField] Spell steamCloud;
    [SerializeField] Spell invisibility;
    [SerializeField] Spell mudShot;
     [SerializeField] Spell mudPlop;
      [SerializeField] Spell mudSelf;
    [SerializeField] Spell lava;
     [SerializeField] Spell meteorStrike;
      [SerializeField] Spell burningMan;
   

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
        recipeList.Add(new List<Spell> {fire, fire, projectile, fireBlast});
        recipeList.Add(new List<Spell> {fire, fire, aoe, explosion});
        recipeList.Add(new List<Spell> {fire, fire, self, burningSpeed});
        recipeList.Add(new List<Spell> {water, water, projectile, bubble});
        recipeList.Add(new List<Spell> {water, water, aoe, wave});
        recipeList.Add(new List<Spell> {water, water, self, heal});
        recipeList.Add(new List<Spell> {earth, earth, projectile, rockRoll});
        recipeList.Add(new List<Spell> {earth, earth, aoe, earthquake});
        recipeList.Add(new List<Spell> {earth, earth, self, rockArmor});

        // spells made from different elements and modifier
        
        recipeList.Add(new List<Spell> {fire, water, projectile, steam});
        recipeList.Add(new List<Spell> {fire, water, aoe, steamCloud});
        recipeList.Add(new List<Spell> {fire, water, self, invisibility});
        recipeList.Add(new List<Spell> {water, earth, projectile, mudShot});
        recipeList.Add(new List<Spell> {water, earth, aoe, mudPlop});
        recipeList.Add(new List<Spell> {water, earth, self, mudSelf});
        recipeList.Add(new List<Spell> {fire, earth, projectile, lava});
        recipeList.Add(new List<Spell> {fire, earth, aoe, meteorStrike});
        recipeList.Add(new List<Spell> {fire, earth, self, burningMan});
        
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
