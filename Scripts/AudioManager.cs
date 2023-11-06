using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip deathSound; // Death sound
    public AudioClip goalSound; // Score sound
    private AudioSource playerAudio;
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    public void DeathAudio()
    {
        // Play the death sound with full volume
        playerAudio.PlayOneShot(deathSound, 1.0f);
    }
    public void GoalAudio()
    {
        // Play the goal sound with half the volume
        playerAudio.PlayOneShot(goalSound, 0.5f);
    }
}
