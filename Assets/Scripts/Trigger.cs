using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Man man;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")// || collision.tag == "Food")
        {
            man.Wall();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if(collision.tag == "Tail"  && man.canAttack)
        {      
            man.Hiting();
        }
    }
}
