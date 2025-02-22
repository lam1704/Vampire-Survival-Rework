using UnityEngine;

public class CircleLeavesController : WeaponController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedBranch = Instantiate(prefab);
        spawnedBranch.transform.position = transform.position;
        spawnedBranch.transform.parent = transform;
    }
}
