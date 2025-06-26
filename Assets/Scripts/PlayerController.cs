using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int lane = 1; // 0 = left, 1 = middle, 2 = right
    private float laneDistance = 2.0f; // distance between lanes
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 0)
        {
            lane--;
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 2)
        {
            lane++;
            UpdateTargetPosition();
        }

        // Smoothly move player towards target lane position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3((lane - 1) * laneDistance, transform.position.y, transform.position.z);
    }
}
