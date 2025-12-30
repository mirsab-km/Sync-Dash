using UnityEngine;
using System.Collections.Generic;
public class StateSyncManager : MonoBehaviour
{
    public static StateSyncManager Instance;
    public Rigidbody playerRb;
    public Rigidbody remoteRb;

    [SerializeField] private float delay = 0f; 
    [SerializeField] private float smoothing = 8f;
    private float timer = 0f;

    private Queue<PlayerState> buffer = new Queue<PlayerState>();
    private Vector3 offSet;

    // Orb event tracking
    private bool pendingOrbCollect = false;
    private int pendingOrbID = -1;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //calculate offset
        offSet = remoteRb.position - playerRb.position;
    }

    public void NotifyOrbCollected(int id)
    {
        pendingOrbCollect = true;
        pendingOrbID = id;
    }

    void Update()
    {
        //  Record player state
        PlayerState state = new PlayerState();
        state.position = playerRb.position;
        state.rotation = playerRb.rotation;
        state.velocity = playerRb.linearVelocity;
        state.isJumped = Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space);

        //  Add orb event if triggered this frame
        state.collected = pendingOrbCollect;
        state.orbID = pendingOrbID;

        //  Reset event
        pendingOrbCollect = false;
        pendingOrbID = -1;

        buffer.Enqueue(state);

        if (buffer.Count < 5)
            return;

        // Release state after delay
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0f;

            if (buffer.Count > 0)
            {
                PlayerState next = buffer.Dequeue();

                //  Apply movement
                Vector3 targetPos = next.position + offSet;
                remoteRb.MovePosition(Vector3.Lerp(remoteRb.position, targetPos, Time.deltaTime * smoothing));
                remoteRb.MoveRotation(Quaternion.Lerp(remoteRb.rotation, next.rotation, Time.deltaTime * smoothing));

                if (next.isJumped)
                {
                    remoteRb.linearVelocity = Vector3.Lerp(remoteRb.linearVelocity, next.velocity, Time.deltaTime * smoothing);

                }

                //Apply orb collection to ghost
                if (next.collected)
                {
                    GhostOrbManager.Instance.CollectOrb(next.orbID);
                }
            }
        }
    }
}
