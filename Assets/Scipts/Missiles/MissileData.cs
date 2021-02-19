using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileData : MonoBehaviour
{
    [SerializeField]
    int baseScoreValue;
    [SerializeField]
    float initialMoveSpeed, initialBlastRadius, initialBlastSpeed, initialColliderSize;

    bool isFired, isPlayerOwned;
    float currentMoveSpeed, currentBlastRadius, currentBlastSpeed, travelProgress, blastProgress;
    Vector2 initialPosition, targetPosition;

    public bool GetIsFired() { return isFired; }
    public bool GetIsPlayerOwned() { return isPlayerOwned; }
    public int GetBaseScoreValue() { return baseScoreValue; }
    public float GetMoveSpeed() { return currentMoveSpeed; }
    public float GetBlastRadius() { return currentBlastRadius; }
    public float GetBlastSpeed() { return currentBlastSpeed; }
    public float GetTravelProgress() { return travelProgress; }
    public float GetBlastProgress() { return blastProgress; }
    public float GetInitialColliderSize() { return initialColliderSize; }
    public Vector2 GetInitialPosition() { return initialPosition; }
    public Vector2 GetTargetPosition() { return targetPosition; }

    public void SetIsFired(bool isFired) { this.isFired = isFired; }
    public void SetIsPlayerOwned(bool isPlayerOwned) { this.isPlayerOwned = isPlayerOwned; }
    public void SetMoveSpeed(float currentMoveSpeed) { this.currentMoveSpeed = currentMoveSpeed; }
    public void ResetMoveSpeed() { currentMoveSpeed = initialMoveSpeed; }
    public void SetBlastRadius(float currentBlastRadius) { this.currentBlastRadius = currentBlastRadius; }
    public void SetBlastSpeed(float currentBlastSpeed) { this.currentBlastSpeed = currentBlastSpeed; }
    public void ResetBlastSpeed() { currentBlastSpeed = initialBlastSpeed; }
    public void IncrementTravelProgress(float increment) { this.travelProgress += increment; }
    public void ResetTravelProgress() { travelProgress = 0; }
    public void IncrementBlastProgress(float increment) { this.blastProgress += increment; }
    public void ResetBlastProgress() { blastProgress = 0; }
    public void ResetBlastRadius() { currentBlastRadius = initialBlastRadius; }
    public void SetInitialPosition(Vector2 initialPosition) { this.initialPosition = initialPosition; }
    public void SetTargetPosition(Vector2 targetPosition) { this.targetPosition = targetPosition; }

    void Start()
    {
        ResetMoveSpeed();
        ResetBlastRadius();
        ResetBlastSpeed();
    }
}