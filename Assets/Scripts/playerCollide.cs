
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerCollide : MonoBehaviour
{
    public GameObject cube;
    private bool colliding = false;
    private float HP;
    public float MaxHP;
    public float iframes;
    private Slider hpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpBar = transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
        HP = MaxHP;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        hpBar.value = HP/MaxHP;
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyMovement>().dashing == true && colliding == false)
        {
            print("Im hit");
            StartCoroutine(Invincible());
            HP = HP - 10;
            print(HP);

            if (HP <= 0)
            {
                print("Player Defeated");
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
    }
    IEnumerator Invincible()
    {
        print("Im invincible");
        colliding = true;
        cube.GetComponent<MeshRenderer>().material.color = new Color(248, 245, 240, 0.1f);
        yield return new WaitForSeconds(iframes);
        cube.GetComponent<MeshRenderer>().material.color = new Color(248, 245, 240, 1f);
        colliding = false;
        print("Im not invincible");
    }
}
