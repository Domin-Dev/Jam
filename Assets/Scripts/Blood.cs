using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public static Blood Instance;

    [SerializeField] private GameObject bloodObject;

    [SerializeField] private List<GameObject> list; 

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    public void MakeBlood(Vector3 vector3)
    {
        Transform t = Instantiate(bloodObject, vector3, Quaternion.identity).transform;
        Destroy(t.gameObject,0.5f);
        Instantiate(list[Random.Range(0,list.Count)], vector3, Quaternion.identity);
    }

}

