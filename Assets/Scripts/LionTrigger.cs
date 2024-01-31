using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tail" || collision.tag == "Wall")
        {
            Player.instance.LionHitTail();
        }
        else if(collision.tag == "Food")
        {
            Blood.Instance.MakeBlood(collision.transform.position);
            SoundsManager.soundsManager.Cheer();
            Destroy(collision.gameObject);
            Player.instance.AddTail();
            Player.instance.AddScore();
            Player.instance.UpdateKills();
        }
    }
}
