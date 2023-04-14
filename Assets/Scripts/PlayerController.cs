using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
   
    public float seprate = -3;
    public float speed = 100f;
    [FormerlySerializedAs("Kspeed")] public float kspeed = 10f;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Vector3 relative;
    private Vector3 gunPos;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Rules.resetPointX, -Rules.resetPointY);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            if (touchPosition.y < seprate && !(Rules.shooting && Rules.Turn)) { 
                Move.MOveToPoint(touchPosition,transform.position,rigidbody2d,speed);
            }
            else 
                rigidbody2d.velocity = Vector2.zero;
            if (touch.phase == TouchPhase.Ended)
                rigidbody2d.velocity = Vector2.zero;
        }
        else {
            float horizontal = Input.GetAxis("Horizontal");

            Vector2 position = rigidbody2d.position;
            Vector2 move = new Vector2(horizontal, 0);
            position = position + move * kspeed * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }

        //Debug.Log(touchPosition + "/" + rigidbody2d.velocity);
    }
}
