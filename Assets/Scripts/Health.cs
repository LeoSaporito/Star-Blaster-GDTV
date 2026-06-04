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
    LevelManager levelManager;

    int playerHealth;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        levelManager = FindFirstObjectByType<LevelManager>();
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
            audioManager.PlayDamageClip();

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
        if (isPlayer)
        { 
            levelManager.LoadGameOver();
        }
        else
        {
            scoreKeeper.AddToScore(addToScore);
        }        
        
        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
            ParticleSystem particles = Instantiate(hitParticles, transform.position, Quaternion.identity);

            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
