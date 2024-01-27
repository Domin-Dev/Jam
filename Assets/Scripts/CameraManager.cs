using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private SpriteRenderer target;
    void Start()
    {
        if (target != null)
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = target.bounds.size.x / target.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                Camera.main.orthographicSize = target.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                Camera.main.orthographicSize = target.bounds.size.y / 2 * differenceInSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
