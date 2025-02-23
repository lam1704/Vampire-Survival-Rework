using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerScriptableObject playerScript;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDir;
    [HideInInspector] public Vector2 lastMovedDir;
    [HideInInspector] public float lastHorizontalDir;
    [HideInInspector] private float lastVerticalDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedDir = new Vector2 (1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if(moveDir.x != 0)
        {
            lastHorizontalDir = moveDir.x;
            lastMovedDir = new Vector2(lastHorizontalDir,0f);
        }
        if (moveDir.y != 0) 
        {
            lastVerticalDir = moveDir.y;
            lastMovedDir = new Vector2(0f, lastVerticalDir);
        }
        if (moveDir.x != 0 && moveDir.y != 0) 
        {
            lastMovedDir = new Vector2(lastMovedDir.x, lastMovedDir.y);
        }
    }
    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * playerScript.MoveSpeed, moveDir.y * playerScript.MoveSpeed);
    }
}
