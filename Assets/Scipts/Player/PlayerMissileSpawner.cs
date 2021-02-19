using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileSpawner : MissileSpawner
{
    [SerializeField]
    float playerShootTimer;

    bool canShoot;
    PlayerInputs playerInputs;

    protected override void Initialise()
    {
        canShoot = true;
        playerInputs = GetComponent<PlayerInputs>();
        playerInputs.SubscribeToOnPrimaryTouch(FireMissile);
    }

    protected override bool IsPlayerOwned()
    {
        return true;
    }

    protected override bool CanShoot()
    {
        return canShoot;
    }

    protected override void Shooting()
    {
        canShoot = false;
        StartCoroutine(ShootTimer());
    }

    protected override Vector2 PositionAdjustments(Vector2 targetPosition)
    {
        return Camera.main.ScreenToWorldPoint(targetPosition);
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(playerShootTimer);
        canShoot = true;
    }
}