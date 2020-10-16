using UnityEngine;
using System.Collections;

public class CMouse : MonoBehaviour {


    // Use this for initialization
    public static bool firstPress()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool Pressed()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool Release()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            return true;

        }
        else
        {
            return false;
        }
    }
    public static Vector3 getPos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.y *= -1;
        pos.z = 0;
        return pos;
    }
}
