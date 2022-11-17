using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSoundManager : MonoBehaviour
{
    AudioSource audioSource;
    SpellAction spellAction;
    //CREATE A DICTIONARY OF AUDIOFILES AND ID NUMBERS?
    [SerializeField] AudioClip fireProjectileCast;
    [SerializeField] AudioClip fireProjectileHit;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spellAction = GetComponentInChildren<SpellAction>();
    }

    Spell getActiveSpell()
    {
        return spellAction.getActiveSpell();
    }

    public void checkSpellCast()
    {
        if (getActiveSpell().id == 1011)
        {
            audioSource?.PlayOneShot(fireProjectileCast);
        }
    }
}
