using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : BaseScorePanel
{

    public void ShowPanel()
    {
        base.LoadScoresToUiText();
        panel.SetActive(true);
    }
}
