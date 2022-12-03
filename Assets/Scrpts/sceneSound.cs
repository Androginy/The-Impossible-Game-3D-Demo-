using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneSound : MonoBehaviour
{
    [SerializeField] AudioSource levelMusic;
    [SerializeField] AudioSource deathSong;

    [SerializeField] bool levelSong = true;
    [SerializeField] bool DeathSong = false;

    public void LevelMusic()
    {
        levelSong = true;
        DeathSong = false;
        levelMusic.Play();
    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if(deathSong.isPlaying && DeathSong == false)
        {
            deathSong.Play();
            DeathSong = true;
        }
    }
}
