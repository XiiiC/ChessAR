using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;


public class LessonPlacement : MonoBehaviour
{
    private enum state
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    };

    private state lessonState;

    public GameObject[] pieces;

    [SerializeField] private Button pawnBtn;
    [SerializeField] private Button rookBtn;
    [SerializeField] private Button knightBtn;
    [SerializeField] private Button bishopBtn;
    [SerializeField] private Button queenBtn;
    [SerializeField] private Button kingBtn;


    private void Awake()
    {
        ChangeMode("Pawn");
        pawnBtn.onClick.AddListener(() => ChangeMode("Pawn"));
        rookBtn.onClick.AddListener(() => ChangeMode("Rook"));
        knightBtn.onClick.AddListener(() => ChangeMode("Knight"));
        bishopBtn.onClick.AddListener(() => ChangeMode("Bishop"));
        queenBtn.onClick.AddListener(() => ChangeMode("Queen"));
        kingBtn.onClick.AddListener(() => ChangeMode("King"));
    }

    void ChangeMode(string mode)
    {
        Color pawnCol = pawnBtn.image.color;
        Color rookCol = rookBtn.image.color;
        Color knightCol = knightBtn.image.color;
        Color bishopCol = bishopBtn.image.color;
        Color queenCol = queenBtn.image.color;
        Color kingCol = kingBtn.image.color;
        
        switch (mode)
        {
            case "Pawn":
                pawnCol.a = 1f;
                rookCol.a = 0.5f;
                knightCol.a = 0.5f;
                bishopCol.a = 0.5f;
                queenCol.a = 0.5f;
                kingCol.a = 0.5f;
                lessonState = state.Pawn;
                pieces[0].SetActive(true);
                pieces[1].SetActive(false);
                pieces[2].SetActive(false);
                pieces[3].SetActive(false);
                pieces[4].SetActive(false);
                pieces[5].SetActive(false);
                break;
            case "Rook":
                pawnCol.a = 0.5f;
                rookCol.a = 1f;
                knightCol.a = 0.5f;
                bishopCol.a = 0.5f;
                queenCol.a = 0.5f;
                kingCol.a = 0.5f;
                lessonState = state.Rook;
                pieces[0].SetActive(false);
                pieces[1].SetActive(true);
                pieces[2].SetActive(false);
                pieces[3].SetActive(false);
                pieces[4].SetActive(false);
                pieces[5].SetActive(false);
                break;
            case "Knight":
                pawnCol.a = 0.5f;
                rookCol.a = 0.5f;
                knightCol.a = 1f;
                bishopCol.a = 0.5f;
                queenCol.a = 0.5f;
                kingCol.a = 0.5f;
                lessonState = state.Knight;
                pieces[0].SetActive(false);
                pieces[1].SetActive(false);
                pieces[2].SetActive(true);
                pieces[3].SetActive(false);
                pieces[4].SetActive(false);
                pieces[5].SetActive(false);
                break;
            case "Bishop":
                pawnCol.a = 0.5f;
                rookCol.a = 0.5f;
                knightCol.a = 0.5f;
                bishopCol.a = 1f;
                queenCol.a = 0.5f;
                kingCol.a = 0.5f;
                lessonState = state.Bishop;
                pieces[0].SetActive(false);
                pieces[1].SetActive(false);
                pieces[2].SetActive(false);
                pieces[3].SetActive(true);
                pieces[4].SetActive(false);
                pieces[5].SetActive(false);
                break;
            case "Queen":
                pawnCol.a = 0.5f;
                rookCol.a = 0.5f;
                knightCol.a = 0.5f;
                bishopCol.a = 0.5f;
                queenCol.a = 1f;
                kingCol.a = 0.5f;
                lessonState = state.Queen;
                                pieces[0].SetActive(true);
                pieces[1].SetActive(false);
                pieces[2].SetActive(false);
                pieces[3].SetActive(false);
                pieces[4].SetActive(true);
                pieces[5].SetActive(false);
                break;
            case "King":
                pawnCol.a = 0.5f;
                rookCol.a = 0.5f;
                knightCol.a = 0.5f;
                bishopCol.a = 0.5f;
                queenCol.a = 0.5f;
                kingCol.a = 1f;
                lessonState = state.King;
                pieces[1].SetActive(false);
                pieces[2].SetActive(false);
                pieces[3].SetActive(false);
                pieces[4].SetActive(false);
                pieces[5].SetActive(true);
                break;
        }
        
        pawnBtn.image.color = pawnCol;
        rookBtn.image.color = rookCol;
        knightBtn.image.color = knightCol;
        bishopBtn.image.color = bishopCol;
        queenBtn.image.color = queenCol;
        kingBtn.image.color = kingCol;
    }
}

