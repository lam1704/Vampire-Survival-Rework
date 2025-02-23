using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerScriptableObject playerScript;


    float currentHealth;
    float currentRegen;
    float currentMoveSpeed;
    float currentStrength;
    float currentProjectileSpeed;




    //lv Up System

    public int exp = 0;
    public int level = 1;
    public int expRequired;


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
    }
    private void Awake()
    {
        currentHealth = playerScript.MaxHealth;
        currentRegen = playerScript.Regeneration;
        currentMoveSpeed = playerScript.MoveSpeed;
        currentStrength = playerScript.Strength;
        currentProjectileSpeed = playerScript.ProjectileSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        expRequired = CalculateExpRequired(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
