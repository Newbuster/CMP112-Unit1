using UnityEngine;
using UnityEngine.UI;

public class Enemyscript : MonoBehaviour
{
    public int MHP = 100;
    private int HP;
    private Slider hpbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = MHP;
        hpbar = transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
        if(gameObject.tag == "Enemy")
        {
            print("Im tagged!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = MHP/HP; 
    }

    public void damagehp(int dmg)
    {
        HP = HP - dmg;
        print("Damaged");
    }

    public int Gethp()
    {
        return HP;
    }
}
