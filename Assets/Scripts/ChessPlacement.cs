using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ChessPlacement : MonoBehaviour
{
    private enum state { 
        Board,
        Pieces,
        Puzzles
    };

    public enum lesson{
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    };

    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit> ();
    public Camera arCamera;
    public GameObject boardPrefab;
    public GameObject piecesPrefab;
    private Vector2 touchPos = default;
    private ARRaycastManager arRaycastManager;

    public LayerMask arObjLayer;

    private state gameState;
    public lesson lessonState;

    [SerializeField] private Button boardBtn;
    [SerializeField] private Button piecesBtn;
    [SerializeField] private Button puzzleBtn;
    [SerializeField] private Button removeBtn;

    [SerializeField] private Button pawnBtn;
    [SerializeField] private Button rookBtn;
    [SerializeField] private Button knightBtn;
    [SerializeField] private Button bishopBtn;
    [SerializeField] private Button queenBtn;
    [SerializeField] private Button kingBtn;

    GameObject[] texts;

    GameObject[] boards;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        ChangeMode("Board");
        boardBtn.onClick.AddListener(() => ChangeMode("Board"));
        piecesBtn.onClick.AddListener(() => ChangeMode("Pieces"));
        removeBtn.onClick.AddListener(() => RemoveBoard());

        ChangeLesson("Pawn");
        pawnBtn.onClick.AddListener(() => ChangeLesson("Pawn"));
        rookBtn.onClick.AddListener(() => ChangeLesson("Rook"));
        knightBtn.onClick.AddListener(() => ChangeLesson("Knight"));
        bishopBtn.onClick.AddListener(() => ChangeLesson("Bishop"));
        queenBtn.onClick.AddListener(() => ChangeLesson("Queen"));
        kingBtn.onClick.AddListener(() => ChangeLesson("King"));
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var touchedPos = touch.position;
                bool isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(touchPos);
                RaycastHit hit;
                        
                if (gameState == state.Board)
                {
                    if (Physics.Raycast(ray, out hit, 100, arObjLayer) && (hit.collider.transform.tag == "board"))
                    {
                        Debug.Log(" raycast");

                        Destroy(hit.transform.gameObject);
                        
                    }
                    else if (!isOverUI && arRaycastManager.Raycast(touchPos, arRaycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                    {
                        Debug.Log(" arraycast");
                        var hitPose = arRaycastHits[0].pose;
                        Instantiate(boardPrefab, hitPose.position, hitPose.rotation);
                    }
                }
                if(gameState == state.Pieces)
                {
                    if (Physics.Raycast(ray, out hit, 100, arObjLayer) && (hit.collider.transform.tag == "lessonBoard"))
                    {
                        Debug.Log(" raycast");
                           
                        Destroy(hit.transform.gameObject);
                    }
                    else if (!isOverUI && arRaycastManager.Raycast(touchPos, arRaycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                    {
                        Debug.Log(" arraycast");
                        var hitPose = arRaycastHits[0].pose;
                        Instantiate(piecesPrefab, hitPose.position, hitPose.rotation);
                    }
                }
                
            }
        }
    }
    void ChangeMode(string mode)
    {
        Color boardCol = boardBtn.image.color;
        
        Color piecesCol = piecesBtn.image.color;

        switch (mode)
        {
            case "Board":
                boardCol.a = 1f;
                piecesCol.a = 0.5f;
                gameState = state.Board;
                break;
            case "Pieces":
                boardCol.a = 0.5f;
                piecesCol.a = 1f;
                gameState = state.Pieces;
                break;
        }
        boardBtn.image.color = boardCol;
        piecesBtn.image.color = piecesCol;
    }

    

    void ChangeLesson(string mode)
    {
        Color pawnCol = pawnBtn.image.color;
        Color rookCol = rookBtn.image.color;
        Color knightCol = knightBtn.image.color;
        Color bishopCol = bishopBtn.image.color;
        Color queenCol = queenBtn.image.color;
        Color kingCol = kingBtn.image.color;
        

        GameObject[] pieces = piecesPrefab.GetComponent<LessonPieces>().pieces;

        switch (mode)
        {
            case "Pawn":
                pawnCol.a = 1f;
                rookCol.a = 0.5f;
                knightCol.a = 0.5f;
                bishopCol.a = 0.5f;
                queenCol.a = 0.5f;
                kingCol.a = 0.5f;
                lessonState = lesson.Pawn;
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
                lessonState = lesson.Rook;
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
                lessonState = lesson.Knight;
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
                lessonState = lesson.Bishop;
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
                lessonState = lesson.Queen;
                pieces[0].SetActive(false);
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
                lessonState = lesson.King;
                pieces[0].SetActive(false);
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

    void RemoveBoard()
    {
        boards = GameObject.FindGameObjectsWithTag("board");
        if(boards.Length > 0)
            foreach (var board in boards)
                Destroy(board.gameObject);
        

        boards = GameObject.FindGameObjectsWithTag("lessonBoard");
        if(boards.Length > 0)
            foreach (var board in boards)
                Destroy(board.gameObject);

        boards = GameObject.FindGameObjectsWithTag("puzzleBoard");
        if(boards.Length > 0)
            foreach (var board in boards)
                Destroy(board.gameObject);
    }


}
