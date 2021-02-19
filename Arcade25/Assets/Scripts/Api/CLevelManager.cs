using UnityEngine;
using System.Collections;

public class CLevelManager : MonoBehaviour {

    //public Transform StartPositionPlane;
   // public Transform StartPositionTank;
    private float _SpeedWorld = 3f;
    public Transform _StartPosition;
    private GameObject _PlayerAsser;
    private bool _TransformingTank = false;
    private GameObject _PlayerGame;
   // private GameObject _MenuPause;
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
        _SpeedWorld = 3f;
        _PlayerAsser = Resources.Load<GameObject>("Plane");
        InstantciatePosition(_StartPosition.position);
	}
	void Update ()
    {
        //PauseMenu();
        RemplacePlayer();
	}
    
    public void SetSpeedWorld(float aSpeedWorld)
    {
        _SpeedWorld = aSpeedWorld;
    }
    public float GetSpeedWorld()
    {
        return _SpeedWorld;
    }
    private void InstantciatePosition(Vector3 aTransform)
    {
        GameObject _Player = (GameObject)Instantiate(_PlayerAsser, aTransform, Quaternion.identity);
        _PlayerGame = _Player;
    }
    
    //Function Prototypo
    public void RemplacePlayer()
    {
        if (_TransformingTank== false)
        {
            if (CKeyCode.firstPress(CKeyCode._KEY_F))
            {

                Destroy(_PlayerGame);
                _PlayerAsser = Resources.Load<GameObject>("Tank");
                GameObject _PlayerTank = (GameObject)Instantiate(_PlayerAsser, new Vector3( _PlayerGame.transform.position.x, 14f, _PlayerGame.transform.position.z) , Quaternion.identity);
                _PlayerGame = _PlayerTank;
                _TransformingTank = true;

            }
        }
        else if (_TransformingTank == true)
        {
            if (CKeyCode.firstPress(CKeyCode._KEY_F))
            {
                Destroy(_PlayerGame);
                _PlayerAsser = Resources.Load<GameObject>("Plane");
                GameObject _PlayerPlane = (GameObject)Instantiate(_PlayerAsser, new Vector3( _PlayerGame.transform.position.x,120f, _PlayerGame.transform.position.z), Quaternion.identity);
                _PlayerGame = _PlayerPlane;
                _TransformingTank = false;
            }
        }
    }
   
    /*
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
