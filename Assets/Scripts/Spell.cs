using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "MagiCrafter/Spell", order = 0)]
public class Spell : ScriptableObject {
    
    public string spellName;

    public Sprite sprite;
}

