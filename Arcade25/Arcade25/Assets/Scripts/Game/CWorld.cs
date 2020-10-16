using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWorld : MonoBehaviour {

    private Rigidbody _Rigidbody;
    private const float _SpeedWorld = 10f;
    private GameObject _AssetGameObject;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }
	// Use this for initialization
    /*
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    */
    private void SpeedMap()
    {
        transform.position += Vector3.forward * (_SpeedWorld * Time.deltaTime);  
    }
}
