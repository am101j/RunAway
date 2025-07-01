using UnityEngine;

public class FunFacts : MonoBehaviour
{
    [TextArea(2, 4)]
    public string[] facts;

    public string GetRandomFact()
    {
        int index = Random.Range(0, facts.Length);
        return facts[index];
    }
}