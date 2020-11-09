using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   [Header("Atributtes")]
    public float speedEnemy;
    public int lifeEnemy;
    public float timeShot;
    float waitShot;


    [Header("References game")]
    public GameObject explosion;
    private Transform playerTransform;
    public GameObject []guns;
    public GameObject bulletPrefab;
    

    [Header("References scripts")]
    move PlayerScript;
    Pontuation pointsScript;
    SpawnDuplicate spawnDuplicateScript;

    [Header("References Enums")]
    public typeEnemy type;

    [SerializeField]
    private typeEnemy TypeRead;
    
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<move>();
        }
        
        pointsScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Pontuation>();

        TypeRead = type;

        if (gameObject.tag == "EnemyDuplicate")
        {
            spawnDuplicateScript = gameObject.GetComponent<SpawnDuplicate>();
        }

        waitShot = timeShot;

        
    }

    // Update is called once per frame
    void Update()
    {
        TypeEnemies();
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

    void TypeEnemies()
    {
        switch (type)
        {
            case typeEnemy.chase:

                if (playerTransform != null)
                {
                    FollowPlayer(playerTransform.position);
                    RotatePlayer(playerTransform.position);
                }
                
                break;
            case typeEnemy.shooter:
                if (waitShot <= 0)
                {

                    for (int i = 0; i < guns.Length; i++)
                    {
                        Instantiate(bulletPrefab, guns[i].transform.position, guns[i].transform.rotation);
                    }
                    waitShot = timeShot;
                }
                else
                {
                    waitShot -= Time.deltaTime;
                }

                break;
            case typeEnemy.dead:

                Destroy(gameObject); //destroy asteroid


                if (gameObject.tag == "EnemyDuplicate")
                {
                    spawnDuplicateScript.InstantiateMinis();
                    pointsScript.points = pointsScript.points + pointsScript.duplicatepoints;
                    pointsScript.textscore.text = pointsScript.points.ToString();

                }

                else if (TypeRead == typeEnemy.chase)
                {
                    pointsScript.points = pointsScript.points + pointsScript.ChasePoints;
                    pointsScript.textscore.text = pointsScript.points.ToString();
                }

                else if (TypeRead == typeEnemy.shooter)
                {
                    pointsScript.points = pointsScript.points + pointsScript.shooterPoints;
                    pointsScript.textscore.text = pointsScript.points.ToString();
                }
                    break;
        }

    }

}