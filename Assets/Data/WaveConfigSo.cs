using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
    public class WaveConfigSo : ScriptableObject
    {
        [SerializeField] Transform pathPrefab;
        [SerializeField] float moveSpeed;

        public Transform GetStartingWaypoint()
        {
            // Returning Starting Waypoint
            return pathPrefab.GetChild(0);
        }

        public List<Transform> GetWaypoints()
        {
            List<Transform> waypoints = new List<Transform>();

            foreach (var child in waypoints)
            {
                waypoints.Add(child);
            }

            return waypoints;
        }

        public float GetMoveSpeed()
        {
            return this.moveSpeed;
        }
    }
}