using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static PickUpScriptableObject;

public class DropRateManager : MonoBehaviour
{
    [SerializeField] private PickUpScriptableObject pickUpScriptableObject;
    bool checkBossDrop = false;

    private void OnDestroy()
    {
        if (!Application.isPlaying) return;
        if (pickUpScriptableObject == null) return;

        float randomNumber = UnityEngine.Random.Range(0, 100);
        List<PickUpScriptableObject.Drops> possibleDrops = new List<PickUpScriptableObject.Drops>();
        Debug.Log($"The number is {randomNumber}");
        foreach (var d in pickUpScriptableObject.DropsList)
        {
            if (d.DropChance < 0)
            {
                Instantiate(d.ItemPrefab, transform.position, Quaternion.identity);
                checkBossDrop = true;
            }
            else
            {
                if (randomNumber <= d.DropChance || d.DropChance < 0)
                {
                    possibleDrops.Add(d);
                    //Debug.Log($"Adding {d.Name} to the drops");
                }
            }
        }

        if (possibleDrops.Count > 0 && !checkBossDrop)
        {
            PickUpScriptableObject.Drops drop = possibleDrops[possibleDrops.Count - 1];
            Instantiate(drop.ItemPrefab, transform.position, Quaternion.identity);
            Debug.Log($"Dropping {drop.Name}");
        }
        else
        {
            foreach (var d in possibleDrops)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector3 spawnPosition = GetRandomSpawnPosition();
                    Instantiate(d.ItemPrefab, spawnPosition, Quaternion.identity);
                    Debug.Log($"Dropping {d.Name} - Instance {i + 1}");
                }
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float radius = 2f; 
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * radius;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);
        return spawnPosition;
    }
}
