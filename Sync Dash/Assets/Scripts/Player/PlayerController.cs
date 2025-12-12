using UnityEngine;

namespace SyncDash.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float forwardSpeed = 5f;
        [SerializeField] private float jumpForce = 7f;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundRadius = 0.3f;
        [SerializeField] private LayerMask groundLayer;

        [Header("Extra Gravity")]
        [SerializeField] private float extraGravity = 20f;

        private Rigidbody rb;
        private bool isGrounded;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Detect jump input (PC + Mobile)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            MoveForward();
            CheckGround();
            ApplyExtraGravity();
        }

        private void MoveForward()
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, forwardSpeed);
        }

        private void Jump()
        {
            if (!isGrounded) return;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void CheckGround()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);
        }

        private void ApplyExtraGravity()
        {
            if (!isGrounded)
            {
                rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
            }
        }
    }
}
