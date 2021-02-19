using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    MissileData missileData;
    MissileBlast missileBlast;

    void Start()
    {
        missileData = GetComponent<MissileData>();
        missileBlast = GetComponent<MissileBlast>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (new Vector2(transform.position.x, transform.position.y) == missileData.GetTargetPosition())
        {
            missileBlast.Blast();
        }

        else
        {
            missileData.IncrementTravelProgress(missileData.GetMoveSpeed() * Time.deltaTime);
            transform.position = Vector3.MoveTowards(missileData.GetInitialPosition(), missileData.GetTargetPosition(), missileData.GetTravelProgress());
        }    
    }
}