using UnityEngine;

public class LeavesController : WeaponController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnLeaf = Instantiate(prefab);
        spawnLeaf.transform.position = transform.position;
        spawnLeaf.GetComponent<LeafBehaviour>().DirectionChecker(pm.lastMovedDir);
    }
}
