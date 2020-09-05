using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxmenu : MonoBehaviour
{
    // variables 
    public GameObject SpawnPoint;
    public GameObject DeadPoint;
    public GameObject background;
    public float speedBackground;
    public Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //get Component of object 
    }

    // Update is called once per frame
    void Update()
    {
        Background();
    }
    private void OnTriggerEnter(Collider col) //method of trigger collision 
    {
        if (col.gameObject.CompareTag("deadpoint")) //check if col is colliding with tag 
        {

            Instantiate(background, SpawnPoint.transform.position, Quaternion.identity, transform.parent); //instantiate a object in position e rotation especified
            Destroy(this.gameObject); // destroy object
        }
    }

    public void Background()
    {
        background.transform.Translate(1 * speedBackground, 0, 0); // movement object for right 
    }
}

