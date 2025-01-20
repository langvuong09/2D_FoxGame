using Unity.VisualScripting;

using UnityEngine;

[AddComponentMenu("TienCuong/Enemy")]
public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public float timeDead = 0.07f;
    private Player player;
    private bool isDead = false;
    private Animator animator;
    private int isDeadEnemyId;
    private EnemyAI enemyAI;
    private PathedMoving pathedMoving;
    private void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
        isDeadEnemyId = Animator.StringToHash("isDead");
        enemyAI = GetComponent<EnemyAI>();
        pathedMoving = GetComponent<PathedMoving>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.contacts[0].normal.y < -0.3f)
        {
            DeadEnemy();
        }
    }

    private void DeadEnemy()
    {
        animator.SetTrigger(isDeadEnemyId);
        if (enemyAI != null) enemyAI.enabled = false;
        if (pathedMoving != null) pathedMoving.enabled = false;
        Invoke("DestroyEnemy", timeDead);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
