using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ManTrigger : MonoBehaviour
{

    public Man man;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lion")
        {
            if (!man.canAttack)
            {
                man.Ran(collision.transform);
                man.Attack();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Tail")
        {
            if(man.canAttack)
            {
                man.Attack();
            }
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
