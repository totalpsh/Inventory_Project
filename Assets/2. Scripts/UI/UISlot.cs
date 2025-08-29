using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;

    public InventoryUI inventoryUI;
    public Image icon;
    public Image equipIcon;
    public Button button;

    public int index;
    public bool equipped;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClickSlot);

        icon.gameObject.SetActive(false);
        equipIcon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;

        if(equipIcon != null)
        {
            equipIcon.gameObject.SetActive(equipped);
        }
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
    }

    public void OnClickSlot()
    {
        inventoryUI.SelectItem(index);
    }
}
