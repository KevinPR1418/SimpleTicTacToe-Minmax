using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public Text[] buttonList;
    private string playerside;

    public GameObject GameOverPanel;
    public Text GameOverText;
    public Text TurnText;

    private bool playerTurn;
    int movecount;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        setGameControllerReferenceButton();
        playerside = "X";
        playerTurn = true;
        movecount = 0;

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";

        }
    }

    void setGameControllerReferenceButton()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<ButtonController>().SetGameController(this);
        }
    }

    public string getPlayerSide()
    {
        return playerside;
    }

    public void EndTurn()
    {
        movecount++;
        if (buttonList[0].text == playerside && buttonList[1].text == playerside && buttonList[2].text == playerside )
        {
            GameOver();
        }
        else if (buttonList[0].text == playerside && buttonList[3].text == playerside && buttonList[6].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[0].text == playerside && buttonList[4].text == playerside && buttonList[8].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[1].text == playerside && buttonList[4].text == playerside && buttonList[7].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[2].text == playerside && buttonList[5].text == playerside && buttonList[8].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[3].text == playerside && buttonList[4].text == playerside && buttonList[5].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[6].text == playerside && buttonList[4].text == playerside && buttonList[2].text == playerside)
        {
            GameOver();
        }
        else if (buttonList[6].text == playerside && buttonList[7].text == playerside && buttonList[8].text == playerside)
        {
            GameOver();
        }
        else if (movecount >= 9)
        {
            itsDraw();
        }

        ChangeSide();
        
    }

    public void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable= false;
        }

        GameOverPanel.SetActive(true);
        GameOverText.text = " " + playerside + "  Wins";
    }
    public void itsDraw()
    {
        GameOverPanel.SetActive(true);
        GameOverText.text = "a draw";
    }

    public void ChangeSide()
    {
        if (playerside == "X")
        {
            playerside = "O";
        }
        else
        {
            playerside = "X";
        }

        if (playerTurn == true)
        {
            playerTurn = false;
        }
        else
        {
            playerTurn = true;
        }
        //playerTurn = (playerTurn == true) ? false : true;
    }

    public void ResetGame()
    {
        GameOverPanel.SetActive(false);
        playerside = "X";
        movecount = 0;

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";

        }
        TurnText.text = "first Player Turn";
        TurnText.GetComponentInParent<Button>().interactable = true;
    }

    public void setTurn()
    {
        ChangeSide();
        TurnText.text = "first AI Turn";
        TurnText.GetComponentInParent<Button>().interactable = false;
    }






    private void Update()
    {
        if (playerTurn == false)
        {
            BestMove();
        }
    }

    private void BestMove()
    {
        int bestScore = int.MinValue;
        Point bestMove;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (buttonList[x * 3 + y].text == "")
                {
                    buttonList[x * 3 + y].text = "O";
                    int score = MiniMax(buttonList, 0, int.MinValue, int.MaxValue, false);
                    buttonList[x * 3 + y].text = "";
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = new Point(x, y);
                    }
                }
            }
        }
        UpdateBestMoveCell(bestMove);
    }

    public string CheckForWinner(Text[] list)
    {
        string winner = null;
        if (list[0].text == "X" && list[1].text == "X" && list[2].text == "X")
        {
            winner = "X";
        }
        else if (list[0].text == "X" && list[3].text == "X" && list[6].text == "X")
        {
            winner = "X";
        }
        else if (list[0].text == "X" && list[4].text == "X" && list[8].text == "X")
        {
            winner = "X";
        }
        else if (list[1].text == "X" && list[4].text == "X" && list[7].text == "X")
        {
            winner = "X";
        }
        else if (list[2].text == "X" && list[5].text == "X" && list[8].text == "X")
        {
            winner = "X";
        }
        else if (list[3].text == "X" && list[4].text == "X" && list[5].text == "X")
        {
            winner = "X";
        }
        else if (list[6].text == "X" && list[4].text == "X" && list[2].text == "X")
        {
            winner = "X";
        }
        else if (list[6].text == "X" && list[7].text == "X" && list[8].text == "X")
        {
            winner = "X";
        }

        
        if (list[0].text == "O" && list[1].text == "O" && list[2].text == "O")
        {
            winner = "O";
        }
        else if (list[0].text == "O" && list[3].text == "O" && list[6].text == "O")
        {
            winner = "O";
        }
        else if (list[0].text == "O" && list[4].text == "O" && list[8].text == "O")
        {
            winner = "O";
        }
        else if (list[1].text == "O" && list[4].text == "O" && list[7].text == "O")
        {
            winner = "O";
        }
        else if (list[2].text == "O" && list[5].text == "O" && list[8].text == "O")
        {
            winner = "O";
        }
        else if (list[3].text == "O" && list[4].text == "O" && list[5].text == "O")
        {
            winner = "O";
        }
        else if (list[6].text == "O" && list[4].text == "O" && list[2].text == "O")
        {
            winner = "O";
        }
        else if (list[6].text == "O" && list[7].text == "O" && list[8].text == "O")
        {
            winner = "O";
        }
        int openSpots = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (list[i * 3 + j].text == "")
                {
                    openSpots++;
                }
            }
        }
        if (winner == null && openSpots == 0)
        {
            return "tie";
        }
        else
        {
            return winner;
        }
        
        
    }

    
    private int MiniMax(Text[] List, int depth, int alpha, int beta, bool isMaximizing)
    {
        string result = CheckForWinner(List);
        if (result != null)
        {
            if (result == "X")
                return -10;
            else if (result == "O")
                return 10;
            else if (result == "tie")
                return 0;
        }
        if (isMaximizing) // gets next best move
        {
            int bestScore = int.MinValue;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (List[x * 3 + y].text == "")
                    {
                        List[x * 3 + y].text = "O";
                        int score = MiniMax(List, depth++, alpha, beta, false);
                        List[x * 3 + y].text = "";
                        bestScore = Math.Max(bestScore, score);
                        //alpha = Math.Max(alpha, score);
                        //if (beta >= alpha)
                        //{
                        //    break;
                        //}
                    }
                }
            }
            return bestScore;
        }
        else // gets next worst move
        {
            int bestScore = int.MaxValue;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (List[x * 3 + y].text == "")
                    {
                        List[x * 3 + y].text = "X";
                        int score = MiniMax(List, depth++, alpha, beta, true);
                        List[x * 3 + y].text = "";
                        bestScore = Math.Min(bestScore, score);
                        //beta = Math.Min(beta, score);
                        //if (beta <= alpha)
                        //{
                        //    break;
                        //}
                    }
                }
            }
            return bestScore;
        }
    }
    private void UpdateBestMoveCell(Point bestMove) 
    {
        buttonList[bestMove.X * 3 + bestMove.Y].text = playerside;
        buttonList[bestMove.X * 3 + bestMove.Y].GetComponentInParent<Button>().interactable = false;
        EndTurn();
    }

}
