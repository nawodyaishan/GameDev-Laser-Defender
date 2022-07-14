using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSo currentWave;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position, Quaternion.identity);
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