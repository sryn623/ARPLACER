using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(t0.position, t1.position);
                initialScale = transform.localScale;
            }
            else if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(t0.position, t1.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}
