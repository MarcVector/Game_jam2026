using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float speed = 4f;
    public InputAction moveAction;

    Rigidbody2D rigidbody2d;
    float currentInput;

    SpriteRenderer sr;

    AudioSource audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        moveAction.Enable();
    }

    void Update()
    {
        currentInput = moveAction.ReadValue<float>();

        if (currentInput > 0.01f)
            sr.flipX = false;
        else if (currentInput < -0.01f)
            sr.flipX = true;

        if (currentInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

    void FixedUpdate()
    {
        rigidbody2d.linearVelocity = new Vector2(currentInput * speed, rigidbody2d.linearVelocity.y);
    }

    void Respawn()
    {
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
                    