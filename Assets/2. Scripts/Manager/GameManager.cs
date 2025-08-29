using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    Character character;
    public Player Player { get; set; }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        if(playerPrefab != null && Player == null)
        {
            GameObject playerObj = Instantiate(playerPrefab);
            Player = playerObj.GetComponent<Player>();
            
        }
    }

    private void Start()
    {

        SetData();

        if (uiManager != null)
            uiManager.SetPlayer(Player);
    }
    
    void SetData()
    {
        if(Player != null)
        {
            Player.stats = new Character("박성한", 10, "괴물이다. 건드리면 안된다.", 200000,10, 10, 10, 10);
        }
    }
}