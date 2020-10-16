using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alex.viewCamera
{

    public class CCameraControl : MonoBehaviour
    {
        public bool _smothed;
        public float _smoothTime = 5;
        public Transform _charPivot;
        public Transform _CamPivot;
        //public static CCameraControl _inst;
        [Header("Camera Value")]
        private Quaternion _CharterTargetRot;
        private Quaternion _CameraTargerRot;
        private Vector2 SensivilityMouse;
        private float _minClampX;
        private float _maxClampX;
        public float _CamOffset = 2.0f;
        private GameObject _CameraTarger;
        private Vector3 _Vel;
        private Vector3 _CamBasePosition;
        private bool _instEnabled = true;
        // Use this for initialization
        public struct PlayerInputs
        {
            public Vector2 Movement;
            public Vector2 Aim;
            public bool FireDown;
        }
        public void Awake()
        {
            _CamBasePosition = _CameraTarger.transform.localPosition;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            //_inst = this;
        }
        void Start()
        {

        }
        public GameObject GetCamTarget()
        {
            return _CameraTarger;
        }

        // Update is called once per frame
        public Vector3 GetAnim()
        {
            return _CameraTarger.transform.forward;
        }
        public void SetAnim(Vector3 aim)
        {
            _charPivot.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(aim.z, aim.x) * Mathf.Rad2Deg + 90, 0f));
        }
        public void LookRotation(PlayerInputs input,Transform Charter,Transform Camera)
        {
            _CharterTargetRot *= Quaternion.Euler(0f, input.Aim.x, 0f);
            _CameraTargerRot *= Quaternion.Euler(-input.Aim.y, 0f, 0f);
            _CameraTargerRot = ClampRotationAroundXAxis (_CameraTargerRot);

            if (_smothed)
            {
                Charter.localRotation = Quaternion.Slerp(Charter.localRotation, _CharterTargetRot, _smoothTime * Time.deltaTime);
                Camera.localRotation = Quaternion.Slerp(Camera.localRotation, _CameraTargerRot, _smoothTime * Time.deltaTime);
            }
            else
            {
                Charter.localRotation = _CharterTargetRot;
                Camera.localRotation = _CameraTargerRot;
            }
        }
        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;
            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
            angleX = Mathf.Clamp(angleX, _minClampX, _maxClampX);
            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
            return q;
        }
    }
    
}
