using UnityEngine;

public class EndlessGroundTile : MonoBehaviour
{
    public float speed = 10f;
    public float tileLength = 200f;
    public int totalTiles = 3;

    void Update()
    {

        if (ScoreManager.isGameOver) {
            return;
        }
        
        // Move backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // If tile went behind z = -tileLength, recycle it
        if (transform.position.z <= -tileLength)
        {
            // Move it to the front by total tile space
            transform.position += new Vector3(0, 0, tileLength * totalTiles);
        }
    }
}
