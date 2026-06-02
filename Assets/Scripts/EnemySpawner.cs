using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    WaveConfigSO currentWave;

    [SerializeField] float timeBetweenWaves = 1f;

    void Start()
    {       
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            { 
                Instantiate(
                    currentWave.GetEnemyPrefab(i), 
                    currentWave.GetStartingWaypoint().position, 
                    Quaternion.identity, 
                    transform);

                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    { 
        return currentWave;
    }
}
