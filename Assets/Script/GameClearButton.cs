using UnityEngine;

public class GameClearButton : MonoBehaviour
{
    public BossDragon bossDragon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossDragon.Die();
            Debug.Log("Button Pressed");
        }
    }
}
