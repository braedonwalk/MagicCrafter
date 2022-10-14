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
        // handleSpellSelectKey(1);
        // handleSpellSelectKey(2);
        // handleSpellSelectKey(3);
        // handleSpellSelectKey(4);

        if(Input.GetButtonDown("Fire1"))
        {
            castActiveSpell();
        }
    }

    void castActiveSpell()
    {
        if (activeSpell != null)
        {
            if(activeSpell.spellName == "Lava")
            {
                Debug.Log("Shoot fireball");
            }
        }
    }

    void makeActiveSpellDefault()
    {
        if (activeSpellSlots[0].GetComponent<SpellDisplay>().getSpell() != null)
        {
            activeSpell = activeSpellSlots[0].GetComponent<SpellDisplay>().getSpell();
            Debug.Log("test");
        }
    }

    void handleSpellSelectKey(int keyNum)
    {
         if (Input.GetKeyDown(keyNum.ToString()) && activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell() != null)
        {
            activeSpell = activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell();
            Debug.Log(activeSpell);
        }
        else if(Input.GetKeyDown(keyNum.ToString()) && activeSpellSlots[keyNum-1].GetComponent<SpellDisplay>().getSpell() == null)
        {
            activeSpell = emptySpell;
        }
    }

    public Spell getActiveSpell()
    {
        return activeSpell;
    }

}
