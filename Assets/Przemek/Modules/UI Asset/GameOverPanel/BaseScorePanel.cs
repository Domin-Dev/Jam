using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScorePanel : MonoBehaviour
{
    [Header("Base scire texts:")]
    public Text scoresText;
    public Text bestScoresText;
    public GameObject panel;

    public void LoadScoresToUiText()
    {
        scoresText.text =     "Scores:  " + SaveManager.FindInstance.Get_CurrentScores().ToString();
        bestScoresText.text = "Best scores: " + SaveManager.FindInstance.Get_BestScores().ToString();
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
    public void ButtonAction_Retry()
    {
        Debug.Log("Button...");
        //SaveManager.FindInstance.Get_Level();
        SaveManager.ResetValues();
        SceneManager.LoadScene(UiManager.FindInstance.scenes[0]);
    }
    public void ButtonAction_Exit()
    {
        Application.Quit();
    }
}
