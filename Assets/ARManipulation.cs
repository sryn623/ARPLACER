using UnityEngine;

public class ARManipulation : MonoBehaviour
{
    private SinglePlacement placement;
    private GameObject target;

    private float startDist;
    private Vector3 startScale;

    void Start()
    {
        placement = GetComponent<SinglePlacement>();
    }

    void Update()
    {
        target = placement.GetPlacedObject();
        if (target == null) return;

        // ROTATE — one finger or mouse drag
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)
            {
                target.transform.Rotate(0f, -t.deltaPosition.x * 0.25f, 0f, Space.World);
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            float dx = Input.GetAxis("Mouse X");
            target.transform.Rotate(0f, dx * 5f, 0f, Space.World);
        }
#endif

        // SCALE — two finger pinch
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                startDist = Vector2.Distance(t0.position, t1.position);
                startScale = target.transform.localScale;
            }
            else
            {
                float currDist = Vector2.Distance(t0.position, t1.position);
                float factor = currDist / startDist;
                target.transform.localScale = Vector3.ClampMagnitude(startScale * factor, 2f);
            }
        }
    }
}
