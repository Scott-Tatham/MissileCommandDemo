using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileSpawner : MonoBehaviour
{
    [SerializeField]
    int poolSize;
    [SerializeField]
    List<MissileData> missileTypes;

    List<MissileData>[] missilePools;

    void Start()
    {
        missilePools = new List<MissileData>[missileTypes.Count];

        for (int i = 0; i < missilePools.Length; i++)
        {
            missilePools[i] = new List<MissileData>();

            for (int j = 0; j < poolSize; j++)
            {
                MissileData missileData = Instantiate(missileTypes[i]);
                missileData.gameObject.SetActive(false);
                missileData.transform.position = transform.position;
                missileData.transform.localScale = Vector2.one * missileData.GetInitialColliderSize();
                missileData.SetIsPlayerOwned(IsPlayerOwned());
                missilePools[i].Add(missileData);
            }
        }

        Initialise();
    }

    protected abstract void Initialise();

    protected void FireMissile(Vector2 targetPosition)
    {
        if (CanShoot())
        {
            Shooting();
            targetPosition = PositionAdjustments(targetPosition);

            int missileType = GetMissileType();

            for (int i = 0; i < missilePools[missileType].Count; i++)
            {
                MissileData missileData = missilePools[missileType][i];

                if (!missileData.GetIsFired())
                {
                    missileData.gameObject.SetActive(true);
                    missileData.transform.position = transform.position;
                    missileData.transform.localScale = Vector2.one * missileData.GetInitialColliderSize();
                    missileData.SetIsFired(true);
                    missileData.ResetMoveSpeed();
                    missileData.ResetTravelProgress();
                    missileData.ResetBlastProgress();
                    missileData.SetInitialPosition(transform.position);
                    missileData.SetTargetPosition(targetPosition);

                    return;
                }
            }

            MissileData newMissileData = Instantiate(missileTypes[missileType]);
            newMissileData.transform.position = transform.position;
            newMissileData.transform.localScale = Vector2.one * newMissileData.GetInitialColliderSize();
            newMissileData.SetIsPlayerOwned(IsPlayerOwned());
            newMissileData.SetIsFired(true);
            newMissileData.SetInitialPosition(transform.position);
            newMissileData.SetTargetPosition(targetPosition);
            missilePools[missileType].Add(newMissileData);
        }
    }

    protected virtual bool CanShoot()
    {
        return true;
    }

    protected virtual void Shooting()
    {

    }

    protected virtual Vector2 PositionAdjustments(Vector2 targetPosition)
    {
        return targetPosition;
    }

    protected virtual int GetMissileType()
    {
        return 0;
    }

    protected virtual bool IsPlayerOwned()
    {
        return false;
    }
}