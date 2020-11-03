using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy;

    public GameObject explosion;
    private Transform playerTransform;

    move PlayerScript;
    Pontuation pointsScript;

    public typeEnemy type;
    public int lifeEnemy;
    typeEnemy TypeRead;
    SpawnDuplicate spawnDuplicateScript;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<move>();
        pointsScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Pontuation>();

        TypeRead = type;
        if (gameObject.tag == "EnemyDuplicate")
        {
            spawnDuplicateScript = gameObject.GetComponent<SpawnDuplicate>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case typeEnemy.chase:

                FollowPlayer(playerTransform.position);
                RotatePlayer(playerTransform.position);
                break;
            case typeEnemy.dead:
               
                Destroy(gameObject); //destroy asteroid

                pointsScript.points = pointsScript.points + pointsScript.ChasePoints;
                pointsScript.textscore.text = pointsScript.points.ToString();

                if(gameObject.tag == "EnemyDuplicate")
                {
                    spawnDuplicateScript.InstantiateMinis();
                }
                break;
        }
    }
    void FixedUpdate()
    {



    }
    void FollowPlayer(Vector3 player)
    {
        transform.position = Vector3.MoveTowards(transform.position, player, speedEnemy * Time.deltaTime);
    }
    void RotatePlayer(Vector3 player)
    {
        transform.LookAt(player * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet")) //check object colliding in tag player
        {
            GameObject explosionprefab = Instantiate(explosion, col.transform.position, transform.rotation); // instantieate a particle system
            Destroy(explosionprefab, 3f); //destroy particle

            Destroy(col.gameObject); //destroy bullet    
            lifeEnemy--;

            if (lifeEnemy <= 0)
            {
                lifeEnemy = 0;
                type = typeEnemy.dead;
            }

        }

        if (col.gameObject.CompareTag("Player"))
        {
            type = typeEnemy.dead;
            PlayerScript.PlayerDamage();

        }
    }

    void LifeEnemy()
    { 
        

    }
}