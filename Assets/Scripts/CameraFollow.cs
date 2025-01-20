using UnityEngine;
[AddComponentMenu("TienCuong/CameraFollow")]
public class CameraFollow : MonoBehaviour
{
    public Transform target; // Nhân vật mà camera theo dõi
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private bool isPlayerDead = false; // Biến kiểm tra trạng thái nhân vật

    void LateUpdate()
    {
        if (target != null && !isPlayerDead)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void StopFollowing()
    {
        isPlayerDead = true; // Ngừng theo dõi nhân vật
    }
}
