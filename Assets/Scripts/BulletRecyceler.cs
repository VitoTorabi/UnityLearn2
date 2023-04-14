
using UnityEngine;

public class BulletRecyceler : MonoBehaviour
{
    public GameObject blue;
    public GameObject bulletGlobal;
    public GameObject red;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>() ;
        if (bullet != null) {
            Rules.Reset(blue,red,bulletGlobal);
            bullet.gameObject.SetActive(false);
        }
    }
}
