using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : SingletonLL<SaveManager>
{
    public const string KEY_CURRENT_SCORES = "CURRENT_SCORES";
    public const string KEY_BEST_SCORES = "BEST_SCORES";
    public const string KEY_CURRENT_LEVEL = "CURRENT_LEVEL";
    
    public static void ResetValues()
    {
        PlayerPrefs.SetInt(SaveManager.KEY_CURRENT_LEVEL, 1);
        PlayerPrefs.SetInt(SaveManager.KEY_CURRENT_SCORES, 0);
        Debug.Log("TESTS. Reset: level = 1, scores = 0.");
    }

    public void Add_CurrentScores(int valueToAdd) { Set_CurrentScores(Get_CurrentScores() + valueToAdd); }
    public void Reset_CurrentScores() { Set_CurrentScores(0); }
    public void Set_NextLevel() { Set_Level(Get_Level() + 1); }

    public void Set_CurrentScores(int value) {   
        PlayerPrefs.SetInt(KEY_CURRENT_SCORES, value);
        Debug.Log("TESTS. Set scores: " + value);

        if(value > Get_BestScores())
        {
            Set_BestScores(value);
        }
    }
    public void Set_BestScores(int value) {
        PlayerPrefs.SetInt(KEY_BEST_SCORES, value);
        Debug.Log("TESTS. Set best scores: " + value);
    }
    public void Set_Level(int value) { 
        PlayerPrefs.SetInt(KEY_CURRENT_LEVEL, value);
        Debug.Log("TESTS. Set level: " + value);
    }


    public int Get_CurrentScores() { return PlayerPrefs.GetInt(KEY_CURRENT_SCORES); }
    public int Get_BestScores() { return PlayerPrefs.GetInt(KEY_BEST_SCORES); }
    public int Get_Level() { return PlayerPrefs.GetInt(KEY_CURRENT_LEVEL); }
    public bool IsNexLevel() { return (Get_Level() + 1 <= UiManager.FindInstance.scenes.Length ); }

    public void ButtnAction_IncreaseBestScores() { Set_BestScores(Get_BestScores() + 1); }
}
