using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShoot : MonoBehaviour
{

    public Image Aim;

    public float weaponRange = 50f;  // Distance in Unity units over which the player can fire                          
    public Camera fpsCam;
   


    void Start()
    {



    }
    void Update()
    {

        // Create a vector at the center of our camera's viewport
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        // Declare a raycast hit to store information about what our raycast has hit
        




        // Check if our raycast has hit anything
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
        {
            Transform asteoid = hit.transform;
            if (asteoid.CompareTag("DestroyAsteroids"))
            {
                Aim.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }
            else
            {
                Aim.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }


        }


    }
}


