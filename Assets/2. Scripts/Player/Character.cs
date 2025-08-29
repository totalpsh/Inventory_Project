using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public string Description { get; private set; }
    public int Gold { get; private set; }
    public float Health { get;  set; }
    public float Attack { get;  set; }
    public float Defence { get;  set; }
    public float Critical { get;  set; }

    Player player;

    public Character(string name, int level, string description, int gold, float health, float attack, float defence, float critical)
    {
        Name = name;
        Level = level;
        Description = description;
        Gold = gold;
        Health = health;
        Attack = attack;
        Defence = defence;
        Critical = critical;
    }

}
