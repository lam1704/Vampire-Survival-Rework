using UnityEngine;
[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/Player")]

public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField] GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] float regeneration;
    public float Regeneration { get => regeneration; private set => regeneration = value; }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] float strength;
    public float Strength { get => strength; private set => strength = value; }

    [SerializeField] float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }
}
