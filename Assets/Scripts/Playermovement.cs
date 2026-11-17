
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Playermovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    public float maxspeed = 10;
    public float drag = 0.1f;
    private int Jumpcd = 0;
    private int Dashcd = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

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

        //Default drag for when player isnt moving
        if (rb.linearVelocity.magnitude > 0.0f)
        {
            if (Input.anyKey == false)
            {
                rb.AddForce(-rb.linearVelocity * 50);
            }
        }


        //Sets player's rotation to direction of movement only when player is moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) == true)
        {
          
            Vector3 rotation = new Vector3(0, angle, 0);
            transform.eulerAngles = rotation;
        }

        if (Jumpcd > 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
            {
                Jumpcd--;
            }
        }
        if (Dashcd > 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.25f))
            {
                Dashcd--;
            }
        }

        //jumping lalala
        if (Input.GetKey(KeyCode.Space)) 
        {
        
            if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
            {
                if (Jumpcd == 0)
                {
                   
                    rb.AddForce (new Vector3(0, 80, 0), ForceMode.Impulse);
                     Jumpcd = 25;
                 
                }
                
            }
        }

        //dashing lalala
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Physics.Raycast(transform.position, Vector3.down, 0.25f))
            {
                print("grounddashing");
                if (Dashcd == 0)
                {

                    rb.AddForce(transform.forward * 40, ForceMode.Impulse);
                    Dashcd = 25;

                } 

            }

            
        }


    }

}

