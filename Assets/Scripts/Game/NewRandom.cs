using UnityEngine;

public class NewRandom : MonoBehaviour
{
    public int Roulette(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue + 1);
    }

    public float Roulette(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue + 1f);
    }
}
