using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> cheer;
    AudioSource audioSource;
    AudioSource people;

    AudioSource menu;
    AudioSource battle;
    AudioSource lion;


    int i;

    public static SoundsManager soundsManager;

    private void Awake()
    {
        if(soundsManager == null)
        {
            soundsManager = this;
        }
        else
        {
            Destroy(soundsManager);
        }


    }


    private void Start()
    {
        i = Random.Range(0, cheer.Count);
        people = transform.GetChild(1).GetComponent<AudioSource>();
        audioSource = transform.GetChild(1).GetComponent<AudioSource>();   
        menu = transform.GetChild(3).GetComponent<AudioSource>();   
        battle = transform.GetChild(4).GetComponent<AudioSource>();   
        lion = transform.GetChild(1).GetComponent<AudioSource>() ;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

                people.Pause();
                menu.Play();
                lion.Pause();
                audioSource.Pause();
            }
            else
            {
                people.Play();
                lion.Play();
                audioSource.Play();
                battle.Play();
            }
        
    }

    private void nextIndex()
    {
        i++;
        if(i == cheer.Count)
        {
            i = 0;
        }
    }
    public void Cheer()
    {
        audioSource.PlayOneShot(cheer[i]);
        nextIndex();
    }


}
