using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridSquareManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image oImage;
    [SerializeField] private Image xImage;
    [SerializeField] private int squareID;
    [SerializeField] private AudioSource xoPlacementSound;
    private GridSquareState currentState = GridSquareState.empty;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.squareClick(squareID);
        xoPlacementSound.Play();
    }

    public GridSquareState getSquareState()
    {
        return currentState;
    }

    public void SetSquare(GridSquareState newState)
    {
        if(newState == GridSquareState.empty)
        {
            oImage.enabled = false;
            xImage.enabled = false;
        }else if(newState == GridSquareState.cross)
        {
            oImage.enabled = false;
            xImage.enabled = true;
        }
        else
        {
            oImage.enabled = true;
            xImage.enabled = false;
        }

        currentState = newState;
    }

}

public enum GridSquareState{
    empty, cross, circle
};
