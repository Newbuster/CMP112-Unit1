using UnityEngine;
using UnityEngine.Assemblies;
using static UnityEngine.Mathf;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject player;
    public float speed;
    public float maxSpeed;
    public float drag;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get current position of enemy and player
        Vector3 currentPos = rb.transform.position;
        Vector3 playerPos = player.transform.position;

        //Calculate distance to player
        float x = playerPos.x - currentPos.x;
        float y = playerPos.y - currentPos.y;
        float z = playerPos.z - currentPos.z;

        //Create and apply movement vector
        Vector3 moveVector = new Vector3(x, y, z);
        rb.AddForce(moveVector.normalized * speed);

        //Apply drag if  moving faster than maxSpeed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.AddForce(-rb.linearVelocity * rb.linearVelocity.magnitude * drag);
        }
    }
}
