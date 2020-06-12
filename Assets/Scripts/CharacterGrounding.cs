using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    public event Action OnAirborne = delegate { };
    public event Action OnLand = delegate { };

    [SerializeField]
    private Transform[] positions;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float maxDistance;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    private void Update()
    {
        if (!IsGrounded)
        {
            OnAirborne();
        }

        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
            {
                break;
            }
        }

        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue &&
                groundedObjectLastPosition.Value != groundedObject.position)
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                Debug.LogFormat("moving position by {0}", delta);
                transform.position += delta;
            }

            groundedObjectLastPosition = groundedObject.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        Debug.DrawRay(foot.position, foot.forward * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            if (groundedObject != raycastHit.collider.transform)
            {
                groundedObject = raycastHit.collider.transform;
                groundedObjectLastPosition = groundedObject.position;

                if (!IsGrounded)
                {
                    OnLand();
                }

                IsGrounded = true;
                GroundedDirection = foot.forward;
            }
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
