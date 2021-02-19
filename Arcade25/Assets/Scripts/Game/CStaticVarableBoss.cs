using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStaticVarableBoss : MonoBehaviour {

    public static float _SpeedEnemy = 30F;
    public static float _TimeState = 30f;
    public static float _state;
    public static CStaticVarableBoss _inst;
    public static float _HealthBoss = 2500;
    private static CStaticVarableBoss INST
    {
        get
        {
            if (_inst != null)
           return _inst;
            GameObject obj = new GameObject("CStaticVarableBoss");
             return obj.AddComponent<CStaticVarableBoss>();
        }
        
    }

	// Use this for initialization
	void Start ()
    {
        _inst = this;
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }

	}
	
	// Update is called once per frame
	
}
