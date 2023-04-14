using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBlock : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        float rotationDigree = 0.0f;
        Quaternion rotation;
        Rigidbody2D rigidbody2d = transform.parent.GetComponent<Rigidbody2D>();
        Rigidbody2D shieldRigidbody2d2 = transform.parent.GetComponent<Rigidbody2D>();
        if (bullet != null) {
            Weapon.Block(bullet.gameObject,0);
        }
    }
}
