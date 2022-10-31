using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// gets active information from in game spell slots
// then read player key presses
// based on key presses, cast the spell from the appropriate slot (lots of ifs)

public class SpellInputManager : MonoBehaviour
{
    [SerializeField] Spell emptySpell;
    [SerializeField] ActiveSpellSlot[] activeSpellSlots;

    Spell activeSpell;

    int spellModifier;
    int spellEffect;
    
    void Start()
    {
        makeActiveSpellDefault();
    }

    void Update()
    {
        setActiveSpell();
    }

    void setActiveSpell()
    {
        for(int i = 1; i <= 4; i++)
        {
            handleSpellSelectKey(i);
        }

        updateSpellModifierAndEffect();
    }

    void makeActiveSpellDefault()
    {
        if (activeSpellSlots[0].GetComponent<SpellDisplay>().getSpell() != null)
        {
            activeSpell = activeSpellSlots[0].GetComponent<SpellDisplay>().getSpell();
            // Debug.Log("test");
        }
    }

    void handleSpellSelectKey(int keyNum)
    {
         if (Input.GetKeyDown(keyNum.ToString()) && activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell() != null)
        {
            activeSpell = activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell();
            Debug.Log(activeSpell + " Selected");

            for (int i=0; i< activeSpellSlots.Length; i++)
            {
                if ( i != keyNum-1)
                {
                    activeSpellSlots[i].setAlpha(0.3f);
                }

                else
                {
                    activeSpellSlots[i].setAlpha(1.0f);
                }
            }
        }
        else if(Input.GetKeyDown(keyNum.ToString()) && activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell() == null)
        {
            activeSpell = emptySpell;
        }
    }

    void updateSpellModifierAndEffect()
    {
        int id = activeSpell.id;
        
        List<int> listOfDigits = new List<int>();
        while(id > 0)
        {
            listOfDigits.Add(id % 10);
            id /= 10;
        }
        listOfDigits.Reverse();
        
        spellModifier = listOfDigits[2];
        spellEffect = listOfDigits[3];

    }

    public Spell getActiveSpell()
    {
        return activeSpell;
    }

    public int getSpellModifier()
    {
        return spellModifier;
    }

    public int getSpellEffect()
    {
        return spellEffect;
    }

}
