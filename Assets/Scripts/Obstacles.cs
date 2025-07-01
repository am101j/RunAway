using UnityEngine;
public class ObstacleMover : MonoBehaviour
{
    public float speed = 15f;
    public float destroyZ = -20f;

    private bool counted = false;  // prevents duplicate scoring

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < destroyZ && !counted)
        {
            counted = true;

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.ObstacleExited(); 
            }

            Destroy(gameObject);
        }
    }
}
