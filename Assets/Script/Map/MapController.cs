using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainChunks;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private float checkerRadius = 0.2f;
    private Vector3 noTerrainPosition;
    public GameObject currentChunk;
    private PlayerMovement pm;

    [SerializeField] private List<GameObject> spawnedChunks;
    private GameObject lastestChunk;
    [SerializeField] private float maxOptimizationDistance;
    private float optimizationDistance;
    private float optimizerCD;
    [SerializeField] private float optimizerCDDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        chunkOptimizer();
    }
    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }
        // Right
        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        // Left
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        // Up
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        // Down
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        // Right Down
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        // Right Up
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        // Left Up
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();
            }
        }
        // Left Down
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        lastestChunk = Instantiate(terrainChunks[random], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(lastestChunk);
    }
    void chunkOptimizer()
    {
        optimizerCD -= Time.deltaTime;
        if (optimizerCD < 0)
        {
            optimizerCD = optimizerCDDuration;
        }
        else
        {
            return;
        }
        foreach (GameObject chunk in spawnedChunks)
        {
            optimizationDistance = Vector3.Distance(player.transform.transform.position, chunk.transform.position);
            if (optimizationDistance > maxOptimizationDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }

    }
}
