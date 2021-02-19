using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    Action<Vector2> OnPrimaryTouch;

    public void SubscribeToOnPrimaryTouch(Action<Vector2> OnPrimaryTouch) { this.OnPrimaryTouch += OnPrimaryTouch; }
    public void UnsubscribeToOnPrimaryTouch(Action<Vector2> OnPrimaryTouch) { this.OnPrimaryTouch -= OnPrimaryTouch; }

    void Update()
    {
        PrimaryTouch();
    }

    void PrimaryTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnPrimaryTouch(Input.GetTouch(0).position);
        }

        else if (Input.GetMouseButtonDown(0))
        {
            OnPrimaryTouch(Input.mousePosition);
        }
    }
}