using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponInformation;
    protected Vector3 direction;
    public float destroyAfterSecond;



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
        Destroy(gameObject,destroyAfterSecond);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
        float dirX = direction.x;
        float dirY = direction.y;
        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;
        // Left
        if (dir.x < 0 && dir.y == 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        // Down
        else if (dir.x == 0 && dir.y < 0)
        {
            scale.y = scale.y * -1;
        }
        // Up
        else if (dir.x == 0 && dir.y > 0)
        {
            scale.x = scale.x * -1;
        }
        // Right Up
        else if (dir.x > 0 && dir.y > 0)
        {
            rotation.z = 0f;
        }
        // Right Down
        else if (dir.x > 0 && dir.y < 0)
        {
            rotation.z = -90f;
        }
        // Left Up
        else if (dir.x < 0 && dir.y > 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        // Left Down
        else if (dir.x < 0 && dir.y < 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Stats enemy = collision.GetComponent<Stats>();
            enemy.TakeDamage(currentDamage);
            ApplyPierce();
            Debug.Log($"Enemy take {currentDamage} Damage");
        }
    }

    void ApplyPierce()
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }

    }
}
