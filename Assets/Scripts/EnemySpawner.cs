using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSo currentWave;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private List<WaveConfigSo> waveConfigs;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        foreach (var waveConfigSo in waveConfigs)
        {
            currentWave = waveConfigSo;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position,
                    Quaternion.identity);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public WaveConfigSo GetCurrentWave()
    {
        return currentWave;
    }
}