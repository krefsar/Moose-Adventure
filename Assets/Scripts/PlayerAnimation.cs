using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement moveController;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        moveController = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float currentMoveSpeed = moveController.CurrentHorizontalSpeed;
        animator.SetFloat("Speed", Mathf.Abs(currentMoveSpeed));

        if (currentMoveSpeed != 0)
        {
            sprite.flipX = currentMoveSpeed < 0;
        }
    }
}
