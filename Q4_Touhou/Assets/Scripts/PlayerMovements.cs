using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 5f;

    public List<string> bulletTags = new List<string>();
    public CameraShake cameraShake;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    Vector2 movementInput;
    Vector2 smoothedMovementInput;
    Vector2 movementInputSmoothVelocity;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletTags.Contains(collision.gameObject.tag))
        {
            BulletManager.instance.DestroyBullet(collision.gameObject);
            GameManager.instance.TakeBullet();
            audioSource.Play();
            StartCoroutine(cameraShake.Shake(0.12f, 0.08f));
        }
    }

}
