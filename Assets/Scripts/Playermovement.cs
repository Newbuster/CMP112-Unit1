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
    private int Jumpcd = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }


        // Update is called once per frame
        void FixedUpdate()
    {
        float movementx = Input.GetAxis("Horizontal");
        float movementy = Input.GetAxis("Vertical");
        float angle = Mathf.Atan2(movementx, movementy) * Mathf.Rad2Deg;
      

        //Takes player input and creates a vector force in that direction.
        Vector3 movevector = new Vector3(movementx, 0.0f, movementy);
        rb.AddForce(movevector * speed);
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
                rb.AddForce(-rb.linearVelocity * 5);
            }
        }

        //Sets player's rotation to direction of movement only when player is moving
        if (Input.anyKey == true)
        {
            rb.angularVelocity = Vector3.zero;
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
        

        if (Input.GetKey(KeyCode.Space)) 
        {
            print(Jumpcd);
            if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
            {
                if (Jumpcd == 0)
                {
                    print("Jumping");
                    rb.AddForce (new Vector3(0, 5, 0), ForceMode.Impulse);
                     Jumpcd = 25;
                    print("Jump cd is now: ");
                    print(Jumpcd);
                }
                
            }
        }
 

    }
}
