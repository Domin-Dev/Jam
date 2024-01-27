using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManTrigger : MonoBehaviour
{

    public Man man;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lion")
        {
            man.Ran(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lion")
        {
            man.Safe();
        }
    }

}
