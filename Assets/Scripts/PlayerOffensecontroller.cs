using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerOffensecontroller : MonoBehaviour
{
   
    public GameObject swrdATK;
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

            StartCoroutine(Attack());
            
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

    IEnumerator Attack()
    {
        for (int i = 0; i < 2; i++)
        {
            //swings twice

           //spawns a damager which will create hitboxes and things
            GameObject Damagerobject = Instantiate(swrdATK, transform.position + transform.forward, transform.rotation);
            Damagerobject.transform.parent = transform;
            Damagerobject.GetComponent<Damager>().Setdmg(12);
            Destroy(Damagerobject, 0.5f);

            yield return new WaitForSeconds(0.5f);
        }
     
        
    }
}
