using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float deadZone = 0.4f;

    private Rigidbody2D rb;

    Vector2 moveVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 ctxValue = ctx.ReadValue<Vector2>();

        if (ctxValue.x <= -deadZone)
            moveVector.x = -speed;
        if (ctxValue.x >= deadZone)
            moveVector.x = speed;
        if (ctxValue.x > -deadZone && ctxValue.x < deadZone)
            moveVector.x = 0;

        if (ctxValue.y <= -deadZone)
            moveVector.y = -speed;
        if (ctxValue.y >= deadZone)
            moveVector.y = speed;
        if (ctxValue.y > -deadZone && ctxValue.y < deadZone)
            moveVector.y = 0;

        rb.velocity = moveVector;
    }
}
