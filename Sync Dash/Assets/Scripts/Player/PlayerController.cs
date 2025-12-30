using UnityEngine;

namespace SyncDash.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 7f;

        [Header("Ground Detection")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundRadius = 0.3f;
        [SerializeField] private LayerMask groundLayer;

        [Header("Gravity Settings")]
        [SerializeField] private float extraGravity = 20f;

        [Header("Movement Speed")]
        public float startSpeed = 3f;
        public float maxSpeed = 25f;
        public float speedIncreaseRate = 0.5f; // speed per second

        // Runtime variables
        private float currentSpeed;
        private Rigidbody rb;
        private bool isGrounded;
        private bool isDead = false;

        private void OnEnable()
        {
            GameEvents.onPlayerDied += StopPlayer;
        }

        private void OnDisable()
        {
            GameEvents.onPlayerDied -= StopPlayer;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            currentSpeed = startSpeed;
        }

        private void Update()
        {
            // Detect jump input
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            if (isDead) return;

            MoveForward();
            CheckGround();
            ApplyExtraGravity();
        }

        private void MoveForward()
        {
            // Increase speed over time
            currentSpeed += speedIncreaseRate * Time.fixedDeltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            //Forward
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, currentSpeed);
        }

        private void Jump()
        {
            if (!isGrounded) return;

            AudioManager.Instance.JumpSound();

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

        public void StopPlayer()
        {
            isDead = true;

            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true; // fully stop physics
        }

    }
}
