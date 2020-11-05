using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bulletRigid; // RigidBody bullet
    public int speed = 7;  //speed bullet
    public float lifebullet = 10f; // time of bullet in alive
    

    void Awake()
    {
        if (gameObject.tag == "BulletEnemy")
        {
            bulletRigid = GetComponent<Rigidbody>(); //get component Rigidbody
            bulletRigid.AddForce(-bulletRigid.transform.forward * speed); //addforce bullet
            Destroy(gameObject, lifebullet); //Destroy bullet in time life
        }
        else
        {
            bulletRigid = GetComponent<Rigidbody>(); //get component Rigidbody
            bulletRigid.AddForce(bulletRigid.transform.forward * speed); //addforce bullet
            Destroy(gameObject, lifebullet); //Destroy bullet in time life
        }
      

    }
    void Start()
    {
        
    }


    void Update()
    {

    }
    

}

