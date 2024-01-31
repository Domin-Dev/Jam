using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider SprintBar;


    public static UIManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);  
        }
    }

 

    public void UpdateSprintBar(float value)
    {
        SprintBar.value = value;
    }

    public void UpdateHPBar(float value)
    {
        hpBar.value = value;
    }
}
