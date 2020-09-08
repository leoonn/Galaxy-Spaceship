using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    //Variables
    public Transform[] positionsArray; //Positions where asteroids will be instantiate
    public GameObject[] PrefabsAsteroids; //options asteroids
    public GameObject[] PrefabsPowerUp;
    int spawnAtual; // get a prefab
    int spawnposition; //get a spawnposition
    [SerializeField]
    public float timespawn = 125f; //time to spawn
    [SerializeField]
    private float timespawnPowerUp; //time to spawn
    [HideInInspector]
    public pauseScript pause;

    float timeCount = 0; //count of time
    float timeCountpower = 0; //count of time
    void Start()
    {
        pause = gameObject.GetComponent<pauseScript>();
        
        
    }

    void FixedUpdate()
    {
        SpawnAsteroids(); //called the method spawn asteroids
        SpawnPowerUp();
        
    }
    public void SpawnAsteroids() //method for spawn thats asteroids
    {

        spawnAtual = Random.Range(0, PrefabsAsteroids.Length); //randomize a number to get a prefab
        spawnposition = Random.Range(0, positionsArray.Length); //randomize a number to get a position
         //time count + 1
        if (timeCount > timespawn) //if count time > time to spawn, do this !
        {
            GameObject spawnasteroid = Instantiate(PrefabsAsteroids[spawnAtual], positionsArray[spawnposition].transform.position, Quaternion.identity); //Instantatiate a random prefab and random position.
            SpawnTime(); //calling method reset time
            timespawn = Random.Range(100f, 150f);
            //Destroy(spawnasteroid, 1000f);
        }
        timeCount++;
    }

    public void SpawnPowerUp() //method for spawn thats asteroids
    {

        spawnAtual = Random.Range(0, PrefabsPowerUp.Length); //randomize a number to get a prefab
        spawnposition = Random.Range(0, positionsArray.Length); //randomize a number to get a position
       
        if (timeCountpower > timespawnPowerUp) //if count time > time to spawn, do this !
        {
            GameObject spawnasteroid = Instantiate(PrefabsPowerUp[spawnAtual], positionsArray[spawnposition].transform.position, Quaternion.identity); //Instantatiate a random prefab and random position.
            SpawnTimePower(); //calling method reset time
            timespawnPowerUp = Random.Range(1100f, 1500f);
            //Destroy(spawnasteroid, 1000f);
        }
        timeCountpower++;
    }
    public void SpawnTime() //method for reset time
    {
        timeCount = 0f; //reset the count time 
    }
    public void SpawnTimePower() //method for reset time
    {
        timeCountpower = 0f; //reset the count time 
    }

}