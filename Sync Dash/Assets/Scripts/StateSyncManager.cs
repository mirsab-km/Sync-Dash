using UnityEngine;
using System.Collections.Generic;
public class StateSyncManager : MonoBehaviour
{
    public Rigidbody playerRb;
    public Rigidbody remoteRb;

    [SerializeField] private float delay = 0f; //200 ms delay
    [SerializeField] private float smoothing = 8f;
    private float timer = 0f;

    private Queue<PlayerState> buffer = new Queue<PlayerState>();
    private Vector3 offSet;

    private void Start()
    {
        //calculate offset
        offSet = remoteRb.position - playerRb.position;
    }

    void Update()
    {
        //record player state in every frame
        PlayerState state = new PlayerState();
        state.position = playerRb.position;
        state.rotation = playerRb.rotation;
        state.velocity = playerRb.linearVelocity;
        state.isJumped = Input.GetMouseButton(0);

        buffer.Enqueue(state);

        if (buffer.Count < 5)
            return;


        //release the state after delay
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0f;
            if (buffer.Count > 0)
            {
                PlayerState next = buffer.Dequeue();

                //Apply offset
                Vector3 targetPos = next.position + offSet;

                //Smooth positioning
                remoteRb.MovePosition(Vector3.Lerp(remoteRb.position, targetPos, Time.deltaTime * smoothing));

                //smooth rotation
                remoteRb.MoveRotation(Quaternion.Lerp(remoteRb.rotation, next.rotation, Time.deltaTime * smoothing));

                //Jump
                if (next.isJumped)
                {
                    remoteRb.linearVelocity = new Vector3(next.velocity.x, next.velocity.y, next.velocity.z);
                }
            }
        }
    }
}
