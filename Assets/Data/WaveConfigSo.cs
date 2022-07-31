using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Wave Config", fileName = "Wave ")]
    public class WaveConfigSo : ScriptableObject
    {
        [SerializeField] Transform pathPrefab;
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] List<GameObject> enemyPrefabObjects;
        [SerializeField] private float timeBetweenSpawns = 0.7f;
        [SerializeField] private float spawnTimeVariance = 0f;
        [SerializeField] private float minimumSpawnTime = 0.2f;

        public Transform GetStartingWaypoint()
        {
            // Returning Starting Waypoint
            return pathPrefab.GetChild(0);
        }

        public List<Transform> GetWaypoints()
        {
            List<Transform> waypoints = new List<Transform>();

            foreach (Transform child in pathPrefab)
            {
                waypoints.Add(child);
            }

            return waypoints;
        }

        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        public GameObject GetEnemyPrefab(int index)
        {
            return (enemyPrefabObjects[index]);
        }

        public int GetEnemyCount()
        {
            return enemyPrefabObjects.Count;
        }

        public float GetRandomSpawnTime()
        {
            float spawnTime =
                Random.Range(timeBetweenSpawns - spawnTimeVariance, timeBetweenSpawns + spawnTimeVariance);
            return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        }
    }
}