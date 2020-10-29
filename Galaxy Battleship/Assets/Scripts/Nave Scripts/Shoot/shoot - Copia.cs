using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform [] Gunplayer; //player position
    public GameObject bulletprefab;
    public float fireRate  = 25f;
    public float countTime;
   
    
    
   
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
        Shoot(); //Initializing the method 
    }
    public void Shoot() //method shoot
    {
        if (Input.GetButton("Shoot") && countTime > fireRate ) // if true ? shoot !!
        {
            
            Instantiate(bulletprefab, Gunplayer[0].position, Gunplayer[0].rotation); //instanteate one bullet
            ResetTime(); //call the method 
            //fire.Play(); //play particle of bullet

        }
        
        countTime++;
    }

    public void ResetTime() //reset the time shoot
    {
        countTime = 0f;
    }
    


}
