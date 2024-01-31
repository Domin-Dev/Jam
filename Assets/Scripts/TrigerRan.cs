
using UnityEngine;

public class TrigerRan : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
      //  Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Food")
        {
            if(collision.gameObject.GetComponent<Man>().canAttack)
            collision.gameObject.GetComponent<Man>().Ran(transform.parent);
        }
    }

}
