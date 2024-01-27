using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Camera _camera;
    Rigidbody2D _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _speed2;
    [SerializeField] Vector2 direction;
    [SerializeField] Vector2 lastPostion;
   // List<Transform> tail;



    private void Start()
    {
        _camera = Camera.main.GetComponent<Camera>();
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (lastPostion != null)
        {
            Transform child = transform.GetChild(0);
           
            Vector2 target = (lastPostion + (Vector2)child.position) / 2f;
            child.position = Vector2.MoveTowards(child.position, target, _speed2 * Time.deltaTime);
        }
        lastPostion = transform.position;

        direction = transform.position - _camera.ScreenToWorldPoint(Input.mousePosition);
        direction = direction.normalized;
        _rb.velocity = -direction  *  _speed;


        Debug.Log(_rb.velocity.x * _rb.velocity.x + _rb.velocity.y * _rb.velocity.y);
    }
}
