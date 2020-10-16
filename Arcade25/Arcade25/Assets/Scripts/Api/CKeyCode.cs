using UnityEngine;
using System.Collections;

public class CKeyCode : MonoBehaviour {

    public static KeyCode KEY_W = KeyCode.W;
    public static KeyCode _KEY_S = KeyCode.S;
    public static KeyCode _KEY_D = KeyCode.D;
    public static KeyCode _KEY_A = KeyCode.A;
    public static KeyCode _KEY_F = KeyCode.F;
    public static KeyCode _KEY_Q = KeyCode.Q;
    public static KeyCode _KEY_C = KeyCode.Q;
    public static KeyCode _KEY_ALT = KeyCode.LeftAlt;
    public static KeyCode _KEY_Z = KeyCode.Z;
    public static KeyCode _KEY_X = KeyCode.X;
    public static KeyCode _KEY_TAB = KeyCode.Tab;
    public static KeyCode _KEY_R = KeyCode.R;



    public static KeyCode _KEY_UP_ARROW = KeyCode.UpArrow;
    public static KeyCode _KEY_DOWN_ARROW = KeyCode.DownArrow;
    public static KeyCode _KEY_RIGTH_ARROW = KeyCode.LeftArrow;
    public static KeyCode _KEY_LEFT_ARROW = KeyCode.RightArrow;

    public static KeyCode _KEY_SPACE = KeyCode.Space;
    public static KeyCode _KEY_ESCAPE = KeyCode.Escape;

    public static KeyCode _KEY_SHIFT = KeyCode.LeftShift;
     
    
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public static bool Pressed(KeyCode aKey)
    {
        return Input.GetKey(aKey);
    }
    public static bool firstPress(KeyCode aKey)
    {
        return Input.GetKeyDown(aKey);
    }
    public static bool Release(KeyCode aKey)
    {
        return Input.GetKeyUp(aKey);
    }
}
