using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneControl : MonoBehaviour {

    private Transform _TransformCrosshair;
    private GameObject _CrosshairObject;
    public Vector3 _worldSpeed = Vector3.forward * 2;

    public float _horizontalSpeed = 10;
    private Vector3 _localVelocity;

    public Transform _planeBase;
    public float _rotationAngle = 15f;
    public float _rotationForce = 5;
    public float _SpeedBullets = 145f;
    public float _SpeedRocketsPlayer = 145f;
    private float Offset = 30f;
    private Rigidbody _Rigidbody;
    private Quaternion _StartRotation;
    private float _Offset = 0.2f;


   
    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _StartRotation = transform.rotation;
        _TransformCrosshair = gameObject.transform.GetChild(0);
        //_CrosshairObject = gameObject.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        Debug.Log(_SpeedBullets.ToString() + _SpeedRocketsPlayer.ToString());
        transform.position += _localVelocity * Time.deltaTime;

        //		if (_localVelocity.magnitude > _rotationSpeedThreshold * _horizontalSpeed) {
        _planeBase.rotation = Quaternion.Slerp(
            _planeBase.rotation,
            //			Quaternion.LookRotation ((_worldSpeed + _localVelocity).normalized),
            Quaternion.Euler(new Vector3(0, 0, _localVelocity.x / -_horizontalSpeed) * _rotationAngle),
            _rotationForce * Time.deltaTime);
        //		}
        MoveHorizontal();
        Shoot();
    }
    private void MoveHorizontal()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (input.magnitude > 1)
            input.Normalize();
        _localVelocity = input * _horizontalSpeed;
        //transform.position += _localVelocity * Time.deltaTime;
     
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
            
            transform.position += Vector3.forward * (_horizontalSpeed * Time.deltaTime);
        }
    }
    private void TransformPositionCrosshair()
    {
       _TransformCrosshair.position = Vector3.Lerp(transform.position, new Vector3(0,_localVelocity.x / - _horizontalSpeed, _localVelocity.x /- _horizontalSpeed) * _Offset,50f*Time.deltaTime);
    }
    private void Shoot()
    {
        //Primarie Shoot
        if (CKeyCode.firstPress(CKeyCode._KEY_SPACE))
        {
            CManagerBall.INST.SetPrefab("Balls");
            Vector3 VelPos = (Vector3.forward * _SpeedBullets) * Time.deltaTime;
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * Offset), VelPos,transform.rotation);
        }
        //Secundarie Shoot
        if (CKeyCode.firstPress(CKeyCode._KEY_SHIFT))
        {
            CManagerBall.INST.SetPrefab("PlayerRocket");
            Vector3 VelPos = (Vector3.forward * _SpeedRocketsPlayer) * Time.deltaTime;
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * Offset), VelPos,transform.rotation);
        }
    }
    private void Rotation()
    {
        // transform.position += _localVelocity * Time.deltaTime;

        //		if (_localVelocity.magnitude > _rotationSpeedThreshold * _horizontalSpeed) {
        _planeBase.rotation = Quaternion.Slerp(
          _planeBase.rotation,
            Quaternion.Euler(new Vector3(0, _localVelocity.x / -_horizontalSpeed, _localVelocity.x / -_horizontalSpeed) * _rotationAngle),
            _rotationForce * Time.deltaTime);
        
    }
    private void RotationIdle()
    {
        //transform.position += _localVelocity * Time.deltaTime;

        //		if (_localVelocity.magnitude > _rotationSpeedThreshold * _horizontalSpeed) {
        transform.rotation = Quaternion.Slerp(transform.rotation, _StartRotation, _rotationForce * Time.deltaTime);
    }
    public Vector3 GetTransformPlane()
    {
        return transform.position;
    }
    public void SetTransformPlane(Vector3 aVector)
    {
        transform.position = aVector;
    }


}
