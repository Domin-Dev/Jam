using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaesarsSatisfactionBar : SingletonLL<CaesarsSatisfactionBar>
{


    [Header("Level values:")]
    public float startTime = 15.0f;
    public float maxTime = 30.0f;
    public float timeToAddPerKill = 15.0f;

    //public float satisfaction = 1.0f;
    //public float decreaseSpeedPerSecond = 1f;

    [Header("UI:")]
    public SimpleBar simpleBar;
    public RadialBar radialBar;
    public Text remainingTimeText;

    float currentTime;

    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0) currentTime = 0;

        simpleBar.UpdateBar(currentTime / maxTime);
        radialBar.UpdateBar(currentTime / maxTime);
        UpdateRemainingTimeText();
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
    }

    void UpdateRemainingTimeText()
    {
        remainingTimeText.text = (int)(currentTime - 1) + " s";
    }
    /*
    public void IncreaseValue(float valueToAdd)
    {
        satisfaction += valueToAdd;

        if (satisfaction > 1.0f)
            satisfaction = 1.0f;

        simpleBar.UpdateBar(satisfaction);
        radialBar.UpdateBar(satisfaction);
    }
    */
}
