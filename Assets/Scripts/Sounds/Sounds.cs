using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    AudioSource checkpointSound = null;
    [SerializeField]
    AudioSource collectSound = null;
    [SerializeField]
    AudioSource deathSound = null;
    [SerializeField]
    AudioSource jumpSound = null;

    public static Sounds instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCheckpointSound()
    {
        checkpointSound.Play();
    }

    public void PlayCollectSound()
    {
        collectSound.Play();
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
}
