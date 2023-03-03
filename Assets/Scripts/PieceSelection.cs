using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;


public class PieceSelection : MonoBehaviour
{
    private GameObject puzzlePrefab;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Image debugImg;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();

    }

    void Update()
    {
        if (puzzlePrefab == null)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                bool isOverUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                Debug.Log(isOverUI);
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Debug.Log(" blocked raycast");
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && (hit.transform.tag == "piece"))
                {
                    debugImg.gameObject.SetActive(true);
                }
                else if (!isOverUI && arRaycastManager.Raycast(touchPosition, hits,
               UnityEngine.XR.ARSubsystems.TrackableType.Planes))
                {
                    Debug.Log(" arraycast");

                    var hitPose = hits[0].pose;
                    Instantiate(puzzlePrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }

}
