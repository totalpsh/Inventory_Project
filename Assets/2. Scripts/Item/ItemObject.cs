using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public ItemData data;

    public string GetItemInfo()
    {
        string str = $"{data.name} \n {data.description}";

        return str;
    }

    public void OnSpawn()
    {
        GameManager.Instance.Player.itemData = data;
        GameManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
