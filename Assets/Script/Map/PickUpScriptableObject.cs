using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PickupScriptableObject", menuName = "ScriptableObject/Pickups")]

public class PickUpScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class Drops
    {
        [SerializeField] private string name;
        public string Name { get => name; private set => name = value; }

        [SerializeField] private GameObject itemPrefab;
        public GameObject ItemPrefab { get => itemPrefab; private set => itemPrefab = value; }

        [SerializeField] private float dropChance;
        public float DropChance { get => dropChance; private set => dropChance = value; }
    }

    [SerializeField] private List<Drops> drops;
    public List<Drops> DropsList { get => drops; private set => drops = value; }
}
