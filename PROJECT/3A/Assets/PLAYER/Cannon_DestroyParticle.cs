using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_DestroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 2);
    }

    // Update is called once per frame
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
