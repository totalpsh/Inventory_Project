using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] ItemObject[] items;
    [SerializeField] Button spawnButton;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player;

        spawnButton.onClick.AddListener(RandomSpawnItem);

    }

    void RandomSpawnItem()
    {
        int index = Random.Range(0, items.Length);

        ItemObject item = Instantiate(items[index]);
        item.OnSpawn();

    }
}
