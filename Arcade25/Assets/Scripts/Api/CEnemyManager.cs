using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyManager : MonoBehaviour {

    private GameObject _AssetEnemy;
    private List<CGenericEnemy> _EnemyList;
    public Transform _Pos;
    public static CEnemyManager INST
    {
        get
        {
            if (_inst != null)
                return _inst;
            
                GameObject obj = new GameObject("EnemyManager");
                return  obj.AddComponent<CEnemyManager>();
            
        }
    }
    private static CEnemyManager _inst;
    

    void Awake()
    {
        _inst = this;
        _EnemyList = new List<CGenericEnemy>();

    }
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = _EnemyList.Count - 1; i >= 0; i--)
        {
            if (_EnemyList[i] == null)
                _EnemyList.RemoveAt(i);
        }
    }
    
}
