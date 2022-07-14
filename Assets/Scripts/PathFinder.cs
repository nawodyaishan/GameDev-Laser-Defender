using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSo _waveConfigSo;
    List<Transform> _wayPoints;
    int _waypointIndex = 0;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _waveConfigSo = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfigSo.GetWaypoints();
        transform.position = _wayPoints[_waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_waypointIndex < _wayPoints.Count)
        {
            Vector3 targetPosition = _wayPoints[_waypointIndex].position;
            float delta = _waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);

            // Checking whether the same position
            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}