using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    [SerializeField] int objectValue;

    private GameUI gameUI;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            // Instantiate the particle effect using the other object's particle system
            ParticleSystem otherExplosionParticle = other.GetComponent<Collisions>().explosionParticle;

            // Get the score value associated with the collided "Goal" object
            int scoreValue = other.GetComponent<Collisions>().objectValue;

            // Update the score in the GameUI
            gameUI.UpdateScore(scoreValue);
            audioManager.GoalAudio();
            Destroy(other.gameObject);
            Instantiate(otherExplosionParticle, other.transform.position, otherExplosionParticle.transform.rotation);

            // Instantiate the explosion particle effect from the collided "Goal" object
            ParticleSystem instantiatedParticle = Instantiate(otherExplosionParticle, other.transform.position, otherExplosionParticle.transform.rotation);

            float scaleFactor = 60.0f;
            instantiatedParticle.transform.localScale *= scaleFactor;
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameUI.GameOver();
            audioManager.DeathAudio();
        }
    }
}
