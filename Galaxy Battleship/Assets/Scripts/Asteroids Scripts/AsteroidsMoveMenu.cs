using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMoveMenu : MonoBehaviour
{
    // variables
    public float varSpeedRot; //rotate speed    
    public float varSpeedMove; //Move speed

    void Start()
    {
        AsteroidsVarSpeed(); //calling the method of variation movement speed
    }

    // Update is called once per frame
    void Update()
    {

        AsteroidsRotate();  //calling the method of rotation
        AsteroidsMovement(); //calling the method of movement

    }

    public void AsteroidsMovement() //method Movement
    {
        this.transform.Translate(1 * varSpeedMove, 0, 0, Space.World); // movement object 
    }
    public void AsteroidsRotate() //method rotate
    {
        this.transform.Rotate(1 * varSpeedMove, -1 * varSpeedMove, 0, Space.World); //rotation object
    }
    public void AsteroidsVarSpeed() //method variation move and rotate
    {
        varSpeedRot = Random.Range(0.5f, 1.5f); //random speed rotate
        varSpeedMove = Random.Range(0.3f, 0.5f);  //random speed move
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DestroyAsteroids"))
        {
            Destroy(this.gameObject);
        }
    }
}
