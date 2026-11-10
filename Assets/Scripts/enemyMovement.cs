using System.Collections;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject player;

    public float speed;
    public float maxSpeed;
    public float drag;

    private bool dashing;
    public float dashDist;
    public float dashDelay;
    public float dashLength;
    public float dashMult;

    private bool colliding;
    public float knockbackMult;
    public float iframes;


    IEnumerator dash(Vector3 moveVector)
    {
        //Stop moving
        dashing = true;
        rb.linearVelocity = Vector3.zero;

        //Dash
        rb.AddForce(moveVector.normalized * speed * dashMult, ForceMode.Impulse);

        //Wait until dash finished
        yield return new WaitForSeconds(dashLength);
        dashing = false;
    }


    IEnumerator knockback()
    {
        //Stops any dashes in progress and any further movement
        colliding = true;
        StopCoroutine(dash(Vector3.zero));

        //Knocks enemy in the opposite direction
        rb.AddForce(rb.linearVelocity.normalized * speed * -knockbackMult, ForceMode.Impulse);

        //Resets and enables movement after knockback is over
        yield return new WaitForSeconds(iframes);
        rb.linearVelocity = Vector3.zero;
        colliding = false;
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

        //Move if not being knocked back
        if (!colliding)
        {
            //Ram the player if within range
            if (moveVector.magnitude <= dashDist && !dashing)
            {
                StartCoroutine(dash(moveVector));
            }
            //Cancel ram if player moves out of range
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

    //Called upon collision with the sword during an attack
    void OnTriggerEnter(Collider other)
    {
        //Checks for repeat collisions
        if (!colliding)
        {
            StartCoroutine(knockback());
        }
    }

}
