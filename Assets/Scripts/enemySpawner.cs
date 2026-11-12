using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCap;
    public float spawnDelay;
    private bool spawn = true;

    public GameObject player;

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

            //Gets enemyMovement scripts from newly created enemy and stores the player
            enemyMovement moveScript = enemy.GetComponent("enemyMovement") as enemyMovement;
            moveScript.player = player;

            //Delays next spawn
            StartCoroutine(spawnWait());
        }
    }
}
