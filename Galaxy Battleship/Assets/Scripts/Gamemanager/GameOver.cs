using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    //variables
    public TMP_Text ScoreGameOver;
    public TMP_Text RecordGameOver;
    Pontuation pointsScript;
    public GameObject panelGameOver;
    void Start()
    {
        RecordGameOver.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //get player prefs highscore
        pointsScript = GameObject.Find("GameManager").GetComponent<Pontuation>(); //get componente of other script
    }

    // Update is called once per frame
    void Update()
    {
        PointsShow(); //call methood of points 
        RecordShow(); //call method of record
    }
    public void PointsShow()
    {
        ScoreGameOver.text = pointsScript.points.ToString();  // convert a int in text 
    }

    public void RecordShow()
    {
        if (pointsScript.points > PlayerPrefs.GetInt("HighScore",0)) //if points > that record its true and record in variable highscore
        {
            PlayerPrefs.SetInt("HighScore", pointsScript.points); // set a highscore 
            RecordGameOver.text = pointsScript.points.ToString(); // // convert a int in text 
        }
    }
    public void GameOverActive()
    {
        panelGameOver.SetActive(true); //active a gameobject in unity 
        pointsScript.textscore.enabled = false; //desactive a text in unity 
        
    }
    public void Continue()
    {
        SceneManager.LoadScene("Rank"); //load scene rank 
    }
   
}
