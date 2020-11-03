using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pontuation : MonoBehaviour
{
    //Variables
    public int points;
    public TMP_Text textscore;
    public int record;
    public Text scoreText;
    public int asteroidsPoints = 100;
    public int LittleAsteroidsPoints = 50;
    public int duplicatepoints = 100;
    public int ChasePoints = 200;
    public int shooterPoints = 400;
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
