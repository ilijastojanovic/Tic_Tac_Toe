using UnityEngine;

public class WinLinesManager : MonoBehaviour
{
    [SerializeField] private GameObject verticalMiddleWin;
    [SerializeField] private GameObject verticalLeftWin;
    [SerializeField] private GameObject verticalRightWin;
    [SerializeField] private GameObject horizontalTopWin;
    [SerializeField] private GameObject horizontalMiddleWin;
    [SerializeField] private GameObject HorizontalBottomWin;
    [SerializeField] private GameObject diagonalLeftWin;
    [SerializeField] private GameObject diagonalRightWin;

    public void SetWinLine(WinLine winLine)
    {
        switch (winLine)
        {
            case WinLine.none:
                SetActiveWinLine(null);
                break;
            case WinLine.verticalMiddle:
                SetActiveWinLine(verticalMiddleWin);
                break;
            case WinLine.verticalLeft:
                SetActiveWinLine(verticalLeftWin);
                break;
            case WinLine.verticalRight:
                SetActiveWinLine(verticalRightWin);
                break;
            case WinLine.horizontalTop:
                SetActiveWinLine(horizontalTopWin);
                break;
            case WinLine.horizontalMiddle:
                SetActiveWinLine(horizontalMiddleWin);
                break;
            case WinLine.horizontalBottom:
                SetActiveWinLine(HorizontalBottomWin);
                break;
            case WinLine.diagonalLeft:
                SetActiveWinLine(diagonalLeftWin);
                break;
            case WinLine.diagonalRight:
                SetActiveWinLine(diagonalRightWin);
                break;
            default:
                break;
        }
    }

    public void SetActiveWinLine(GameObject activeWinLine)
    {
        verticalMiddleWin.SetActive(verticalMiddleWin == activeWinLine);
        verticalLeftWin.SetActive(verticalLeftWin == activeWinLine);
        verticalRightWin.SetActive(verticalRightWin == activeWinLine);
        horizontalTopWin.SetActive(horizontalTopWin == activeWinLine);
        horizontalMiddleWin.SetActive(horizontalMiddleWin == activeWinLine);
        HorizontalBottomWin.SetActive(HorizontalBottomWin == activeWinLine);
        diagonalLeftWin.SetActive(diagonalLeftWin == activeWinLine);
        diagonalRightWin.SetActive(diagonalRightWin == activeWinLine);
    }

    public enum WinLine { none, verticalMiddle, verticalLeft, verticalRight, horizontalTop, horizontalMiddle, horizontalBottom, diagonalLeft, diagonalRight}
}
