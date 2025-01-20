using UnityEngine;
[AddComponentMenu("TienCuong/MovePlayer")]
public class MovePlayer : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Animator animator;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f; // Tốc độ di chuyển ngang
    public float jumpForce = 10f; // Lực nhảy
    private int jumpCount;
    public int maxJumb = 2;
    private bool isGrounded;

    public Sprite idleSprite;
    public Sprite jumpSprite;
    public Sprite dropSprite;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpCount = maxJumb;
    }

    void Update()
    {
        // Xử lý di chuyển qua trái/phải
        float moveX = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveX * moveSpeed, rb2d.linearVelocity.y);

        // Quay đầu nhân vật dựa trên hướng di chuyển
        if (moveX > 0) 
        {
            transform.localScale = new Vector3(5, 5, 1);
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }

        // Kích hoạt Animation Run nếu di chuyển
        animator.SetBool("isRunning", moveX != 0);

        // Xử lý nhảy
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpCount--;
            animator.enabled = false;
            spriteRenderer.sprite = jumpSprite;
            return;
        }

        // Kiểm tra trạng thái rơi (fall)
        if (rb2d.linearVelocity.y < 0 && !isGrounded)
        {
            animator.enabled = false;
            spriteRenderer.sprite = dropSprite; // Đổi sang sprite khi đang rơi
            return;
        }

        // Nếu nhân vật chạm đất
        if (isGrounded)
        {
            animator.enabled = true;
            spriteRenderer.sprite = idleSprite; // Quay lại sprite mặc định
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu nhân vật chạm đất trả lại số lần nhảy
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumb;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Nếu nhân vật chạm đất trả lại số lần nhảy
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

