﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_Controller : MonoBehaviour
{
    public Transform[] tiles;
    public GameObject[] tilesGO = null;
    public Transform startTile;
    public Transform endTile;
    public Transform player;
    public Transform slimeEnemy;
    public Transform zombieEnemy;
    public Transform skeleteonEnemy;
    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        deSpawnGrid();
        spawnGrid();
        chooseStart();
        spawnEnemy();
    }

    private void deSpawnGrid()
    {
        // if (tilesGO == null)
        tilesGO = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tilesGO)
        {
            Destroy(tile);
        }
    }

    private void chooseStart()
    {
        int index = Random.Range(0, 3);
        int randomChoice = (Random.Range(0, 9) * 32);

        switch (index)
        {
            case 0:
                Instantiate(startTile, new Vector3(-32, 0, randomChoice), Quaternion.identity);
                player.position = new Vector3(-32, 1, randomChoice);
                Instantiate(endTile, new Vector3(320, 0, Random.Range(0, 9) * 32), Quaternion.identity);
                break;
            case 1:
                Instantiate(startTile, new Vector3(320, 0, randomChoice), Quaternion.identity);
                player.position = new Vector3(320, 1, randomChoice);
                Instantiate(endTile, new Vector3(-32, 0, Random.Range(0, 9) * 32), Quaternion.identity);
                break;
            case 2:
                Instantiate(startTile, new Vector3(randomChoice, 0, -32), Quaternion.identity);
                player.position = new Vector3(randomChoice, 1, -32);
                Instantiate(endTile, new Vector3((Random.Range(0, 9) * 32), 0, 320), Quaternion.identity);
                break;
            case 3:
                Instantiate(startTile, new Vector3(randomChoice, 0, 320), Quaternion.identity);
                player.position = new Vector3(randomChoice, 1, 320);
                Instantiate(endTile, new Vector3((Random.Range(0, 9) * 32), 0, -32), Quaternion.identity);

                break;
        }
    }
    public navMesh_Script navscript;

    void spawnGrid()
    {
        //  navscript.UpdateMesh();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(getRandomTile(), new Vector3(i * 32, 0, j * 32), Quaternion.identity);
            }
        }
        navscript.buildNavMesh();
    }
    public int numSlimeToSpawn = 1;
    public int numSkeletonToSpawn = 1;
    public int numZombieToSpawn = 1;

    void spawnEnemy()
    {
        for (int i = 0; i < numSlimeToSpawn; i++)
        {
            Instantiate(slimeEnemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < numZombieToSpawn; i++)
        {
            Instantiate(zombieEnemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < numSkeletonToSpawn; i++)
        {
            Instantiate(skeleteonEnemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public Transform getRandomTile()
    {
        int index = Random.Range(0, tiles.Length);
        return tiles[index];
    }
    // Update is called once per frame
    void Update()
    {
    }
}