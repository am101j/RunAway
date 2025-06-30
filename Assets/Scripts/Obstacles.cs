using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 10f;
    public float destroyZ = -50f; 

    void Update()
    {
        // Move the obstacle backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy when far behind the player
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
