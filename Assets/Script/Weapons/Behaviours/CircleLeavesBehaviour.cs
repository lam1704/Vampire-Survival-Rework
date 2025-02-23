using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CircleLeavesBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !markedEnemies.Contains(collision.gameObject){
            Stats enemy = collision.GetComponent<Stats>();
            enemy.TakeDamage(currentDamage);
            markedEnemies.Add(collision.gameObject);
        }
    }

}
