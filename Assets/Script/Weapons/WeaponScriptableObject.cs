using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName ="ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value;  }
    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] private float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] private float cD;
    public float CD { get => cD; private set => cD = value; }

    [SerializeField] private int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
