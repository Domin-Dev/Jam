using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] int food;
    private void Start()
    {
       food =  GameObject.FindGameObjectsWithTag("Food").Length;
    }
}
