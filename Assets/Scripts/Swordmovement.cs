using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Swordmovement : MonoBehaviour
{
   
    public GameObject Player;
    private Vector3 offset;
    private bool swinging;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        offset = transform.position - Player.transform.position;
        swinging = false;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
  
        //gets player's rotation and isolates the y rotation value
        if (swinging == false)
        {
            transform.rotation = Quaternion.Euler(0, Player.transform.eulerAngles.y, 0);
        }

        transform.position = Player.transform.position + offset;
    }

    public IEnumerator Swing()
    {
        
        swinging = true;
        float swingtime = 0.25f;
        float timer = 0f;
        float cAngle;
  

        print("swinging");
        do
        {
            timer += Time.deltaTime;
            cAngle = (270*timer/swingtime);
            transform.rotation = Quaternion.Euler(0, Player.transform.eulerAngles.y, 0) * Quaternion.Euler(0, cAngle, 0);
          
            yield return null;
        } while (timer <= swingtime);

        swinging = false;

    }


}
