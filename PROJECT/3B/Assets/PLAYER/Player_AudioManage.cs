using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AudioManage : MonoBehaviour
{
    public void Start()
    {
        UpdateAudio();
    }

    public void UpdateAudio()
    {
        float music = PlayerPrefs.GetFloat("volume_music");
        float sfx = PlayerPrefs.GetFloat("volume_sfx");
        float amb = PlayerPrefs.GetFloat("volume_amb");

        foreach (Transform child in transform)
        {
            float maxVolume = child.gameObject.GetComponent<Audio_MaxVolume>().maxVolume;
            float multiplier = 1;

            AudioSource audioSource = child.gameObject.GetComponent<AudioSource>();

            if (child.gameObject.tag == "MUSIC") multiplier = PlayerPrefs.GetFloat("volume_music");
            else if (child.gameObject.tag == "SFX") multiplier = PlayerPrefs.GetFloat("volume_sfx");
            else if (child.gameObject.tag == "AMB") multiplier = PlayerPrefs.GetFloat("volume_amb");

            audioSource.volume = maxVolume * multiplier;
        }
    }
}
