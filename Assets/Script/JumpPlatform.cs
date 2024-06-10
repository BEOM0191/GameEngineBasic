using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public float jumpForce = 10f; // 플레이어를 튕겨나가는 힘

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 충돌한 대상이 Player라면
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>(); // Player의 Rigidbody2D 컴포넌트 가져오기
            if (playerRb != null)
            {
                Vector2 jumpVector = Vector2.up * jumpForce; // 플레이어를 위로 튕기는 힘 벡터 생성
                playerRb.velocity = jumpVector; // 플레이어에게 힘 적용
            }
        }
    }
}
