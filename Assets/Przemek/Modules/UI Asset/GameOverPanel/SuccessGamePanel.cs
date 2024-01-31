using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessGamePanel : BaseScorePanel
{
    public void ShowPanel()
    {
        base.LoadScoresToUiText();
        panel.SetActive(true);
    }
    public void ButtonAction_NextLevel()
    {
        panel.SetActive(false);
    }
}
