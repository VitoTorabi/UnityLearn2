
using UnityEngine;

public class Move {
    public static void MOveToPoint(Vector3 point,Vector3 self,Rigidbody2D rigidbody2d, float speed)
    {
        Vector3 direction;
        direction = (point - self);
        rigidbody2d.velocity = new Vector2(direction.x, 0) * speed;
    }
}
