using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform[] waypoints;
    int posi;
    float waitMove;
    public float timeMove;
    public Moveenemy moveType;
    Enemy enemyScript;
    
    private void Start()
    {
        waitMove = timeMove;
        enemyScript = gameObject.GetComponent<Enemy>();

        RandomPoint();
    }

    void FixedUpdate()
    {
        Movement();
        if (Vector3.Distance(transform.position, waypoints[posi].position) < 0.01f) // check distance between point and enemy
        {
            if (waitMove <= 0)
            {
                RandomPoint();
                waitMove = timeMove; //restart count 
            }
            else
            {
                waitMove -= Time.deltaTime; //count time 
            }

        }

    }
    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[posi].transform.position, enemyScript.speedEnemy * Time.deltaTime);
    }

    void RandomPoint()
    {
        posi = Random.Range(0, waypoints.Length);
        Debug.Log(posi);
    }

}

