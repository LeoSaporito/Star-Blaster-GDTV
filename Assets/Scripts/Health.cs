using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] bool isPlayer;
    [SerializeField] int addToScore;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;


    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //check if we hit a damage dealer
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();

            if (applyCameraShake)
            { 
                cameraShake.Play();
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        audioManager.PlayDamageClip();

        if (!isPlayer)
        {
            scoreKeeper.AddToScore(addToScore);
        }        
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);

            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
}
