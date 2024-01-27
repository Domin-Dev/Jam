using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Camera camera;


    [SerializeField] private float currentHp;
    [SerializeField] private float maxHp;
    [Space(20)]
    [SerializeField] private float maxSprintTime;
    [SerializeField] private float currentSprintTime;



    [SerializeField] private int count;
    [SerializeField] private float distance;
    private float currentDistance;


    [SerializeField] private float speed;
    [SerializeField] private float currentSpeed;


    [SerializeField] private float rotationSpeed;

    [SerializeField] Vector2 direction;
    [SerializeField] Vector2 lastPostion;

    [SerializeField] List<Transform> body = new List<Transform>();
    [SerializeField] List<GameObject> parts = new List<GameObject>();

    [SerializeField] private Sprite spriteBody;

    // List<Transform> tail;

    static public Player instance;
    int sortingOrder;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        camera = Camera.main.GetComponent<Camera>();
        Transform t = Instantiate(parts[0], Vector3.zero, Quaternion.identity).AddComponent<MarkerManager>().transform;
        sortingOrder = t.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
        body.Add(t);
        currentSpeed = speed;
        currentDistance = distance;
        isSprint = false;
        currentSprintTime = maxSprintTime;
        timer1 = 0;
    }



    [SerializeField] private float timer;



    bool isSprint;
    [SerializeField]float timer1;
    private void Update()
    {
        if(isSprint)
        {
            currentSprintTime = currentSprintTime - Time.deltaTime;
            UIManager.Instance.UpdateSprintBar(currentSprintTime / maxSprintTime);
            if (currentSprintTime <= 0)
            {
                currentSpeed = speed;
                isSprint = false;
                timer1 = 1f;
            }
        }
        else if(currentSprintTime <= maxSprintTime)
        {
            if (timer1 > 0)
            {
                timer1 = timer1 - Time.deltaTime;
            }
            else 
            {
                currentSprintTime = currentSprintTime + (Time.deltaTime);
                UIManager.Instance.UpdateSprintBar(currentSprintTime / maxSprintTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSprintTime > 0)
            {
                currentSpeed = 1.45f * speed;
                isSprint = true;
            }
            // currentDistance = 0.5f * distance;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            currentSpeed = speed;
            isSprint = false;
            timer1 = 1f;
            //  currentDistance = distance;
        }
        // if(Input.GetAxis("Mouse X") != 0)
        // {
        //  Debug.Log(Input.GetAxis("Mouse X"));
        //}

        if (Input.GetAxis("Horizontal") != 0)
        {
            body[0].transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        }

        //   if (Input.GetAxis("Mouse X") != 0)
        //   {
        //       body[0].transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime * 2 * Input.GetAxis("Mouse X")));
        //   }


    }


    public void LionHitTail()
    {
         SceneManager.LoadScene(0);
    }

    public void AddTail()
    {
        count++;
        body[body.Count - 1].GetComponent<MarkerManager>().ClearList();
    }
    private void MakePart()
    {
        if (count > 0)
        {
            timer += Time.deltaTime;

            if (timer > distance)
            {
                MarkerManager markerManager = body[body.Count - 1].GetComponent<MarkerManager>();
                Transform t;

             

                if (body.Count > 1 && body[body.Count - 1].GetChild(0).GetComponent<Animator>() != null)
                {
                    body[body.Count - 1].GetChild(0).GetComponent<Animator>().enabled = false;
                    body[body.Count - 1].GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteBody;
                    body[body.Count - 1].GetChild(0).transform.localPosition = Vector3.zero;
                }
                t = Instantiate(parts[2], markerManager.markers[0].position, markerManager.markers[0].rotation).transform;
                sortingOrder--;
                t.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;


                if (body.Count == 1) t.transform.tag = "None";

                t.AddComponent<MarkerManager>();
                body.Add(t);
                t.GetComponent<MarkerManager>().ClearList();

                timer = 0;
                count--;
            }
        }
    }



    private void FixedUpdate()
    {

        body[0].GetComponent<Rigidbody2D>().velocity = body[0].transform.right * -currentSpeed * 10f * Time.deltaTime;

        for (int i = 0; i < body.Count; i++)
        {

            body[i].GetComponent<MarkerManager>().UpdateMarkers();
        }

        MakePart();
        if (body.Count > 1)
        {
            for (int i = 1; i < body.Count; i++)
            {
                MarkerManager markerManager = body[i - 1].GetComponent<MarkerManager>();
                if (markerManager.markers.Count > 0)
                {
                    if (speed == currentSpeed)
                    {
                        body[i].transform.position = markerManager.markers[0].position;
                        body[i].transform.rotation = markerManager.markers[0].rotation;
                        markerManager.markers.RemoveAt(0);
                    }
                    else if(markerManager.markers.Count > 1)
                    {
                        Debug.Log(markerManager.markers[1].rotation + " " + markerManager.markers[1].position);
                        body[i].transform.position = markerManager.markers[1].position;
                        body[i].transform.rotation = markerManager.markers[1].rotation;
                        markerManager.markers.RemoveAt(0);
                    }

                }

            }

        }
    }
}
