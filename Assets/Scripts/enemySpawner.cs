using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay;
    private bool spawn = true;

    public GameObject player;
    public GameObject camera;

    IEnumerator spawnWait()
    {
        //Disables spawning
        spawn = false;

        //Restarts spawning after a delay
        yield return new WaitForSeconds(spawnDelay);
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Checks if spawning is enabled
        if (spawn)
        {
            //Create new enemy at spawner location
            GameObject enemy;
            enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;

            //Gets enemyMovement script from newly created enemy and stores the player
            enemyMovement moveScript = enemy.GetComponent<enemyMovement>();
            moveScript.player = player;

            //Gets healthbarBillboard script from newly created enemy and stores the camera
            healthbarBillboard healthScript = enemy.GetComponentInChildren<healthbarBillboard>();
            healthScript.camera = camera;

            //Delays next spawn
            StartCoroutine(spawnWait());
        }
    }
}
