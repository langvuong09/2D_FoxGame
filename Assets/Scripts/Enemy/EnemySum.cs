using System.Collections;

using TMPro;

using UnityEngine;

[AddComponentMenu("TienCuong/EnemySum")]
public class EnemySum : MonoBehaviour
{
    public GameObject father;
    public TextMeshProUGUI textDiamondSum;

    void Start()
    {
        if (father == null)
        {
            father = this.gameObject;
        }

        count();
    }

    private void count() 
    {
            int childCount = father.transform.childCount;
            textDiamondSum.text = childCount.ToString();
    }
}
