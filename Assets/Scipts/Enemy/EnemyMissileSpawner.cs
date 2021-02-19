using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileSpawner : MissileSpawner
{
    [SerializeField]
    float minWaitTime, maxWaitTime;
    [SerializeField]
    List<City> targets;

    bool canFire;

    public void RemoveCity(City city) { targets.Remove(city); }

    protected override void Initialise()
    {
        canFire = true;
    }

    void Update()
    {
        PrepareToFireMissile();
    }

    void PrepareToFireMissile()
    {
        if (canFire && targets.Count > 0)
        {
            StartCoroutine(RandomFire(Random.Range(minWaitTime, maxWaitTime), new Vector2(Random.Range(-7.5f, 7.5f), 5), targets[Random.Range(0, targets.Count)].transform.position));
        }
    }

    IEnumerator RandomFire(float waitTime, Vector2 firePosition, Vector2 target)
    {
        canFire = false;

        yield return new WaitForSeconds(waitTime);

        transform.position = firePosition;
        FireMissile(target);
        canFire = true;
    }
}