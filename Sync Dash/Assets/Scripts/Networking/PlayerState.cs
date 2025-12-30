using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public bool collected;
    public int orbID;
}
