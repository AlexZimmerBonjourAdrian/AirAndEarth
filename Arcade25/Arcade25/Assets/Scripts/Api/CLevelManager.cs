using UnityEngine;
using System.Collections;

public class CLevelManager : MonoBehaviour {

    public Transform StartPositionPlane;
    public Transform StartPositionTank;
    private float _SpeedWorld = 3f;
    private GameObject _PlayerAsser;
    private GameObject _MenuPause;
    public static CLevelManager INST
    {
        get
        {
            if (_inst != null)
                return _inst;
            GameObject obj = new GameObject("CLevelManager");
            return obj.AddComponent<CLevelManager>();
        }
    }
    
    private static CLevelManager _inst;

    private void Awake()
    {
        _inst = this;
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
    }
	void Start ()
    {
        //_SpeedWorld = 3f;
        _PlayerAsser = Resources.Load<GameObject>("Plane");
        //InstanciatePlayer();
	}
	void Update ()
    {
       //PauseMenu();
	}
    /*
    public void SetSpeedWorld(float aSpeedWorld)
    {
        _SpeedWorld = aSpeedWorld;
    }
    public float GetSpeedWorld()
    {
        return _SpeedWorld;
    }
    public void InstanciatePlayer()
    {
        StartCoroutine("TranslatePosition");
        Instantiate(_PlayerAsser, Vector3.zero, Quaternion.identity);
        
    }
    */
    /*
    private void PauseMenu()
    {
        if (CKeyCode.firstPress(CKeyCode._KEY_ESCAPE))
        {
            // GameObject obj = GameObject.Instantiate(_MenuPause,Vector3.zero,Quaternion.identity);
            Instantiate(_MenuPause, Vector2.zero, Quaternion.identity);
        }
     }
     */
     /*
    public IEnumerator TranslatePosition()
    {
        bool _PositionFinish = false;
        while (!_PositionFinish)
        {
            _PlayerAsser.transform.parent = StartPositionPlane;
            _PlayerAsser.transform.position = Vector3.Slerp(_PlayerAsser.transform.position, _PlayerAsser.transform.parent.position, 60f * Time.deltaTime);
            yield return new WaitForSeconds(0.5f);
            _PositionFinish = true;
        }
    }
    
    */
}
