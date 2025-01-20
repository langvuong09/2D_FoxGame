using UnityEngine;
[AddComponentMenu("TienCuong/DIamondManager")]
public class DIamondManager : MonoBehaviour
{
    public int diamondNumber = 1;
    public AudioClip diamondClip;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayEnemySfxMusic(diamondClip);
            GameManager.Instance.SetDiamond(diamondNumber);
            Destroy(gameObject);
        }
    }
}
