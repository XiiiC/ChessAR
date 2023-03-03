using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class KnightManager : MonoBehaviour
{
    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();
    public Camera arCamera;
    public GameObject knightPrefab;
    private Vector2 touchPosition = default;
    public ARRaycastManager arRaycastManager;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        var pose = arRaycastHits[0].pose;
                        CreateKnight(pose.position);
                        return;
                    }

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "knight")
                        {
                            DeleteKnight(hit.collider.gameObject);
                        }
                    }
                }
            }
        }

    }

    private void CreateKnight(Vector3 position)
    {
        Instantiate(knightPrefab, position, Quaternion.identity);
    }
    private void DeleteKnight(GameObject knightObject)
    {
        Handheld.Vibrate(); //optional
        Destroy(knightObject);
    }

}
