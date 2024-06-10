using UnityEngine;
using System.Collections;

public class Fallrock : MonoBehaviour
{
    public float resetDelay = 1.0f; // 벽돌이 다시 떨어지기 전에 대기하는 시간
    public float damage = 100f; // 벽돌이 플레이어에게 주는 데미지
    private Vector2 originalPosition;
    private Rigidbody2D rb;
    private bool isfall = false;

    void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isfall)   // 벽돌이 떨어지도록 중력을 적용
        {
            rb.gravityScale = 1; // 중력을 활성화
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(ResetPosition());
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    IEnumerator ResetPosition()
    {
        isfall = true;
        rb.gravityScale = 0; // 중력을 비활성화하여 떨어지지 않도록 함
        rb.velocity = Vector2.zero; // 속도를 초기화
        yield return new WaitForSeconds(resetDelay);
        transform.position = originalPosition; // 원래 위치로 이동
        isfall = false;
        rb.gravityScale = 1; // 중력을 다시 활성화
    }
}
