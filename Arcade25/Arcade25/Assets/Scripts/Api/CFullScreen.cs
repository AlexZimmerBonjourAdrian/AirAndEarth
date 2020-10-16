using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFullScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void DebugSetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;

        //  o

        Screen.SetResolution(800, 600, fullscreen);

        //  o

        Resolution res = Screen.resolutions[0];
        Screen.SetResolution(res.width, res.height, fullscreen);
    }
}
