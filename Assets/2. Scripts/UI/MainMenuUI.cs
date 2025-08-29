using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : BaseUI
{
    [SerializeField] private Image mainMenuBG;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI goldText;

    Player player;

    public event Action StatusOpen;
    public event Action InventoryOpen;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        statusButton.onClick.AddListener(StatusButtonClick);
        inventoryButton.onClick.AddListener(InventoryButtonClick);

        mainMenuBG.gameObject.SetActive(true);
    }

    private void InventoryButtonClick()
    {
        InventoryOpen?.Invoke();
    }

    private void StatusButtonClick()
    {
        StatusOpen?.Invoke();
    }

    public void OpenUI()
    {
        mainMenuBG.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        mainMenuBG.gameObject.SetActive(false);
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
        UpdateUI();
    }

    private void UpdateUI()
    {
        nameText.text = player.stats.Name.ToString();
        levelText.text = player.stats.Level.ToString();
        descText.text = player.stats.Description.ToString();
        goldText.text = $"{player.stats.Gold.ToString()} G";
    }
}
