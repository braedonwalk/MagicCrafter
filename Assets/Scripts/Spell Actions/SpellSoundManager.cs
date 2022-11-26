using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSoundManager : MonoBehaviour
{
    AudioSource audioSource;
    SpellAction spellAction;
    //CREATE A DICTIONARY OF AUDIOFILES AND ID NUMBERS?
    // [SerializeField] AudioClip fireProjectileCast;
    // [SerializeField] AudioClip fireProjectileHit;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        spellAction = GetComponent<SpellAction>();
    }

    Spell getActiveSpell()
    {
        return spellAction.getActiveSpell();
    }

    int getIdAttribute(int i)
    {
        return spellAction.getIdAttribute(i);
    }

    // bool checkElementType(int i, int j)
    // {
    //     if (getIdAttribute(0) == i && getIdAttribute(1) == j) { return true; }
    //     else { return false; }
    // }

    public void castSound()
    {
        audioSource?.PlayOneShot(getActiveSpell().castSound);
    }

    public void activeSound()
    {
        audioSource?.PlayOneShot(getActiveSpell().activeSound);
    }

    public void hitSound(Vector3 pos)
    {
        // audioSource?.PlayOneShot(getActiveSpell().hitSound);
        AudioSource.PlayClipAtPoint(getActiveSpell().hitSound, pos);
        // audioSource.Stop();
    }
}
