using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationSpeed = 0.2f;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved)
            {
                float deltaX = t0.deltaPosition.x - t1.deltaPosition.x;
                transform.Rotate(0, -deltaX * rotationSpeed, 0);
            }
        }
    }
}
