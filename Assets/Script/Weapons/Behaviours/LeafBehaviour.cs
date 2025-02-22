using UnityEngine;

public class LeafBehaviour : ProjectileWeaponBehaviour
{
    LeavesController lc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        lc = FindAnyObjectByType<LeavesController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * lc.speed * Time.deltaTime;
    }
}
