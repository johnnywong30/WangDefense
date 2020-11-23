using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MusicPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ms_NightMarket;

    private float musicVolume = 1f;
    void Start()
    {
        ms_NightMarket.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ms_NightMarket.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
