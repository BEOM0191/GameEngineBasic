using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero; 

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
