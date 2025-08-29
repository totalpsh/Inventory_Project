using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    public UISlot[] slots;

    public Transform slotPanel;

    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;

    ItemData selectItem;
    int selectItemIndex = 0;
    int currentEquip = 0;

    int itemCount = 0;

    public event Action ClickOnBack;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        backButton.onClick.AddListener(GoBackMainMenu);
        equipButton.onClick.AddListener(EquipItem);
        unEquipButton.onClick.AddListener(() => UnEquipItem(currentEquip));
        this.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
        unEquipButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.Player.addItem += AddItem;

        slots = new UISlot[slotPanel.childCount];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<UISlot>();
            slots[i].index = i;
            slots[i].inventoryUI = this;
        }

    }

    public void GoBackMainMenu()
    {
        equipButton.gameObject.SetActive(false);
        unEquipButton.gameObject.SetActive(false);
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
    
    public void AddItem()
    {
        ItemData data = GameManager.Instance.Player.itemData;

        UISlot empty = GetEmptySlot();

        if(empty != null)
        {
            empty.item = data;
            itemCount++;
            UpdateUI();
            GameManager.Instance.Player.itemData = null;
            return;
        }
    }

    private void UpdateUI()
    {
        for(int i =0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                slots[i].SetItem();
            else
                slots[i].RefreshUI();
        }

        itemCountText.text = itemCount.ToString();
    }

    private UISlot GetEmptySlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectItem = slots[index].item;
        selectItemIndex = index;

        equipButton.gameObject.SetActive(true);
        unEquipButton.gameObject.SetActive(true);
    }

    public void EquipItem()
    {
        if (slots[currentEquip].equipped)
        {
            UnEquipItem(currentEquip);
        }

        slots[selectItemIndex].equipped = true;
        currentEquip = selectItemIndex;
        GameManager.Instance.Player.equippedItem = selectItem;
        GameManager.Instance.Player.UpdateStatus();
        UpdateUI();

        SelectItem(selectItemIndex);

    }

    private void UnEquipItem(int index)
    {
        slots[index].equipped = false;
        GameManager.Instance.Player.UnEquipStatus();
        GameManager.Instance.Player.equippedItem = null;
        UpdateUI();

        if(selectItemIndex == index)
        {
            SelectItem(selectItemIndex);
        }
    }
}
