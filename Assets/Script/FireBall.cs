using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float damage = 100f; // 벽돌이 플레이어에게 주는 데미지
    private Vector2 originalPosition;
    private Rigidbody2D rb;

    void Start()
    {
        // 시작 위치 저장
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 벽돌이 떨어지도록 중력을 적용
        rb.gravityScale = 1; // 중력을 활성화
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetPositionImmediately();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            ResetPositionImmediately();
        }
    }

    void ResetPositionImmediately()
    {
        rb.gravityScale = 0; // 중력을 비활성화하여 떨어지지 않도록 함
        rb.velocity = Vector2.zero; // 속도를 초기화
        transform.position = originalPosition; // 원래 위치로 이동
        rb.gravityScale = 1; // 중력을 다시 활성화
    }
}
