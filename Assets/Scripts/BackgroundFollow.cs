using UnityEngine;
[AddComponentMenu("TienCuong/BackgroundFollow")]
public class BackgroundFollow : MonoBehaviour
{
    public Transform virtualCamera; // Gắn Transform của Cinemachine Virtual Camera
    public float parallaxEffect = 0.5f; // Hiệu ứng parallax

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (virtualCamera == null)
        {
            Debug.LogError("Vui lòng gán Transform của Cinemachine Virtual Camera vào script.");
            return;
        }

        lastCameraPosition = virtualCamera.position;
    }

    void LateUpdate()
    {
        if (virtualCamera == null) return;

        // Tính khoảng cách camera di chuyển
        Vector3 deltaMovement = virtualCamera.position - lastCameraPosition;

        // Di chuyển background
        transform.position += new Vector3(deltaMovement.x * parallaxEffect,0, 0);

        // Cập nhật vị trí camera cuối cùng
        lastCameraPosition = virtualCamera.position;
    }
}
