using UnityEngine;
[AddComponentMenu("TienCuong/EnemyAI")]
public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float minDistance = 0.2f;
    public float speedMove = 2.5f;
    private Transform target;
    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        target = pointB;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Pattrol();
    }

    private void Pattrol()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Enemt-death-Animation"))
        {
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, target.position) < minDistance)
        {
            target = target == pointB ? pointA : pointB;
            Vector2 scale = transform.localScale;
            scale.x = target == pointB ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        rb.linearVelocity = direction * speedMove;
    }
}
