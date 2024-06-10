using UnityEngine;

public class BossDragon : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;
    private GameClearManager gameClearManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameClearManager = FindObjectOfType<GameClearManager>();
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetTrigger("Die");
            Destroy(gameObject);
            gameClearManager.ShowGameClearUI();
        }
    }
}
