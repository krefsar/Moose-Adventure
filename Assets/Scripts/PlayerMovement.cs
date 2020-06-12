using System;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float CurrentHorizontalSpeed { get; private set; }

    private CharacterGrounding characterGrounding;
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float horizontalMoveThreshold = 0.5f;
    [SerializeField]
    private float jumpForce = 200f;

    private void Awake()
    {
        characterGrounding = GetComponent<CharacterGrounding>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        CurrentHorizontalSpeed = horizontal;

        Vector2 moveDirection = new Vector2(horizontal, 0f).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (characterGrounding.IsGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
