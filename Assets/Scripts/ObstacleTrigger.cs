using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool scored = false;


    private void Start()
    {
        // Find the ScoreManager in the scene when this obstacle spawns
        scoreManager = FindFirstObjectByType<ScoreManager>();


        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!scored && other.CompareTag("Player"))
        {
            scored = true;
            scoreManager.IncreaseScore();

            AudioSource triggerAudio = other.GetComponent<AudioSource>();
            if (triggerAudio != null && triggerAudio.clip != null)
            {
                triggerAudio.Play();
            }
        }
    }
}
