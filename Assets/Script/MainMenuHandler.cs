using UnityEngine;
using UnityEngine.UI; // For displaying the score on UI
using UnityEngine.SceneManagement;
using TMPro;    
using System; 

public class MainMenuHandler : MonoBehaviour
{
    // Start is
    //  called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame(){
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("clicked");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
