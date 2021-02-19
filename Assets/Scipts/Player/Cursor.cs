using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    Transform cursor;

    PlayerInputs playerInputs;

    void Start()
    {
        playerInputs = GetComponent<PlayerInputs>();
        playerInputs.SubscribeToOnPrimaryTouch(SetCursorPosition);
    }

    void SetCursorPosition(Vector2 cursorPosition)
    {
        Vector2 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        cursor.position = cursorWorldPosition;
    }
}