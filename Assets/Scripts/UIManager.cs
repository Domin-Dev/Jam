using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Slider hpBar;
    [SerializeField] Slider SprintBar;
    [SerializeField] int food;

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

    private void Start()
    {
       food =  GameObject.FindGameObjectsWithTag("Food").Length;
    }

    public void UpdateSprintBar(float value)
    {
        SprintBar.value = value;
    }

    public void UpdateHPBar(float value)
    {
    //    hpBar.value = value;
    }
}
