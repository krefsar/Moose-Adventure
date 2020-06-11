using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float CurrentHorizontalSpeed { get; private set; }

    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float horizontalMoveThreshold = 0.5f;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        CurrentHorizontalSpeed = horizontal;

        Vector2 moveDirection = new Vector2(horizontal, 0f).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
