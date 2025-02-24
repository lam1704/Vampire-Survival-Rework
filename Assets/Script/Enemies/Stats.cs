using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public EnemyScriptableObject enemyScript;
    float currentMovementSpeed;
    float currentHealth;
    float currentDamage;
    private void Awake()
    {
        currentMovementSpeed = enemyScript.MoveSpeed;
        currentHealth = enemyScript.MaxHealth;
        currentDamage = enemyScript.Damage;
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
