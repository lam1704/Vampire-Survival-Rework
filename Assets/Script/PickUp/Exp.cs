using UnityEngine;

public class Exp : MonoBehaviour, ICollectible
{
    [SerializeField] private int minExpGranted;
    [SerializeField] private int maxExpGranted;
    public void Collect()
    {

        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        if (minExpGranted > 0 || maxExpGranted > 0)
        {
            int expGranted = Random.Range(minExpGranted, maxExpGranted);
            player.IncreaseExp(expGranted);
            Debug.Log($"Player gained {expGranted} exp");
        }
        else
        {
            player.LevelUp();

        }
        Destroy(gameObject);
    }
}
