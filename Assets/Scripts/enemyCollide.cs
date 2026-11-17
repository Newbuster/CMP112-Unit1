using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class enemyCollide : MonoBehaviour
{
    public GameObject Counter;
    private bool colliding = false;
    public float iframes;
    public float health;
    public float maxHealth;
    private Slider hpBar;
 
    IEnumerator dealDamage(int dmgAmt)
    {
        print(dmgAmt);
        //Stops further collisions from causing damage 
        colliding = true;
        yield return new WaitForSeconds(iframes);

        //Deals damage
        health -= dmgAmt;
   

        //Kills enemy if health reaches 0 and increases killcount
        if (health <= 0)
        {
            print("Enemy Defeated");
            Destroy(gameObject);
            Counter.GetComponent<GameController>().killCount++;
        }
        else
        {
            print("Health: " + health + "   Max Health: " + maxHealth);
        
        }

        colliding = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
        hpBar = transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        hpBar.value = health / maxHealth;
    }

    //Called upon collision with the sword during an attack
    void OnTriggerEnter(Collider other)
    {
 
        //Checks for repeat collisions
        if (!colliding)
        {
            StartCoroutine(dealDamage(other.GetComponent<Hitboxscript>().Damage));
        }
    }
}
