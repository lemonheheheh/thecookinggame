using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        if (musicSource != null)
        {
            musicSource.loop = true;  // make sure it loops
            musicSource.Play();       // start playing when the game starts
        }
    }
}