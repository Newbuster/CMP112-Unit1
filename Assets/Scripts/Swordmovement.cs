using UnityEngine;
using System.Collections;

public class Swordmovement : MonoBehaviour
{
   
    public GameObject Player;
    private Vector3 offset;
    private Vector3 rota;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        offset = transform.position - Player.transform.position;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        //gets player's rotation and isolates the y rotation value
        rota = Player.transform.eulerAngles;
        Vector3 rotatarget = new Vector3(0, rota.y, 0) *1;

        //sets position and rotation to allign with player

        StartCoroutine(Lagbehind(rotatarget, Player.transform.position));


       
    }

    IEnumerator Lagbehind(Vector3 rotatarget, Vector3 plyrtransform)
    {
        //makes sword follow behind slower
        yield return new WaitForSeconds(0.1f);
        transform.position = plyrtransform + offset;
        transform.eulerAngles = rotatarget;

    }

}
