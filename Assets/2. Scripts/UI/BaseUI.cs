using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public void ActiveOn()
    {
        this.gameObject?.SetActive(true);
    }

    public void ActiveOff()
    {
        this.gameObject?.SetActive(false);
    }
}
