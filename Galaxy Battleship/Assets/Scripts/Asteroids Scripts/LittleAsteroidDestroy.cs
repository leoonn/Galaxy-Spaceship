using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleAsteroidDestroy : MonoBehaviour
{
    
    public GameObject explosion;
    Pontuation pointsScript;
    PowerManager powerScript;
    void Start()
    {
        pointsScript = GameObject.Find("GameManager").GetComponent<Pontuation>();
        powerScript = GameObject.Find("GameManager").GetComponent<PowerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //check object colliding in tag player
        {
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet")) //check object colliding in tag player
        {
            GameObject explosionprefab = Instantiate(explosion, col.transform.position, transform.rotation); // instantieate a particle system
            Destroy(explosionprefab, 3f); //destroy particle
            Destroy(col.gameObject); //destroy bullet       
            Destroy(gameObject); //destroy asteroid
            pointsScript.points = pointsScript.points + pointsScript.LittleAsteroidsPoints;
            pointsScript.scoreText.text = pointsScript.points.ToString();

            if (powerScript.pointsDouble == true)
            {
                pointsScript.points = pointsScript.points + (pointsScript.LittleAsteroidsPoints * 2);
                pointsScript.scoreText.text = pointsScript.points.ToString();


            }

            if (col.gameObject.CompareTag("ShieldColl")) //check object colliding in tag player
            {
                Destroy(gameObject);
                powerScript.Shield();

            }
        }
    }
}
