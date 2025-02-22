using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    [SerializeField] private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, moveSpeed * Time.deltaTime);
    }
}
