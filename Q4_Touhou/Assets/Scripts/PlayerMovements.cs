using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;

    Vector2 movementInput;
    Vector2 smoothedMovementInput;
    Vector2 movementInputSmoothVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotationInDirectionOfInput();
    }

    void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.01f);

        rb.velocity = smoothedMovementInput * speed;
    }

    void RotationInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
        }
    }

    //public void OnMove(InputAction.CallbackContext ctx)
    //{
    //    Vector2 ctxValue = ctx.ReadValue<Vector2>();

    //    //if (ctxValue.x <= -deadZone)
    //    //    moveVector.x = -speed;
    //    //if (ctxValue.x >= deadZone)
    //    //    moveVector.x = speed;
    //    //if (ctxValue.x > -deadZone && ctxValue.x < deadZone)
    //    //    moveVector.x = 0;

    //    //if (ctxValue.y <= -deadZone)
    //    //    moveVector.y = -speed;
    //    //if (ctxValue.y >= deadZone)
    //    //    moveVector.y = speed;
    //    //if (ctxValue.y > -deadZone && ctxValue.y < deadZone)
    //    //    moveVector.y = 0;
    //    moveVector = Vector2.SmoothDamp(smoothedMovementInput, ctxValue, ref movementInputSmoothVelocity, 0.1f);

    //    rb.velocity = moveVector * speed;

    //    if(moveVector != Vector2.zero)
    //    {
    //        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
    //        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    //        rb.MoveRotation(rotation);
    //    }
    //}

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
}
