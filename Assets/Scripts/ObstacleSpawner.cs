using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Obstacle obstaclePrefab;
    [SerializeField]
    private float timeBetweenSpawn;
    [SerializeField]
    private float initialDelay;
    [SerializeField]
    private float obstacleVelocity;

    private float currentSpawnTime;
    private Camera cam;
    private float x_spawnCoord;
    private List<Obstacle> pool;

    private void Start()
    {
        currentSpawnTime = -timeBetweenSpawn + initialDelay + Time.timeSinceLevelLoad;
        cam = Camera.main;
        x_spawnCoord = cam.aspect * cam.orthographicSize + 0.65f;
        pool = new List<Obstacle>();
        Obstacle.Lifetime = x_spawnCoord * 2 / obstacleVelocity;
    }

    private void Update()
    {
        if(currentSpawnTime + timeBetweenSpawn <= Time.timeSinceLevelLoad)
        {
            Vector2 spawnPosition = new Vector2(x_spawnCoord, Random.Range(-3f, 3f));
            Spawn(spawnPosition);
            currentSpawnTime = Time.timeSinceLevelLoad;
        }
    }

    private void Spawn(Vector2 position)
    {
        Obstacle item;
        if (pool.Count == 0 || pool[0].gameObject.activeSelf)
        {
            item = Instantiate(obstaclePrefab);
            item.SetVelocity(obstacleVelocity);
        }
        else
        {
            item = pool[0];
            pool.RemoveAt(0);
            item.gameObject.SetActive(true);
        }
        pool.Add(item);
        item.transform.position = position;
    }

    public void StopGame()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            pool[i].SetVelocity(0);
        }
    }
}