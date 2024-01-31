using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : SingletonLL<UiManager>
{

    [Header("Scenes:")]
    public string[] scenes = new string[0];

    [Header("Level values:")]
    public float startTime = 15.0f;
    public float maxTime = 30.0f;
    public float timeToAddPerKill = 15.0f;

    //public float satisfaction = 1.0f;
    //public float decreaseSpeedPerSecond = 1f;

    [Header("UI:")]
    public SimpleBar simpleBar;
    public RadialBar radialBar;
    public FaceSatisfaction faceSatisfaction;
    public Text remainingTimeText;
    public Text levelNumberText;

    [Header("Panels:")]
    public SuccessLevelInfoPanel successLevelInfoPanel;
    public GameOverPanel gameOverPanel;
    public SuccessGamePanel successGamePanel;

    [SerializeField] float currentTime;

    void Start()
    {
        currentTime = startTime;
        Time.timeScale = 1.0f;
        levelNumberText.text = "LEVEL " + SaveManager.FindInstance.Get_Level();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0) currentTime = 0;

        simpleBar.UpdateBar(currentTime / maxTime);
        radialBar.UpdateBar(currentTime / maxTime);
        faceSatisfaction.UpdateBar(currentTime / maxTime);
        UpdateRemainingTimeText();

        //End time -> load nex level
        if(currentTime == 0) {
            Time.timeScale = 0;
            this.enabled = false;

            //Jesli jest nastepny level
            if(SaveManager.FindInstance.Get_Level() < scenes.Length)
            {
                successLevelInfoPanel.ShowPanel();
            }
            else
            {
                successGamePanel.ShowPanel();
            }



        }
    }
    public void IncreaseTime()
    {
        Debug.Log("butt");
        IncreaseTime(timeToAddPerKill);
    }

    public void IncreaseTime(float timeToAdd)
    {
        currentTime += timeToAdd;

        if (currentTime > maxTime)
            currentTime = maxTime;

        simpleBar.UpdateBar(currentTime / maxTime);
        radialBar.UpdateBar(currentTime / maxTime);
        faceSatisfaction.UpdateBar(currentTime / maxTime);
    }

    void UpdateRemainingTimeText()
    {
        remainingTimeText.text = (int)(currentTime) + " s";
    }
}
