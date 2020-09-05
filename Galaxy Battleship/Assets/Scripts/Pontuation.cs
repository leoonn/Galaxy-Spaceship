using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuation : MonoBehaviour
{
    public int points;
    public Text scoreText;
    public int asteroidsPoints = 100;
    public int LittleAsteroidsPoints = 50;
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
