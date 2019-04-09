using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_PickSound : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;

    public void playSound()
    {
        int decision = Random.Range(0, 2);
        if (decision == 0)
        {
            gameObject.GetComponent<AudioSource>().clip = sound1;
        }
        else if (decision == 1)
        {
            gameObject.GetComponent<AudioSource>().clip = sound2;
        }
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.75f, 1.75f); // Randomize pitch between 0.75 and 1.75 to make it sound like different clips.
        gameObject.GetComponent<AudioSource>().Play();
    }
}
