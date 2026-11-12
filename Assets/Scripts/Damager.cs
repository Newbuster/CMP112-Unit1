using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Damager : MonoBehaviour
{
    public GameObject hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreateHB());
    }

    IEnumerator CreateHB()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Hitbox = Instantiate(hitbox, transform.position, transform.rotation);
            Hitbox.GetComponent<Hitboxscript>().setmommy(gameObject);
            Destroy(Hitbox, 0.25f);

            yield return new WaitForSeconds(0.05f);
         
        }
    }
}
