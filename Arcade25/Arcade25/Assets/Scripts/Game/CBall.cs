using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBall : CManagerBall {

  
    private Rigidbody _Rigidbody;
    private Vector3 Vel;
	// Use this for initialization
     void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }
    public void AddVel(Vector3 Vel)
    {
        _Rigidbody.AddForce(Vel, ForceMode.Impulse);
    }
    // Update is called once per frame
   

}
