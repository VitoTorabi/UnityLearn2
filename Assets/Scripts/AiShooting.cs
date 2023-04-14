using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AiShooting : MonoBehaviour
{
    public  GameObject bullet;
    public GameObject firepoint;
    public float speed = 10.0f;
    public Quaternion rotation;
    private float aim = 0;
    private float delta;
    private Random rnd;
    [FormerlySerializedAs("PlayerRed")] public GameObject playerRed;
    public float time = 3f;
    private float rotate;
    public float reset = 0.1f;
    private float counter ;
    public int turnNum= 2;
    private int turnCount;
    private float to;
    
    // Start is called before the first frame update
    void Start()
    {
        rotate = reset;
        counter = time;
        turnCount = turnNum;
    }

    // Update is called once per frame
    void Update()
    {
       
        
//        if (!Rules.Turn && !bullet.activeSelf )
//            Rules.Reset(transform.parent.gameObject, GameObject.Find("PlayerRed"), bullet);
        if (!Rules.Turn && !bullet.activeSelf )
        {
            rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                if (aim == 0)
                    aim = Random.Range(100, 260);
                delta=transform.rotation.eulerAngles.z;
                
                if (turnCount> 0)
                {
                    
                    to = turnCount == 2 ? 260 : 100;
                    
                    if (delta - to > 0)
                        delta -= 1;
                    else
                        delta += 1;
                    rotate -= Time.deltaTime;
                    if (rotate<0)
                    {
                        rotate = reset;
                        rotation = Quaternion.Euler(new Vector3(0, 0, delta));
                        transform.rotation = rotation;
                    }

                    if (Math.Abs(delta - to) < 1)
                        turnCount--;

                }
                else
                {
                    if (Math.Abs(delta - aim) > 5)
                    {

                        if (delta - aim > 0)
                            delta -= 1;
                        else
                            delta += 1;

                        rotate -= Time.deltaTime;
                        if (rotate < 0)
                        {
                            rotate = reset;
                            rotation = Quaternion.Euler(new Vector3(0, 0, delta));
                            transform.rotation = rotation;
                        }
                    }
                    else
                    {
                        counter = time;
                        rotation = Quaternion.Euler(new Vector3(0, 0, aim));
                        transform.rotation = rotation;
                        aim = 0;
                        turnCount = turnNum;
                        Weapon.Shoot(firepoint.transform, bullet, speed);
                    }
                }
            }
        }
    }
}
