using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBall : MonoBehaviour {

    private int STATE_IDLE = 0;
    private int STATE_MOVE = 1;
    private int STATE_RELOAD = 2;
    private int STATE_DYNG = 3;
    private int STATE_DEAD = 4;
    private int STATE_HIT = 5;
    private int _state = 0;
    private Rigidbody _Rigidbody;
	// Use this for initialization
     void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }
    public void AddVel(Vector3 vel)
    {
        _Rigidbody.AddForce(vel, ForceMode.Impulse);
    }
    private void Shoot()
    {

    }
    private void SetState(int aState)
    {

    }
    private void PrevState()
    {
        
    }
    private void movementEnemy()
    {

    }
    
    // Update is called once per frame
   
}
