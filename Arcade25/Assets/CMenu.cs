using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenu : MonoBehaviour {

    public GameObject MenuOptions;
	// Use this for initialization
	void Start ()
    {
        MenuOptions = Resources.Load<GameObject>("MenuOptions");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void ExitMenu()
    {
        Application.Quit();
    }
    public void SetActive()
    {
       gameObject.SetActive(false);
    }
    public void Options()
    {
        GameObject GameObj = (GameObject)Instantiate(MenuOptions,Vector2.zero,Quaternion.identity);
        COptionMenu Menu = GameObj.GetComponent<COptionMenu>();
    }
}
