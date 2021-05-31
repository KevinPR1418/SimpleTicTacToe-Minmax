using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button;
    public Text buttontext;
    

    private GameControler gameControler;

    public void setButton()
    {
        buttontext.text = gameControler.getPlayerSide();
        button.interactable = false;
        gameControler.EndTurn();
    }

    public void SetGameController(GameControler controler)
    {
        gameControler = controler;
    }
}
