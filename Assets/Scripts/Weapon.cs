using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    //public Transform firePoint;
    //Rigidbody2D rigidbody2d;
    public static GameObject Bullet = GameObject.Find("bullet");

    public static void Shoot(Transform firePoint,  GameObject prefab, float speed)
    {
        Rigidbody2D rigidbody2d;

        if (null == Bullet) {
            Bullet = GameObject.Instantiate(prefab, firePoint.position, firePoint.rotation);
            rigidbody2d = Bullet.GetComponent<Rigidbody2D>();
            rigidbody2d.velocity = Bullet.transform.up * speed;
            Bullet.GetComponent<Bullet>().SetSpeed(speed);
        }else {
#pragma warning disable CS0618 // Type or member is obsolete
            if (Bullet.active == false) {
#pragma warning restore CS0618 // Type or member is obsolete
                Bullet.SetActive(true);
                Bullet.transform.position = firePoint.position;
                Bullet.transform.rotation = firePoint.rotation;
                rigidbody2d = Bullet.GetComponent<Rigidbody2D>();
                rigidbody2d.velocity = Bullet.transform.up * speed;
                Bullet.GetComponent<Bullet>().SetSpeed(speed);
                Rules.Turn = !Rules.Turn;
            }

        }
    }

    public static void Block(GameObject bullet,float shift)
    {
        Quaternion rotation;
        if (shift > 20) shift = 20f;
        float rotationDigree = bullet.transform.rotation.eulerAngles.z + shift;
        //if(Mathf.Abs(rotationDigree) < 170 | Mathf.Abs(rotationDigree)-180 <170)
            rotation = Quaternion.Euler(new Vector3(0, 0, 180-rotationDigree));
        bullet.transform.rotation = rotation;
        Rigidbody2D rigidbody2d = bullet.GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = bullet.transform.up * bullet.GetComponent<Bullet>().GetSpeed();

        Debug.Log(bullet.transform.rotation.eulerAngles.z+"---" + shift);
        Vector3 pos = bullet.transform.position;
        //bullet.transform.position = pos + new Vector3(shift* 0.1f, 0, 0);
        //Debug.Log(Rules.Turn);
    }
    
}
