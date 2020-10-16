using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlaneControl : MonoBehaviour {

    public Vector3 _worldSpeed = Vector3.forward * 2;

    public float _horizontalSpeed = 10;
    private Vector3 _localVelocity;

    public Transform _planeBase;
    public float _rotationAngle = 15f;
    public float _rotationForce = 5;
    public float _SpeedBullets = 145f;
    public float _SpeedRocketsPlayer = 145f;
    private float Offset = 30f;




 
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
    }

    public void Shoot()
    {
        //Primarie Shoot
        if (CKeyCode.firstPress(CKeyCode._KEY_SPACE))
        {
            CManagerBall.INST.SetPrefab("Balls");
            Vector3 VelPos = (Vector3.forward * _SpeedBullets) * Time.deltaTime;
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * Offset), VelPos);
        }
        //Secundarie Shoot
        if (CKeyCode.firstPress(CKeyCode._KEY_SHIFT))
        {
            CManagerBall.INST.SetPrefab("PlayerRocket");
            Vector3 VelPos = (Vector3.forward * _SpeedRocketsPlayer) * Time.deltaTime;
            CManagerBall.INST.CreateBall((transform.position) + (Vector3.forward * Offset), VelPos);
        }
    }
    
    
}
