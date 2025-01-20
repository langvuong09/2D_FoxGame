using System;
using System.Collections;

using UnityEngine;
[AddComponentMenu("TienCuong/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
