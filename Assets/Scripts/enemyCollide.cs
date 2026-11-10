using System.Collections;
using UnityEngine;


public class enemyCollide : MonoBehaviour
{
    private bool colliding = false;
    public float iframes;
    public float health;

    IEnumerator dealDamage()
    {
        //Stops further collisions from causing damage 
        colliding = true;
        yield return new WaitForSeconds(iframes);

        //Deals damage
        health -= 1;
        
        //Kills enemy if health reaches 0
        if (health == 0)
        {
            print("Enemy Defeated");
            Destroy(gameObject);
        }

        colliding = false;
    }

    //Called upon collision with the sword during an attack
    void OnTriggerEnter(Collider other)
    {
        //Checks for repeat collisions
        if (!colliding)
        {
            StartCoroutine(dealDamage());
        }
    }
}
