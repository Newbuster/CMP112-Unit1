using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Damager : MonoBehaviour
{
    private int dmg;
    private List<GameObject> target;
    public GameObject hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Damager exists!");
        StartCoroutine(CreateHB());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(GameObject enemy)
    {
        print(enemy.name);
        if (enemy.tag == "Enemy")
        {
            print("found an enemy");

            if (target.Contains(enemy) == false)
            {
                enemy.GetComponent<Enemyscript>().damagehp(dmg);
                target.Add(enemy);
            }
        }
   
    }


    public void Setdmg(int damage)
    {
        dmg = damage;
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
