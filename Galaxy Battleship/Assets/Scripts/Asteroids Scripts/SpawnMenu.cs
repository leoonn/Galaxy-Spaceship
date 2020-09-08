using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    public Transform[] positionsArray; //Positions where asteroids will be instantiate
    public GameObject[] PrefabsAsteroids; //options asteroids
    int spawnAtual; // get a prefab
    int spawnposition; //get a spawnposition
    [SerializeField]
    public float timespawn = 125f; //time to spawn
    float timeCount = 0; //count of time
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAsteroids();
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
    public void SpawnTime() //method for reset time
    {
        timeCount = 0f; //reset the count time 
    }
}
