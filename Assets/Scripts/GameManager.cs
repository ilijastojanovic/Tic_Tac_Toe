using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField] private GridManager gridManager;
    private Turn currentTurn;
    private GridSquareState player1SquareState;
    private GridSquareState player2SquareState;
    private bool input = false;
    private GameState currentGameState;
    private float elapsedTime;
    private bool isRunningTime = true;
    private int player1MoveCounter;
    private int player2MoveCounter;
    [SerializeField] private Image player1CharacterImage;
    [SerializeField] private Image player2CharacterImage;
    [SerializeField] private Sprite blueCrossImage;
    [SerializeField] private Sprite yellowCircleImage;
    [SerializeField] private GameObject matchWinnerUI;
    [SerializeField] private TextMeshProUGUI matchWinnerText;
    [SerializeField] private TextMeshProUGUI Player1TurnText;
    [SerializeField] private TextMeshProUGUI Player2TurnText;
    [SerializeField] private TextMeshProUGUI currentMatchTimeText;
    [SerializeField] private TextMeshProUGUI player1MoveCounterText;
    [SerializeField] private TextMeshProUGUI player2MoveCounterText;
    [SerializeField] private WinLinesManager winLinesManager;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI totalMatchTimeTxt;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource drawSound;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("More than one GameManagers in scene");

            StartNewGame();
    }

    private void Update()
    {
        if (isRunningTime)
        {
            elapsedTime += Time.deltaTime;
            CurrentMatchTime();
        }
    }

    public void StartNewGame()
    {
        currentGameState = GameState.ongoing;

        gameOverUI.SetActive(false);
        player1MoveCounter = 0;
        player1MoveCounterText.text = player1MoveCounter.ToString();
        player2MoveCounter = 0;
        player2MoveCounterText.text = player1MoveCounter.ToString();
        gridManager.ResetGrid();
        ResetMatchTime();
        int turnOne = Random.Range(0, 2);
        currentTurn = (Turn)turnOne;

        if(turnOne == 0)
        {
            player2MoveCounter--;
            player1SquareState = GridSquareState.cross;
            player2SquareState = GridSquareState.circle;
        }
        else
        {
            player1MoveCounter--;
            player1SquareState = GridSquareState.circle;
            player2SquareState = GridSquareState.cross;
        }

        if (player1SquareState == GridSquareState.cross)
        {
            player1CharacterImage.sprite = blueCrossImage;
            player2CharacterImage.sprite = yellowCircleImage;
        }
        else
        {
            player1CharacterImage.sprite = yellowCircleImage;
            player2CharacterImage.sprite = blueCrossImage;
        }

        matchWinnerUI.SetActive(false);
        winLinesManager.SetWinLine(WinLinesManager.WinLine.none);
        CurrentPlayerTurnUI();
        input = true;
    }

    private void TurnAction(Turn turn, int actionSquare)
    {
        input = false;
        GridSquareState state = GridSquareState.empty;
        if(turn == Turn.Player1)
            state = player1SquareState;
        else
            state = player2SquareState;

        gridManager.selectedSquare(state, actionSquare);

        bool gameEnded = CheckEndGame();
        if (!gameEnded)
        {
            ChangeTurn();
            input = true;
        }
        else
        {
            matchWinnerUI.SetActive(true);
        }
    }

    private bool CheckEndGame()
    {
        bool fullGrid = gridManager.CheckFullGrid();
        GridSquareState winner = CheckGameWin();
        

        if(winner != GridSquareState.empty)
        {
            if(winner == player1SquareState)
            {
                player1MoveCounter++;
                player1MoveCounterText.text = player1MoveCounter.ToString();
                currentGameState = GameState.player1Win;
                matchWinnerText.text = "WINNER P1";
                isRunningTime = false;
                gameOverUI.SetActive(true);
                winSound.Play();
                return true;
            }
            else
            {
                player2MoveCounter++;
                player2MoveCounterText.text = player2MoveCounter.ToString();
                currentGameState = GameState.player2Win;
                matchWinnerText.text = "WINNER P2";
                isRunningTime = false;
                gameOverUI.SetActive(true);
                winSound.Play();
                return true;
            }
        }
        else
        {
            if (fullGrid)
            {
                if (currentTurn == Turn.Player1)
                {
                    player1MoveCounter++;
                    player1MoveCounterText.text = player1MoveCounter.ToString();
                }
                else
                {
                    player2MoveCounter++;
                    player2MoveCounterText.text = player2MoveCounter.ToString();
                }
                matchWinnerText.text = "DRAW";
                currentGameState = GameState.draw;
                isRunningTime = false;
                gameOverUI.SetActive(true);
                drawSound.Play();
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }

    private GridSquareState CheckGameWin()
    {
        GridSquareState winner = GridSquareState.empty;

        winner = gridManager.CheckGameWin(0, 1, 2);
        if(winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.horizontalTop);
            return winner;
        }
        winner = gridManager.CheckGameWin(3, 4, 5);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.horizontalMiddle);
            return winner;
        }
        winner = gridManager.CheckGameWin(6, 7, 8);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.horizontalBottom);
            return winner;
        }


        winner = gridManager.CheckGameWin(0, 3, 6);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.verticalLeft);
            return winner;
        }
        winner = gridManager.CheckGameWin(1, 4, 7);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.verticalMiddle);
            return winner;
        }
        winner = gridManager.CheckGameWin(2, 5, 8);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.verticalRight);
            return winner;
        }




        winner = gridManager.CheckGameWin(0, 4, 8);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.diagonalLeft);
            return winner;
        }
        winner = gridManager.CheckGameWin(2, 4, 6);
        if (winner != GridSquareState.empty)
        {
            winLinesManager.SetWinLine(WinLinesManager.WinLine.diagonalRight);
            return winner;
        }

        return winner;
    }

    public void ChangeTurn()
    {
        if(currentTurn == Turn.Player1)
            currentTurn = Turn.Player2;
        else
            currentTurn = Turn.Player1;
        CurrentPlayerTurnUI();
    }

    private void CurrentPlayerTurnUI()
    {
        if(currentTurn == Turn.Player1)
        {
            player2MoveCounter++;
            player2MoveCounterText.text = player2MoveCounter.ToString();
            Player1TurnText.enabled = true;
            Player2TurnText.enabled = false;
        }
        else
        {
            player1MoveCounter++;
            player1MoveCounterText.text = player1MoveCounter.ToString();
            Player1TurnText.enabled = false;
            Player2TurnText.enabled = true;
        }

    }



    public void squareClick(int clickedSquare)
    {
        if (!input)
            return;

        if (gridManager.getOneSquareState(clickedSquare) == GridSquareState.empty)
            TurnAction(currentTurn, clickedSquare);
        else
            return;

    }

    private void CurrentMatchTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        currentMatchTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        totalMatchTimeTxt.text = currentMatchTimeText.text;
    }
    private void ResetMatchTime()
    {
        elapsedTime = 0f;
        isRunningTime = true;
    }


    public enum Turn { Player1, Player2 };
    public enum GameState { draw, player1Win, player2Win, ongoing};


}
