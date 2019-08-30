using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject PanelWeaponsList,PanelStart, PanelIntro;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        ActionPanelStart(true);
    }


    public void ActionPanelWeaponsList(bool action)
    {
        PanelWeaponsList.SetActive(action);
    }

    public void ActionPanelStart(bool action)
    {
        PanelStart.SetActive(action);
    }

    public void ActionPanelIntro(bool action)
    {
        PanelIntro.SetActive(action);
    }

}// class
