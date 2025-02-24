using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerScriptableObject playerScript;


    float currentHealth;
    float currentRegen;
    float currentMoveSpeed;
    float currentDamange;
    float currentProjectileSpeed;




    //lv Up System

    public int exp = 0;
    public int level = 1;
    public int expRequired;



    //IFrame
    [SerializeField] private float invincibilityDuration = 0.5f;
    float invincibilityTimer;
    bool isInvincible = false;

    public void IncreaseExp(int amount)
    {
        exp += amount;
        LevelUpChecker();
    }
    public void LevelUpChecker()
    {
        if (exp >= expRequired)
        {
            level++;
            exp -= expRequired;
            expRequired = CalculateExpRequired(level);
            if (exp >= expRequired)
            {
                LevelUpChecker();
            }
        }
    }
    public int CalculateExpRequired(int level)
    {
        double calculation = Math.Pow(4 * (level + 1), 2.1) - Math.Pow(4 * level, 2);
        int amount = (int)Math.Round(calculation);
        return amount;
    }
    public void LevelUp()
    {
        IncreaseExp(expRequired);
        Debug.Log("Leveling up");
    }
    private void Awake()
    {
        currentHealth = playerScript.MaxHealth;
        currentRegen = playerScript.Regeneration;
        currentMoveSpeed = playerScript.MoveSpeed;
        currentDamange = playerScript.Strength;
        currentProjectileSpeed = playerScript.ProjectileSpeed;
    }


    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            if (currentHealth <= 0) Kill();
        }
    }


    private void Kill()
    {
        //Destroy(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        expRequired = CalculateExpRequired(level);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }
}
