using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public float CD;
    public float currentCD;
    [SerializeField] public int pierce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCD = CD;
    }

    // Update is called once per frame
    void Update()
    {
        currentCD -= Time.deltaTime;
        if (currentCD < 0) {
            Attack();
        }
    }
    void Attack()
    {
        currentCD = CD;
    }
}
