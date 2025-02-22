using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);

            // Flip the sprite based on movement direction
            if (pm.moveDir.x > 0)
            {
                sr.flipX = false;
            }
            else if (pm.moveDir.x < 0)
            {
                sr.flipX = true;
            }
        }
        else
        {
            am.SetBool("Move", false);
        }
    }
}
