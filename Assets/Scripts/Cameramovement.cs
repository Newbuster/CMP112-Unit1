using UnityEngine;

public class Cameramovement: MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Makes Cam move with player
        transform.position = Player.transform.position + offset;
    }
}