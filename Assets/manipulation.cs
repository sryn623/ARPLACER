using UnityEngine;

public class ARRotateScale : MonoBehaviour
{
    private ARPlaceCube placer;
    private GameObject target;

    private float startDistance;
    private Vector3 startScale;

    void Start()
    {
        placer = GetComponent<ARPlaceCube>();
    }

    void Update()
    {
        target = placer.GetPlacedObject();
        if (target == null) return;

        // ROTATE (1 finger / mouse drag)
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)
            {
                target.transform.Rotate(0f, -t.deltaPosition.x * 0.3f, 0f, Space.World);
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            target.transform.Rotate(0f, Input.GetAxis("Mouse X") * 5f, 0f, Space.World);
        }
#endif

        // SCALE (pinch)
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                startDistance = Vector2.Distance(t0.position, t1.position);
                startScale = target.transform.localScale;
            }
            else
            {
                float currentDistance = Vector2.Distance(t0.position, t1.position);
                float factor = currentDistance / startDistance;
                target.transform.localScale = startScale * factor;
            }
        }
    }
}
