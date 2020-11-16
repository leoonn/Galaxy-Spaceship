using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void Credits()
    {
        
    }
    public void Options()
    {
        
    }

    public void Shop()
    {
        shopPanel.SetActive(true);
    }

    public void ShopOff()
    {
        shopPanel.SetActive(false);
    }
}
