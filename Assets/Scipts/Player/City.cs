using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;
    [SerializeField]
    EnemyMissileSpawner enemyMissileSpawner;

    public void Destroy()
    {
        playerData.DecreaseCities();
        enemyMissileSpawner.RemoveCity(this);
        Destroy(gameObject);
    }
}