using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform [] Gunplayer; //player position
    public GameObject bulletprefab;
   

    public Camera cam;

    public float waitshot;
    public float timeshot = 4f;
    
   
    void Start()
    {
        waitshot = timeshot;

    }

    // Update is called once per frame
    void Update()
    {
       
        Shoot(); //Initializing the method 
    }
    

    public void ResetTime() //reset the time shoot
    {
       
    }
    private void Shoot()
    {
        if (Input.GetButton("Shoot") && waitshot <= 0) // if true ? shoot !!
        {
            // Create a ray from the camera going through the middle of your screen
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            // Check whether your are pointing to something so as to adjust the direction
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(1000); // You may need to change this value according to your needs
                                                  // Create the bullet and give it a velocity according to the target point computed before
            var bullet = Instantiate(bulletprefab, Gunplayer[0].transform.position, Gunplayer[0].transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = (targetPoint - Gunplayer[0].transform.position).normalized * 10;
            waitshot = timeshot;
        }
        else
        {
            waitshot -= Time.deltaTime;
        }
    }


}
