using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //variables
    public Transform target = null;
    public Transform rig = null;

    public float distance = 10f;
    public float rotationSpeed = 10f;

    Vector3 cameraPosition;
    Vector3 smoothPosition;
    float smoothTime = 0.125f;
    float angle;

    private int camType = 0;


    void Update()
    {
        //change camera
        if(Input.GetKeyDown(KeyCode.C))
        {
            camType += 1;
            if (camType >= 2)
            {
                camType = 0;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // calling the method in camera
        if (camType == 0) BackCam();
        else if (camType == 1) RigCam();
        else BackCam();
    }


    void RigCam()
    {
        //get position of rig object 
        transform.position = rig.position;
        transform.rotation = rig.rotation;
    }
    void BackCam()
    {
        //calculate position camera and smooth camera
        cameraPosition = target.position - (target.forward * distance) + target.up * distance * 0.25f;
        smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smoothTime);
        transform.position = smoothPosition;

        // calculate rotation of camera
        angle = Mathf.Abs(Quaternion.Angle(transform.rotation, target.rotation));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, (rotationSpeed + angle) * Time.deltaTime);
    }
}
