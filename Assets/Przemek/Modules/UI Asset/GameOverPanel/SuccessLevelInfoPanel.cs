using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessLevelInfoPanel : BaseScorePanel
{
    public void ShowPanel()
    {
        base.LoadScoresToUiText();
        panel.SetActive(true);
    }
    public void ButtonAction_NextLevel()
    {
        panel.SetActive(false);
        SaveManager.FindInstance.Set_NextLevel();

        Time.timeScale = 1;
        int sceneIndex = SaveManager.FindInstance.Get_Level() - 1;
        Debug.Log("TESTS. SceneIndex = "+ sceneIndex);
        SceneManager.LoadScene(UiManager.FindInstance.scenes[sceneIndex], LoadSceneMode.Single);

    }
}
