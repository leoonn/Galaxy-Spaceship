using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    // variables
    public float varSpeedRot; //rotate speed    
    public float varSpeedMove; //Move speed
    public float speedRot = -50;
    public float speedMove = -10;
    private Rigidbody asteroidsRigid;
    Vector3 m_EulerAngleVelocity;

    void Start()
    {
        AsteroidsVarSpeed(); //calling the method of variation movement speed
        asteroidsRigid = gameObject.GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, speedRot * varSpeedRot, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        AsteroidsRotate();  //calling the method of rotation
        AsteroidsMovement(); //calling the method of movement

    }

    public void AsteroidsMovement() //method Movement
    {
        asteroidsRigid.AddForce(speedMove * varSpeedMove, 0, 0); // movement object 
    }
    public void AsteroidsRotate() //method rotate
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        asteroidsRigid.MoveRotation(asteroidsRigid.rotation * deltaRotation);
    }
    public void AsteroidsVarSpeed() //method variation move and rotate
    {
        varSpeedRot = Random.Range(0.5f, 1.5f); //random speed rotate
        varSpeedMove = Random.Range(0.2f, 0.4f);  //random speed move
    }

    public void OnBecameInvisible() //method for asteroids exit of camera
    {
        Destroy(this.gameObject); //destroy gameobject
    }
}
