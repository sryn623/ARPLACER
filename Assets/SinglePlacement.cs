using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SinglePlacement : MonoBehaviour
{
    public GameObject placementPrefab;

    private GameObject placedObject;
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool hasPlaced = false;   // 🔒 HARD LOCK

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();

        if (raycastManager == null)
        {
            Debug.LogError("ARRaycastManager NOT FOUND in scene");
            enabled = false;
        }
    }

    void Update()
    {
        if (hasPlaced) return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            TryPlace(Input.mousePosition);
        }
#else
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            TryPlace(touch.position);
        }
#endif
    }

    void TryPlace(Vector2 screenPos)
    {
        if (raycastManager.Raycast(screenPos, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            placedObject = Instantiate(placementPrefab, pose.position, pose.rotation);
            hasPlaced = true; // 🔒 LOCK FOREVER
        }
    }

    public GameObject GetPlacedObject()
    {
        return placedObject;
    }
}
