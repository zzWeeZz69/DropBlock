using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject BlockPrefab;
    public GameObject ScoreBlock;

    private float timeToSpawn = 2f;

    public float timeBetweenWaves = 1f;

    GameController GameController;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if(GameController.GameStart == true)
        {
            if (Time.time >= timeToSpawn)
            {
                SpawnBlocks();
                timeToSpawn = Time.time + timeBetweenWaves;
            }
        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(BlockPrefab, spawnPoints[i].position, Quaternion.identity);
            }

            if(randomIndex == i)
            {
                Instantiate(ScoreBlock, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
