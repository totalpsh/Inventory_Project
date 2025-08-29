using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private StatusUI statusUI;

    public Player player;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) Destroy(Instance);

    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuUI.Init(this);
        inventoryUI.Init(this);
        statusUI.Init(this);

        mainMenuUI.StatusOpen += mainMenuUI.CloseUI;
        mainMenuUI.StatusOpen += statusUI.OpenUI;

        mainMenuUI.InventoryOpen += mainMenuUI.CloseUI;
        mainMenuUI.InventoryOpen += inventoryUI.OpenUI;

        statusUI.ClickOnBack += statusUI.CloseUI;
        statusUI.ClickOnBack += mainMenuUI.OpenUI;

        inventoryUI.ClickOnBack += inventoryUI.CloseUI;
        inventoryUI.ClickOnBack += mainMenuUI.OpenUI;

        this.player = GameManager.Instance.Player;
        player.equipItem += statusUI.UpdateUI;
    }

    public void SetPlayer(Player player)
    {
        mainMenuUI.SetPlayer(player);
        statusUI.SetPlayer(player);
    }
}
