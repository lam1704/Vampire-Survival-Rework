using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponInformation;
    [SerializeField] private float destroyAfterSecond;


    //stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCD;
    protected int currentPierce;

    private void Awake()
    {
        currentCD = weaponInformation.CD;
        currentDamage = weaponInformation.Damage;
        currentSpeed = weaponInformation.Speed;
        currentPierce = weaponInformation.Pierce;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSecond);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Stats enemy = collision.GetComponent<Stats>();
            enemy.TakeDamage(currentDamage);
            Debug.Log($"Enemy take {currentDamage} Damage");
        }
    }

    //void ApplyPierce()
    //{
    //    currentPierce--;
    //    if (currentPierce <= 0)
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}
