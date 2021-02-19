using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTankControl : MonoBehaviour
{

    public Vector3 _worldSpeed = Vector3.forward * 2;

    public float _horizontalSpeed = 5;
    private Vector3 _localVelocity;
    private Transform _tankBase;
    public float _rotationForce = 5;
    public float _rotationSpeedThreshold = 0.2f;
    private float _SpeedBullet=600000f;
    public float _offset = 50f;
    public float _RocketSpeed = 4000f;
    private const int STATE_IDLE = 0;
    private const int STATE_WALKING = 1;
    private const int STATE_DEATH = 2;
    private int _State = 0;
    private GameObject _AssetPlayer;
    private float _Health = 100f;
    private float _Resistence = 9f;
    private float _Speed = 20f;
    private Quaternion _StartRotation;
    
    
    void Start()
    {
        _tankBase = GetComponent<Transform>();
        _StartRotation = transform.rotation;
        //_tankBase = GetComponent<Transform>();
        _AssetPlayer = GetComponent<GameObject>();
        _State = 0;
    }
    
    private void SetState(int aState)
    {

        _State = aState;
        
        if (_State == STATE_IDLE)
        {
            
        }
        else if (_State == STATE_WALKING)
        {

        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    public void SetHealth(float aHealth)
    {
        _Health = aHealth;
    }
    public float GeatHealth()
    {
        return _Health;
    }
    void Update()
    {
       
        if (_localVelocity == Vector3.zero)
        {
            RotationIdle();
        }
        
        Debug.Log(_State);
        if (_State == STATE_IDLE)
        {
            Shoot();
            _localVelocity = Vector3.zero;
          
            if (CKeyCode.firstPress(CKeyCode._KEY_A) || CKeyCode.firstPress(CKeyCode.KEY_W) || CKeyCode.firstPress(CKeyCode._KEY_D) || CKeyCode.firstPress(CKeyCode._KEY_S))
            {
                SetState(STATE_WALKING);
            }
        }
        else if (_State == STATE_WALKING)
        {
            if (!CKeyCode.Pressed(CKeyCode._KEY_A) && !CKeyCode.Pressed(CKeyCode.KEY_W) && !CKeyCode.Pressed(CKeyCode._KEY_D) && !CKeyCode.Pressed(CKeyCode._KEY_S))
            {
                SetState(STATE_IDLE);
            }
           
            MoveHorizontal();
        }
        else if (_State == STATE_DEATH)
        {
            _AssetPlayer.SetActive(false);
        }
    }
    public void MoveHorizontal()
    {
       
        //transform.position += _localVelocity * Time.deltaTime;
        /*
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);
        _localVelocity = input * _horizontalSpeed;
        */
        if (CKeyCode.Pressed(CKeyCode._KEY_A))
        {
            Rotation();
            _localVelocity += Vector3.right * (-_horizontalSpeed * Time.deltaTime);
        }
          if (CKeyCode.Pressed(CKeyCode._KEY_D))
        {
            Rotation();
           _localVelocity += Vector3.right * (_horizontalSpeed * Time.deltaTime);
        }
         if (CKeyCode.Pressed(CKeyCode._KEY_S))
        {
            
             transform.position += Vector3.forward * (-_horizontalSpeed * Time.deltaTime);
        }
         if (CKeyCode.Pressed(CKeyCode.KEY_W))
        {
            Rotation();
            _localVelocity += Vector3.forward * (_horizontalSpeed * Time.deltaTime);
        }
       
    }
    public void Shoot()
    {

        //Primarie Shoot
        if (CKeyCode.firstPress(CKeyCode._KEY_SPACE))
        {
            
            CManagerBall.INST.SetPrefab("Bullet");
            Vector3 _Vel = new Vector3(0, 0, Vector3.forward.z); 
            Vector3 VelPos = (_Vel * _SpeedBullet);
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * _offset), VelPos *Time.deltaTime,transform.rotation);
        
        }
        //Secundarie Shoot
        else if (CKeyCode.firstPress(CKeyCode._KEY_SHIFT))
        {
            CManagerBall.INST.SetPrefab("PlayerRocket");
             Vector3 _Vel = new Vector3(0, 0, Vector3.forward.z);
            Vector3 VelPos = (_Vel * _RocketSpeed) * Time.deltaTime;
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * _offset), VelPos,transform.rotation);
        }

    }
    private void Rotation()
    {
        transform.position += _localVelocity * Time.deltaTime;

        //		if (_localVelocity.magnitude > _rotationSpeedThreshold * _horizontalSpeed) {
        _tankBase.rotation = Quaternion.Slerp(
          _tankBase.rotation,
            Quaternion.LookRotation((_worldSpeed + _localVelocity).normalized),
            _rotationForce * Time.deltaTime);
        //		}
    }
    private void RotationIdle()
    {
        //transform.position += _localVelocity * Time.deltaTime;

        //		if (_localVelocity.magnitude > _rotationSpeedThreshold * _horizontalSpeed) {
        transform.rotation = Quaternion.Slerp(transform.rotation, _StartRotation, _rotationForce * Time.deltaTime);
    }
    void OnCollisionEnter(Collision aCollision)
    {
        if (aCollision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void ResetRotation()
    {
        transform.rotation = _StartRotation;
    }
   
    
}



