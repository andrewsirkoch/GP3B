using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_KillTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 5);
    }

    // Update is called once per frame
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
