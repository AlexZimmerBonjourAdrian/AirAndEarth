using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpiderTank : MonoBehaviour {

    [SerializeField]
    public float _SpeedTanck= 10f;
    [SerializeField]
    private float _TimeToShoot = 260f;
    private Rigidbody _Rigidbody;
    // Use this for initialization
    private const int STATE_MOVE = 0;
    private const int STATE_RELOADED = 1;
    private const int STATE_DYNG = 2;
    private const int STATE_DEATH = 3;
    private int _State = 0;
    public float _offset = 3f;
    public float _Speed = 5f;
    public float _TimeMoveSpiderTank = 260f;
    public float _TimeDyng = 200f;
    
    private void Awake()
    {
        _State = 0;
        _Rigidbody = GetComponent<Rigidbody>();
        _TimeToShoot = _TimeToShoot * Time.deltaTime;
        
    }
    private void PrevState()
    {
        if (_State == STATE_MOVE)
        {

        }
        else if (_State == STATE_RELOADED)
        {

        }
        else if (_State == STATE_DYNG)
        {

        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    private void SetState(int aState)
    {
        _State = aState;
        PrevState();
        if (_State == STATE_MOVE)
        {

        }
        if (_State == STATE_MOVE)
        {
        }
        else if (_State == STATE_DYNG)
        {

        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    private void MoveTanck()
    {
        transform.position += -Vector3.forward * (_SpeedTanck * Time.deltaTime);
    }
	// Update is called once per frame
	void Update ()
    {
        if (_State == STATE_MOVE)
        {
            MoveTanck();
            _TimeToShoot--;
            if (_TimeToShoot <= 0f)
            {  
                Shoot();
              _TimeToShoot = 260f;
                SetState(STATE_RELOADED);
            }
        }
        else if (_State == STATE_RELOADED)
        {
            _TimeMoveSpiderTank--;
           if(_TimeMoveSpiderTank <= 0f)
            {
                _TimeMoveSpiderTank = 260f;
                SetState(STATE_MOVE);
            } 
        }
        else if (_State == STATE_DYNG)
        {
            _TimeDyng--;
            if (_TimeDyng <= 0f)
            {
                SetState(STATE_DEATH);
            }
        }
        else if (_State == STATE_DEATH)
        {
            Destroy(gameObject);
        }
    }
    private void Shoot()
    {
        CManagerBall.INST.SetPrefab("Bullet");
        Vector3 VelPos = (Vector3.forward * _Speed) * Time.deltaTime;
        CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * _offset), -VelPos);
    }
    void OnCollisionEnter(Collision aCollision)
    {
        if (aCollision.gameObject.tag == "Player")
        {
            SetState(STATE_DYNG);
        }
    }
}
