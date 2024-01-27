using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Opponent : MonoBehaviour
{

    public Transform target;
    public float speed = 2;
    public float thrustForce = 1;//Sila pchniecia rogodbody
    public float rotationSpeed = 2;
    public float distanceBetween = 4;

    private Rigidbody2D rigidbody;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    public Vector3 forceDirection;

    // Update is called once per frame

    private void FindTail()
    {
        float distance = float.MaxValue;
        Transform target = transform;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Tail");
        for (int i = 0; i < objects.Length; i++)
        {
            float dist = Vector2.Distance(transform.position, objects[i].transform.position);
            if (distance > dist)
            {
                distance = dist;
                target = objects[i].transform;
            }
        }
    }


    void Update()
    {

        if (target != null)
        {
            distance = Vector2.Distance(this.transform.position, target.position);
            Vector2 direction = target.position - this.transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (distance < distanceBetween)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

                //Vector2 inputDirection = new Vector2(horizontalInput, verticalInput).normalized;
                //rigidbody.AddForce(forceDirection * thrustForce);
                //Vector2 forwardDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * rigidbody.rotation), Mathf.Sin(Mathf.Deg2Rad * rigidbody.rotation));

                // Zastosuj si³ê w kierunku znormalizowanego wektora zwi¹zane z obrotem gracza
                //rigidbody.AddForce(transform.right * thrustForce); 
                //rigidbody.AddForce(inputDirection * thrustForce);

                Quaternion targetRotation = Quaternion.Euler(Vector3.forward * angle);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            }
        }
    }
}
