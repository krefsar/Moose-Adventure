using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CharacterGrounding))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement moveController;
    private Animator animator;
    private SpriteRenderer sprite;
    private CharacterGrounding characterGrounding;

    private void Awake()
    {
        moveController = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }

    private void Start()
    {
        characterGrounding.OnAirborne += HandleAirborne;
        characterGrounding.OnLand += HandleLand;
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

    private void HandleAirborne()
    {
        animator.SetTrigger("Airborne");
    }

    private void HandleLand()
    {
        animator.SetTrigger("Land");
    }
}
