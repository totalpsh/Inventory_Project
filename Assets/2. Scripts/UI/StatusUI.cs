using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    [SerializeField] Button BackButton;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI defenceText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI criticalText;

    Player player;

    public event Action ClickOnBack;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        BackButton.onClick.AddListener(GoBackMainMenu);
        this.gameObject.SetActive(false);
    }

    public void GoBackMainMenu()
    {
        ClickOnBack?.Invoke();
    }

    public void OpenUI()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }
    public void SetPlayer(Player player)
    {
        this.player = player;
        UpdateUI();
    }

    public void UpdateUI()
    {
        attackText.text = player.stats.Attack.ToString();
        defenceText.text = player.stats.Defence.ToString();
        healthText.text = player.stats.Health.ToString();
        criticalText.text = player.stats.Critical.ToString();
    }
}
