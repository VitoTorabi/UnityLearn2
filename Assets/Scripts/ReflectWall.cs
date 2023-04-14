using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectWall : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        float rotationDigree = 0.0f;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Rigidbody2D rigidbody2d;
        if (bullet != null) {
            rotationDigree = bullet.transform.rotation.eulerAngles.z;
            rotation = Quaternion.Euler(new Vector3(0, 0, -rotationDigree));
            bullet.transform.rotation = rotation;
            rigidbody2d = bullet.GetComponent<Rigidbody2D>();
            rigidbody2d.velocity = bullet.transform.up * bullet.GetComponent<Bullet>().GetSpeed();

           // Debug.Log(bullet.transform.rotation.eulerAngles.z);

        }


    }
}
