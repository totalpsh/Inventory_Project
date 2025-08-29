using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character stats;
    public ItemData itemData;

    public ItemData equippedItem;

    public Action addItem;
    public Action equipItem;

    public void UpdateStatus()
    {
        if (equippedItem == null) return;

        stats.Attack += equippedItem.att;
        stats.Defence += equippedItem.def;
        stats.Health += equippedItem.hp;
        stats.Critical += equippedItem.critical;

        equipItem?.Invoke();
    }

    public void UnEquipStatus()
    {
        if (equippedItem == null) return;

        stats.Attack -= equippedItem.att;
        stats.Defence -= equippedItem.def;
        stats.Health -= equippedItem.hp;
        stats.Critical -= equippedItem.critical;
    }
}
