using UnityEngine;
using System.Collections;

public class Hitboxscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        print("hitbox exists!");
        StartCoroutine(Deletion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Deletion()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


}
