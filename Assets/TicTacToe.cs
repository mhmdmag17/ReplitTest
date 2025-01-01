using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour
{
    public GameObject[] squares;
    public TMP_Text gameText;
    public Button restartButton;

    private int playerTurn = 1;
    private int[] board = new int[9];

    void Start()
    {
        restartButton.gameObject.SetActive(false);
    }

    public void SquareClicked(int index)
    {
        if (board[index] == 0)
        {
            board[index] = playerTurn;
            squares[index].GetComponentInChildren<TMP_Text>().text = playerTurn == 1 ? "X" : "O";
            CheckForWinner();
            ChangeTurn();
        }
    }

    private void ChangeTurn()
    {
        playerTurn = playerTurn == 1 ? 2 : 1;
        gameText.text = "Player " + playerTurn + "'s turn";
    }

    private void CheckForWinner()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i * 3] != 0 && board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2])
            {
                DeclareWinner(board[i * 3]);
                return;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i] != 0 && board[i] == board[i + 3] && board[i] == board[i + 6])
            {
                DeclareWinner(board[i]);
                return;
            }
        }

        // Check diagonals
        if (board[0] != 0 && board[0] == board[4] && board[0] == board[8])
        {
            DeclareWinner(board[0]);
            return;
        }
        if (board[2] != 0 && board[2] == board[4] && board[2] == board[6])
        {
            DeclareWinner(board[2]);
            return;
        }

        // Check for draw
        if (IsBoardFull())
        {
            DeclareWinner(0);
            return;
        }
    }

    private bool IsBoardFull()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    private void DeclareWinner(int winner)
    {
        if (winner == 1)
        {
            gameText.text = "Player 1 wins!";
        }
        else if (winner == 2)
        {
            gameText.text = "Player 2 wins!";
        }
        else
        {
            gameText.text = "It's a draw!";
        }
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        playerTurn = 1;
        for (int i = 0; i < 9; i++)
        {
            board[i] = 0;
            squares[i].GetComponentInChildren<TMP_Text>().text = "";
        }
        gameText.text = "Player 1's turn";
        restartButton.gameObject.SetActive(false);
    }
}