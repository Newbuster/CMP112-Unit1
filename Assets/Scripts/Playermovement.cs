using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Playermovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    public float maxspeed = 10;
    public float drag = 0.1f;
    public float jumpHeight = 20;
    public float dashLength = 40;
    public int jumpCD = 0;
    public int dashCD = 0;
    private int jumpTimer;
    private int dashTimer;
    private bool jumpReady = true;
    private bool dashReady = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpTimer = jumpCD;
        dashTimer = dashCD;
    }


        // Update is called once per frame
        void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            rb.AddForce(new Vector3(0, -10, 0));

        }
        float movementx = Input.GetAxis("Horizontal");
        float movementy = Input.GetAxis("Vertical");
        float angle = Mathf.Atan2(movementx, movementy) * Mathf.Rad2Deg;

        rb.angularVelocity = Vector3.zero;
        //Takes player input and creates a vector force in that direction.
        Vector3 movevector = new Vector3(movementx, 0.0f, movementy);
        rb.AddForce(movevector * speed*2);
        rb.AddForce(new Vector3(0, -9, 0));

        //If player is faster than max speed, apply drag
        if (rb.linearVelocity.magnitude > maxspeed)
        {
            rb.AddForce(-rb.linearVelocity * rb.linearVelocity.magnitude * drag);
        }


        //Sets player's rotation to direction of movement only when player is moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) == true)
        {
          
            Vector3 rotation = new Vector3(0, angle, 0);
            transform.eulerAngles = rotation;
        }

        //Decrease jump and dash cooldowns
        if (!jumpReady && jumpTimer > 0)
        {
            print(jumpTimer);
            jumpTimer--;
        }
        else
        {
            jumpReady = true;
            jumpTimer = jumpCD;
        }

        if (!dashReady && dashTimer > 0)
        {
            print(dashTimer);
            dashTimer--;
        }
        else
        {
            dashReady = true;
            dashTimer = dashCD;
        }

        //jumping lalala
        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.25f) && jumpReady)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                jumpReady = false;
            }
        }

        //dashing lalala
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.25f) && dashReady)
            {
                rb.AddForce(transform.forward * dashLength, ForceMode.Impulse);
                dashReady = false;
            }
        }
    }
}
