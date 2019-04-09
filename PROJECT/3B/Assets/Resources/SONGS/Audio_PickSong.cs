using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PickSong : MonoBehaviour
{
    private int songNumber;

    private void Start()
    {
        songNumber = Random.Range(1, 7);
        PlaySong(songNumber);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            if (songNumber == 6)
            {
                songNumber = 1;
                PlaySong(songNumber);
            }
            else
            {
                songNumber++;
                PlaySong(songNumber);
            }
        }
    }

    void PlaySong(int number)
    {
        AudioClip Clip = Resources.Load<AudioClip>("SONGS/MUSIC_" + number.ToString());
        gameObject.GetComponent<AudioSource>().clip = Clip;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
