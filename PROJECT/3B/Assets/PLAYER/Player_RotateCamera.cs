using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 3);
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 3);
            }
        }
    }
}
