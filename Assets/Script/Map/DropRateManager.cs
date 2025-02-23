using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [SerializeField] private PickUpScriptableObject pickUpScriptableObject;

    private void OnDestroy()
    {
        if (pickUpScriptableObject == null) return;

        float randomNumber = UnityEngine.Random.Range(0, 100);
        List<PickUpScriptableObject.Drops> possibleDrops = new List<PickUpScriptableObject.Drops>();
        Debug.Log($"The number is {randomNumber}");
        foreach (var d in pickUpScriptableObject.DropsList)
        {
            if (randomNumber <= d.DropChance)
            {
                possibleDrops.Add(d);
                //Debug.Log($"Adding {d.Name} to the drops");
            }
        }

        if (possibleDrops.Count > 0)
        {
            PickUpScriptableObject.Drops drop = possibleDrops[possibleDrops.Count-1];
            Instantiate(drop.ItemPrefab, transform.position, Quaternion.identity);
            Debug.Log($"Dropping {drop.Name}");
        }
    }
}
