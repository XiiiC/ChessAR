using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel;
    public ChessPlacement chessPlacement;
    public Button tutorialButton;

    public GameObject[] texts;

    
    void Awake()
    {
        tutorialButton.onClick.AddListener(() =>ToggleTutorial());
    }

    void FixedUpdate()
    {
        switch(chessPlacement.lessonState)
        {
            case ChessPlacement.lesson.Pawn:
                texts[0].SetActive(true);
                texts[1].SetActive(false);
                texts[2].SetActive(false);
                texts[3].SetActive(false);
                texts[4].SetActive(false);
                texts[5].SetActive(false);
                break;
            case ChessPlacement.lesson.Rook:
                texts[0].SetActive(false);
                texts[1].SetActive(true);
                texts[2].SetActive(false);
                texts[3].SetActive(false);
                texts[4].SetActive(false);
                texts[5].SetActive(false);
                break;
            case ChessPlacement.lesson.Knight:
                texts[0].SetActive(false);
                texts[1].SetActive(false);
                texts[2].SetActive(true);
                texts[3].SetActive(false);
                texts[4].SetActive(false);
                texts[5].SetActive(false);
                break;
            case ChessPlacement.lesson.Bishop:
                texts[0].SetActive(false);
                texts[1].SetActive(false);
                texts[2].SetActive(false);
                texts[3].SetActive(true);
                texts[4].SetActive(false);
                texts[5].SetActive(false);
                break;
            case ChessPlacement.lesson.Queen:
                texts[0].SetActive(false);
                texts[1].SetActive(false);
                texts[2].SetActive(false);
                texts[3].SetActive(false);
                texts[4].SetActive(true);
                texts[5].SetActive(false);
                break;
            case ChessPlacement.lesson.King:
                texts[0].SetActive(false);
                texts[1].SetActive(false);
                texts[2].SetActive(false);
                texts[3].SetActive(false);
                texts[4].SetActive(false);
                texts[5].SetActive(true);
                break;

        }
    }
    void ToggleTutorial()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
    }
}
