using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 0.3f;

    public float maxZoom = 3.5f;
    public float minZoom = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0.0f && gameObject.GetComponent<Camera>().orthographicSize - zoomSpeed > maxZoom)
        {
            gameObject.GetComponent<Camera>().orthographicSize -= zoomSpeed;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f && gameObject.GetComponent<Camera>().orthographicSize - zoomSpeed < minZoom)
        {
            gameObject.GetComponent<Camera>().orthographicSize += zoomSpeed;
        }
    }
}
