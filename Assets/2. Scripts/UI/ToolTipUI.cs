using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipUI : MonoBehaviour
{
    [SerializeField] private GameObject toolTipUI;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDesc;
    [SerializeField] private TextMeshProUGUI itemPrice;

    public void ShowToolTip(ItemData item, Vector2 _pos)
    {
        toolTipUI.SetActive(true);

        _pos += new Vector2(toolTipUI.GetComponent<RectTransform>().rect.width * 0.5f,
            -toolTipUI.GetComponent<RectTransform>().rect.height * 0.5f);
        toolTipUI.transform.position = _pos;

        itemName.text = item.name;
        itemDesc.text = item.description;
        itemPrice.text = item.price.ToString();
    }

    public void HideToolTip()
    {
        toolTipUI.SetActive(false);

        
    }
}
