using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCollision : MonoBehaviour
{
    public GameObject asteroidCracked;
    public GameObject explosion;

    PowerManager powerScript;
    Pontuation pointsScript;
  
    GameOver gameoverScript;
    void Start()
    {
        powerScript = GameObject.Find("GameManager").GetComponent<PowerManager>();
        pointsScript = GameObject.Find("GameManager").GetComponent<Pontuation>();
       
        gameoverScript = GameObject.Find("GameManager").GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        
       

    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("bullet")) //check object colliding in tag player
        {
            GameObject explosionprefab = Instantiate(explosion, col.transform.position, transform.rotation); // instantieate a particle system
            Destroy(explosionprefab, 3f); //destroy particle
            Instantiate(asteroidCracked, transform.position, transform.rotation); //instatiate asteroid cracked
            Destroy(col.gameObject); //destroy bullet       
            Destroy(gameObject); //destroy asteroid
            
           
            
            Destroy(asteroidCracked.transform.parent, 5f); //destroy peaces asteroids

            if (powerScript.pointsDouble)
            {
                pointsScript.points = pointsScript.points + (pointsScript.asteroidsPoints * 2);
                pointsScript.textscore.text = pointsScript.points.ToString();
            }
            else
            {
                pointsScript.points = pointsScript.points + pointsScript.asteroidsPoints;
                pointsScript.textscore.text = pointsScript.points.ToString();
            }
        }

        if (col.gameObject.CompareTag("ShieldColl")) //check object colliding in tag player
        {
            Destroy(gameObject);
            GameObject explosionprefab = Instantiate(explosion, col.transform.position, transform.rotation); // instantieate a particle system
            Destroy(explosionprefab, 3f); //destroy particle
            
            powerScript.Shield();

        }


    }
}
