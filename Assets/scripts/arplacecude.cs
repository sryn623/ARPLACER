using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject placementPrefab;

    private GameObject placedObject;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        if (raycastManager == null)
            raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (raycastManager == null) return;
        if (placedObject != null) return;   // ← blocks multiple placement

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            TryPlace(Input.mousePosition);
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            TryPlace(Input.GetTouch(0).position);
#endif
    }

    void TryPlace(Vector2 pos)
    {
        if (raycastManager.Raycast(pos, hits, TrackableType.PlaneWithinPolygon))
        {
            placedObject = Instantiate(
                placementPrefab,
                hits[0].pose.position,
                hits[0].pose.rotation
            );
        }
    }

    public GameObject GetPlacedObject()
    {
        return placedObject;
    }
}
