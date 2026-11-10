using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerOffensecontroller : MonoBehaviour
{
   
    public GameObject swrdHB;
    private bool atkready;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atkready = true;
    }

    // Update is called once per frame
    void Update()
    {
        //attacks if cd is set and left mouse is clicked
        if (Input.GetMouseButtonDown(0) && atkready == true)
        {
            atkready = false;
            print("atkready is now false");

            StartCoroutine(CreateHB());
            
            StartCoroutine(Basicattackcd());
        }
    }
    IEnumerator Basicattackcd()
    {
        //cooldown control
        yield return new WaitForSeconds(0.5f);
        atkready = true;
        print("atkready is now true");
    }

    IEnumerator CreateHB()
    {
        for (int i = 0; i < 2; i++)
        {
            //swings twice
            yield return new WaitForSeconds(0.2f);
            for (int x = 0; x < 5; x++)
            {
                //spawns multiple hitboxes to smoothen reach. Needs parenting before working on actual functions
                yield return new WaitForSeconds(0.025f);
                GameObject Hitbox;
                Hitbox = Instantiate(swrdHB, transform.position + transform.forward, transform.rotation);
                print("created hitbox");
                swrdHB.transform.eulerAngles = transform.eulerAngles;
                swrdHB.transform.position = transform.position;
            }
        }
     
        
    }
}
