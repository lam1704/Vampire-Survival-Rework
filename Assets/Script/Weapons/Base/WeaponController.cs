using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponScriptableObject weaponInformation;
    private float currentCD;
    protected PlayerMovement pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
        currentCD = weaponInformation.CD;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCD -= Time.deltaTime;
        if (currentCD < 0) {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        currentCD = weaponInformation.CD;
    }
}
