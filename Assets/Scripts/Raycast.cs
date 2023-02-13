using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Raycast : MonoBehaviour
{
    [SerializeField] private Transform feetPos;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    public bool IsGrounded { get; private set; }
    private CircleCollider2D collider;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }
}