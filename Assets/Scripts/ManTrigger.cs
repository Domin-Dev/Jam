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
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Tail")
        {
            if (man.canAttack)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll((Vector2)transform.position,(Vector2)collision.transform.position,Vector2.Distance((Vector2)transform.position, (Vector2)collision.transform.position));

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.tag == "Wall")
                    {
                        return;
                    }
                }

                man.Attack(collision.transform);
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lion")
        {
            man.Safe();
        }else if(collision.tag == "Tail")
        {
            man.Attack(null);
        }
    }

}
