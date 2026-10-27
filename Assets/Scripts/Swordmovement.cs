using UnityEngine;

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
      

        rota = Player.transform.eulerAngles;
        Vector3 rotaoffset = new Vector3(rota.x, 0, 0)*1;




        transform.position = Player.transform.position+offset; //+ rotaoffset;
        transform.eulerAngles = rota;
    }
}
