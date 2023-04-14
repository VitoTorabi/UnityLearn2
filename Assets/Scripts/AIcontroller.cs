using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : MonoBehaviour
{
    private GameObject bullet;
    Rigidbody2D rigidbody2d;
    private Vector2 movePoint;
    public float speed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("bullet");
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Rules.resetPointX, Rules.resetPointY);
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.active == true) {
            movePoint = bullet.transform.position;
            movePoint.x += -0.6f;
            Move.MOveToPoint(movePoint, transform.position,rigidbody2d,speed);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0,0);
        }
        
    }

    

    void CalculateDestination(GameObject bullet)
    {
        Vector3 pos = transform.position;
        pos.x = bullet.transform.position.x;
        transform.position = pos;
        //bullet.transform.rotation.eulerAngles.z
    }
    
}
