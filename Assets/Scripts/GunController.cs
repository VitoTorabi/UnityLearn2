using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float seprate = -2.7f;
    public float speed = 10.0f;
    private float angle;
    private bool aiming;
    private Vector3 touchPosition;
    private Vector3 relativePos;
    private Vector3 gunPos;
    private float aim;
    private float delta;
    private float move;
    private Vector3 relative;
    public  GameObject bullet;
    public GameObject firepoint;


    public Quaternion rotation;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0) {
            aiming = false;
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            gunPos = transform.position;

            if (touchPosition.y > seprate ) {
                aiming = true;
                relative = touchPosition - gunPos;
                aim = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg -90;
                angle = transform.rotation.z;
                delta = aim - angle;
                move = Mathf.Abs(delta) / delta;
                if (Mathf.Abs(delta) > 2) {
                    //rotation = Quaternion.Euler(new Vector3(0, 0, angle + speed * move * Time.deltaTime));
                    rotation = Quaternion.Euler(new Vector3(0, 0,aim));
                    transform.rotation = rotation;
                }

            }
            if (touch.phase == TouchPhase.Ended && Rules.Turn) {
                if (aiming) {
                    Weapon.Shoot(firepoint.transform, bullet, speed);
                    
                }
            }
        }
        if (Weapon.Bullet != null)
            if(Mathf.Abs(Weapon.Bullet.GetComponent<Rigidbody2D>().velocity.y )< 1) 
                Weapon.Bullet.SetActive(false);
        
        
    }
}
