using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Swordmovement : MonoBehaviour
{
   
    public GameObject Player;
    public GameObject hitbox;
    private Vector3 offset;
    private bool swinging;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - Player.transform.position;
        swinging = false;
        hitbox.SetActive(false);
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
        hitbox.SetActive(true);
        float swingtime = 0.25f;
        float timer = 0f;
        float cAngle;
  
        do
        {
            timer += Time.deltaTime;
            cAngle = (270*timer/swingtime);
            transform.rotation = Quaternion.Euler(Player.transform.eulerAngles.x, Player.transform.eulerAngles.y, 0) * Quaternion.Euler(cAngle/15, cAngle, 0);
          
            yield return null;
        } while (timer <= swingtime);

        swinging = false;
        hitbox.SetActive(false);
    }
}
