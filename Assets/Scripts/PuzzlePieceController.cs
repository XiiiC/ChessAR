using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceController : MonoBehaviour
{
    public GameObject[] pieceChoices;
    public GameObject pieceSquare;

    public bool selected = false;
    void Update()
    {
        if(selected)
        {
            pieceSquare.SetActive(true);
            foreach(GameObject piece in pieceChoices)
            {
                piece.SetActive(true);
            }
        }
        else if(!selected)
        {
            pieceSquare.SetActive(false);
            foreach(GameObject piece in pieceChoices)
            {
                piece.SetActive(false);
            }
        }
    }

    
}
