using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public int RandomRange(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue + 1);
    }
}
