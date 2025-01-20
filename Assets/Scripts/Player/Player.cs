using System.Collections;

using Unity.VisualScripting;

using UnityEngine;
[AddComponentMenu("TienCuong/Player")]
public class Player : MonoBehaviour
{
    public float timeDead = 1f;
    public float jumpForce = 10f;
    private Animator animator;
    private int isDeadPlayerId;
    private bool isDead = false;
    private MovePlayer movePlayer;
    private Rigidbody2D rb;
    private Collider2D[] colliders;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isDeadPlayerId = Animator.StringToHash("isDead");
        movePlayer = GetComponent<MovePlayer>();
        rb = GetComponent<Rigidbody2D>();
        colliders = GetComponents<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && (collision.contacts[0].normal.x > 0 || collision.contacts[0].normal.x < 0))
        {
            DeadPlayer();
        }
    }
    private void DeadPlayer()
    {
        if(isDead)
        {
            return;
        }
        isDead = true;
        animator.SetTrigger(isDeadPlayerId);
        movePlayer.enabled = false;
        if (Camera.main != null)
        {
            Camera.main.transform.position = Camera.main.transform.position;
        }
        rb.linearVelocity = Vector2.zero;// Đặt lại vận tốc để tránh lực kéo xuống ảnh hưởng
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);// Áp dụng lực đẩy lên  
        // Vô hiệu hóa tất cả collider của Player
        foreach (var col in colliders)
        {
            col.enabled = false;
        }
        StartCoroutine(DelayedGameOver());
    }
    IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.GameOver();
    }
}
