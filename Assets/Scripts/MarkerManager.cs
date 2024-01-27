using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    [System.Serializable]
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 pos,Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    [SerializeField]public List<Marker> markers = new List<Marker>();

    // Update is called once per frame
    public void UpdateMarkers()
    {
        markers.Add(new Marker(transform.position, transform.rotation));
    }

    public void ClearList()
    {
        markers.Clear();
        markers.Add(new Marker(transform.position, transform.rotation));

    }

}
