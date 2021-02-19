using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRedRocket : MonoBehaviour {

    private GameObject Rocket;
    public float _SpeedRocket = 5f;
    private const int STATE_FLY = 0;
    private const int STATE_DEATH = 1;
    private int _State = 1;
    private Rigidbody _Rigidbody;


	// Use this for initialization
	void Start ()
    {
        _State = 1;
        _Rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_State == STATE_FLY)
        {
            MovementRocket();
        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    public void SetState(int aState)
    {
        _State = aState;
        if (_State == STATE_FLY)
        {

        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    void OnCollisionEnter(Collision aCollisionEnemy)
    {
        if (aCollisionEnemy.gameObject.tag == "Player")
        {

        }
    }
    public void MovementRocket()
    {
       // _SpeedRocket = aSpeedRocket * Time.deltaTime;
        transform.position += Vector3.forward * _SpeedRocket; 
    }
}
