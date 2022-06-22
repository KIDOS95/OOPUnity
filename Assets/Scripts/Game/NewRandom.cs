using UnityEngine;

public class NewRandom : MonoBehaviour
{
    public int Roulette(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue + 1);
    }
}
