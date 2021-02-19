using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CManagerBall : MonoBehaviour {

    public static CManagerBall INST
    {
        get
        {
            if (_inst != null)
            return _inst;
                GameObject obj = new GameObject("CManagerBall");
                return obj.AddComponent<CManagerBall>();
        }
    }
    private static CManagerBall _inst;
    private List<CBall> _BallList;
    private GameObject _BallAsset;
    private Rigidbody _rigidbody;
    private float _Speed = 1;
    private List<CBall> _listObjectsBalls;
    public Transform PostPlayer;

    private void Awake()
    {
        _inst = this;
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        _BallAsset = Resources.Load<GameObject>("Ball");
        _BallList = new List<CBall>();
    }
    private void Update()
    {
        for(int i = _BallList.Count - 1; i>= 0; i--)
        {
            if (_BallList[i] == null)
                _BallList.RemoveAt(i);
        }
        
    }
    public void CreateBall(Vector3 aPos,Vector3 Vel,Quaternion aRotation)
    {
        GameObject obj = (GameObject)Instantiate(_BallAsset, aPos, aRotation);
        CBall newBall = obj.AddComponent<CBall>();
        newBall.AddVel(Vel);
        Destroy(obj, 3f);
        _BallList.Add(newBall);
    }
    public void SetPrefab(string aResources)
    {
        _BallAsset = Resources.Load<GameObject>(aResources);
        
    }
    public GameObject GetObject()
    {
        return _BallAsset;
    }


}
