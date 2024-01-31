using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonLL<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance;
    protected void GetInstance() { Instance = this as T; }
    protected void GetInstance_OnlyOneInstance()
    {
        if (Instance != null && Instance != (this as T))
            Debug.LogError("Wiecej niz jedna instancja. Nazwa obiektu: " + gameObject.name);
        //Nie ustawia jesli jest juz jakas inna instancja przypisana (bo na tamtej moglo juz cos byc robione - np. w PlayerStats)
        else
            Instance = this as T;
    }
    public static T FindInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();
            }
            return Instance;
        }
    }


}
