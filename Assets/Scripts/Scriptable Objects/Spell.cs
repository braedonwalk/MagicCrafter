using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "MagiCrafter/Spell", order = 0)]
public class Spell : ScriptableObject {
    
    public string spellName;

    public Sprite sprite;

    public int id; // thousands is type, hundreds/tens is effect it can give

    // 0 = null, projectile = 1, aoe = 2, self = 3
    public int spellType = 0;
    public float cooldown;
    public float damage=0f;
    public GameObject prefab;
    public float originDistance;    //projectile = 1, aoe = var, self = 0

    public bool canCauseBurning=false;
    public bool canCauseWet=false;
    public bool canCauseSlow=false;

    public float speed = 0f;

    public float diameter = 0f;
    public float range = 0f;

    public float duration;

    public GameObject effectPrefab;

}

