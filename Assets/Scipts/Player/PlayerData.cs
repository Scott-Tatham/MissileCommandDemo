using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int score, cities;

    public int GetScore() { return score; }

    public int IncementScore(int increment) { return score += increment; }
    public void DecreaseCities()
    {
        cities--;

        if (cities == 0)
        {
            // GameOver.
        }
    }
}