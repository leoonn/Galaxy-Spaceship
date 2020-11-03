using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDuplicate : MonoBehaviour
{
    public GameObject duplicated;
    public GameObject duplicated2;

    
    void Start()
    {
      

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateMinis()
    { 
        
            Instantiate(duplicated, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(duplicated2, gameObject.transform.position, gameObject.transform.rotation);


    }
}
