using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string newSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonAction_StartGame()
    {
        //Reset wszystkich wartosci:
        SaveManager.ResetValues();

        SceneManager.LoadScene(newSceneName);
    }
    public void ButtonAction_ShowScores() { }
    public void ButtonAction_ExitGame() {
        Application.Quit();
    
    }
}
