using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Wave Config", fileName = "Wave ")]
    public class WaveConfigSo : ScriptableObject
    {
        [SerializeField] Transform pathPrefab;
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] private List<GameObject> enemyPrefabObjects;

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
    }
}