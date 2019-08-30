using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instacne;
    public GameState gameState;
    private void Awake()
    {
        if(instacne==null)
        {
            instacne = this;
        }
        gameState = GameState.idle;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameState = GameState.play;
            UIManager.instance.ActionPanelWeaponsList(false);
        }
        else if (Input.GetKey(KeyCode.B))
        {
            gameState = GameState.pause;
            UIManager.instance.ActionPanelWeaponsList(true);
        }
    }

    public void Play()
    {
        gameState = GameState.play;
        UIManager.instance.ActionPanelStart(false);
    }

    public void CloseWeaponList()
    {
        UIManager.instance.ActionPanelWeaponsList(false);
        gameState = GameState.play;
    }

    public void OpenWeaponList()
    {
        UIManager.instance.ActionPanelWeaponsList(true);
        gameState = GameState.pause;
    }

} // class
