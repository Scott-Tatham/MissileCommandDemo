using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBlast : MonoBehaviour
{
    [SerializeField]
    LayerMask missileLayer;
    [SerializeField]
    LayerMask cityLayer;

    bool isInBlast;
    CircleCollider2D circleCollider;
    MissileData missileData;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        missileData = GetComponent<MissileData>();
    }

    void Update()
    {
        Blasting();
    }

    public void Blast()
    {
        if (!isInBlast)
        {
            isInBlast = true;
            missileData.SetMoveSpeed(0);
        }
    }

    public void Blasting()
    {
        if (isInBlast)
        {
            if (transform.localScale.x < missileData.GetBlastRadius())
            {
                missileData.IncrementBlastProgress(missileData.GetBlastSpeed() * Time.deltaTime);
                transform.localScale = Vector2.one * Mathf.MoveTowards(missileData.GetInitialColliderSize(), missileData.GetBlastRadius(), missileData.GetBlastProgress());
            }

            else
            {
                isInBlast = false;
                missileData.SetIsFired(false);
                missileData.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & missileLayer.value) != 0)
        {
            if (missileData.GetIsPlayerOwned() != collision.gameObject.GetComponent<MissileData>().GetIsPlayerOwned())
            {
                Blast();
            }
        
            collision.gameObject.GetComponent<MissileBlast>().Blast();
        }
        
        else if(((1 << collision.gameObject.layer) & cityLayer.value) != 0)
        {
            if (!missileData.GetIsPlayerOwned())
            {
                Blast();
        
                collision.gameObject.GetComponent<City>().Destroy();
            }
        }
    }
}