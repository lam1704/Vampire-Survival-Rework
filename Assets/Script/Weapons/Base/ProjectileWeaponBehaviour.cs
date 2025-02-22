using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSecond;
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
}
