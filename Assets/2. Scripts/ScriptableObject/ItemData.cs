using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite icon;

    public float att;
    public float def;
    public float hp;
    public float critical;

    public int price;

}
