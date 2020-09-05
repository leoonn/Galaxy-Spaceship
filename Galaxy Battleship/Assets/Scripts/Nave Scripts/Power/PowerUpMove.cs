using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMove : MonoBehaviour
{
    //variables
    public int speed = 10; 
    public int speedRot = 50;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime, 0); //move icon power ups axi z
        transform.Rotate( speedRot * Vector3.up * Time.deltaTime, Space.World); //rotate power up icon
    }
}
