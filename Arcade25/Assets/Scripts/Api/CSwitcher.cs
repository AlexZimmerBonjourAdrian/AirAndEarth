using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSwitcher : MonoBehaviour {

    /*
    public enum _SelectStage
    {

    }
    public _SelectStage _Level;
    */
   
	// Use this for initialization
	
    public void SetState(string _name)
    {
        CGameManager.INST.LoadLevelAssync(_name);
    }
   
}
