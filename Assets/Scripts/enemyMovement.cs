using System.Collections;
using UnityEngine;
using UnityEngine.Assemblies;
using static UnityEngine.Mathf;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool dashing;

    public GameObject player;
    public float speed;
    public float maxSpeed;
    public float drag;
    public float dashDist;
    public float dashDelay;
    public float dashLength;
    public float dashMult;


    IEnumerator dash(Vector3 moveVector)
    {
        //Stop moving
        dashing = true;
        rb.linearVelocity = Vector3.zero;

        //Dash after a delay
        rb.AddForce(moveVector.normalized * speed * dashMult, ForceMode.Impulse);

        //Wait until dash finished
        yield return new WaitForSeconds(dashLength);
        dashing = false;
    }


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

        //Create movement vector
        Vector3 moveVector = new Vector3(x, y, z);

        //Ram the player if within range
        if (moveVector.magnitude <= dashDist && !dashing)
        {
            StartCoroutine(dash(moveVector));
        }
        else if (moveVector.magnitude > dashDist)
        {
            StopCoroutine(dash(moveVector));
            dashing = false;
        }

        //Move towards the player if not dashing
        if (!dashing)
        {
            rb.AddForce(moveVector.normalized * speed);
        }

        //Apply drag if moving faster than maxSpeed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.AddForce(-rb.linearVelocity * rb.linearVelocity.magnitude * drag);
        }

        //Hover above the ground
        if (Physics.Raycast(currentPos, Vector3.down, 1))
        {
            rb.AddForce(Vector3.up * (rb.mass * 9.8f + 4));
        }
    }
}
