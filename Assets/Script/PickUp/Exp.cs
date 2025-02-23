using UnityEngine;

public class Exp : MonoBehaviour, ICollectible
{
    [SerializeField] private int expGranted;
    public void Collect()
    {
        PlayerStats player = GetComponent<PlayerStats>();
        if (expGranted > 0)
        {
            player.IncreaseExp(expGranted);

        }
        else
        {
            player.LevelUp();
        }
        Destroy(gameObject);
    }


}
