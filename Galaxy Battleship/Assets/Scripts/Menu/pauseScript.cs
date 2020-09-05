using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseScript : MonoBehaviour
{

    public GameObject panelPause; // variables
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ActivePause() //method active pause menu
    {
        panelPause.SetActive(true); //active panel
        if (Time.timeScale == 1) 
        {
            Time.timeScale = 0f;//stop the game
           
        }
        
    }
    public void ResumeGame()  //method for resume game
    {
        panelPause.SetActive(false); //desactive panel
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f; //game back your normal time
            
        }
    }
    public void ResetGame() //method for calling scene of game
    {
        SceneManager.LoadScene("GameScene"); //call scene of game
        Time.timeScale = 1f; //back game normal time
        
    }
    public void Menu() //method for call the scene menu
    {
        SceneManager.LoadScene("Menu"); //method for call the scene menu

    }
    
}
