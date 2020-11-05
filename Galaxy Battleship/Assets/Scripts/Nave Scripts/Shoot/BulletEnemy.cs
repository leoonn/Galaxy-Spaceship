using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletEnemy : MonoBehaviour
{
    public GameObject Bullet;

    public int speedBullet;

    //Rigidbody2D BulletRb;
    public float lifeBullet = 10f;

    private Transform player;
    private Vector3 target;
    Rigidbody BulletRb;
    private void Awake()
    {



        BulletRb = GetComponent<Rigidbody>(); //get component Rigidbody
        /*if (Bullet)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
        if (BulletFliped)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
       */
    }
    void Start()
    {
       if( GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector3(player.position.x, player.position.y, player.position.z);
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        GetTheLastPosiPlayer();
    }

    void GetTheLastPosiPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speedBullet * Time.deltaTime);
        transform.LookAt(target);
        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Destroy(gameObject);
        }
    }

}

    



