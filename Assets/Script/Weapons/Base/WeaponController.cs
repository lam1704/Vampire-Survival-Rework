using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public float CD;
    private float currentCD;
    [SerializeField] public int pierce;
    protected PlayerMovement pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
        currentCD = CD;
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
        currentCD = CD;
    }
}
