
using UnityEngine;

public class Rules
{
    public static bool Turn = false;
    public static bool shooting = true;
    public static float resetPointX = 0f;
    public static float resetPointY = 4.88f;
    

    public  static void Reset(GameObject blue,GameObject red,GameObject bullet)
    {
        blue.transform.position = new Vector2(resetPointX,resetPointY);
        red.transform.position = new Vector2(resetPointX,-resetPointY);
        bullet.transform.position = new Vector2(0,0);
        shooting = !shooting;
    }
}
