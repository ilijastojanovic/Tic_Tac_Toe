using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GridSquareManager[] grid;



    public void ResetGrid()
    {
        foreach (GridSquareManager square in grid)
        {
            square.SetSquare(GridSquareState.empty);
        }
    }
    public void selectedSquare(GridSquareState squareState, int square)
    {
        grid[square].SetSquare(squareState);
    }

    public GridSquareState getOneSquareState(int squareID)
    {
        return grid[squareID].getSquareState();
    }

    public bool CheckFullGrid()
    {
        foreach (GridSquareManager square in grid)
            if (square.getSquareState() == GridSquareState.empty)
                return false;
        return true;
    }

    public GridSquareState CheckGameWin(int square1, int square2, int square3)
    {
        GridSquareState state1 = grid[square1].getSquareState();
        GridSquareState state2 = grid[square2].getSquareState();
        GridSquareState state3 = grid[square3].getSquareState();

        if (state1 != GridSquareState.empty)
        {
            if(state1 == state2 && state1 == state3)
            {
                return state1;
            }
            else
            {
                return GridSquareState.empty;
            }
        }
        return GridSquareState.empty;
    }



}
