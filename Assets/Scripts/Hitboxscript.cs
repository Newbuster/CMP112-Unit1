using UnityEngine;
using System.Collections;

public class Hitboxscript : MonoBehaviour
{
    private GameObject damager;



    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        damager.GetComponent<Damager>().SetTarget(other.gameObject);
    }

    public void setmommy(GameObject mom)
    {
        damager = mom;
    }



}
