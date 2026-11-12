using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class enemyCollide : MonoBehaviour
{
    private bool colliding = false;
    public float iframes;
    public float health;
    private float maxHealth;
    private Slider hpBar;

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
        else
        {
            print("Health: " + health + "   Max Health: " + maxHealth);
            hpBar.value = health / maxHealth;
        }

        colliding = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
        hpBar = transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
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
