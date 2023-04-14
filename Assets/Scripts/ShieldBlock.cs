
using UnityEngine;

public class ShieldBlock : MonoBehaviour
{
    public float speedShiftInReflect = 2f;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        float rotationDigree = 0.0f;
        Quaternion rotation;
        Rigidbody2D rigidbody2d = transform.parent.GetComponent<Rigidbody2D>();
        Rigidbody2D shieldRigidbody2d2 = transform.parent.GetComponent<Rigidbody2D>();
        if (bullet != null) {
            Weapon.Block(bullet.gameObject,shieldRigidbody2d2.velocity.x * speedShiftInReflect);
        }
    }
}
