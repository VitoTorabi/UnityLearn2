using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speed=10;
    public float slow=0.9f;


    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float val)
    {
        speed = val;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(rigidbody2d.velocity);
    }


    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.name == "shield") {
            speed *= slow;
            rigidbody2d.velocity = transform.up * speed;
        }
    }
  
}
