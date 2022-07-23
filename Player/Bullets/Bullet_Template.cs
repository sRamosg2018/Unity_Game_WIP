using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bullet: MonoBehaviour
{

    public GameObject hitEffect;
    public int damage = 3;
    public int critChance = 1;
    public int critDamageMultiplier = 2;
    public bool isCrit = false;
    public int speed = 4;






}
