using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class CGameManager : MonoBehaviour {

    
    private static CGameManager _inst;
    public static CGameManager INST
     {
        get
        {
            if (_inst == null)
            { 
            GameObject obj = new GameObject("CManagerBall");
            return obj.AddComponent<CGameManager>();
        }
            return _inst; 
        } 
    }

    private float _BulletTime =100f;
   private bool _activePause = false;
   private AsyncOperation _currentLoadingScene;
   private void Awake()
    {
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            _inst = this;
        }

    }     
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PauseControl();
	}
    public void LateUpdate()
    {
        if(_currentLoadingScene != null)
        {
            if (_currentLoadingScene.isDone)
            {
                _currentLoadingScene = null;
            }
        }
    }
    private void PauseControl()
    {
        if (CKeyCode.firstPress(CKeyCode._KEY_ESCAPE))
        {
            _activePause = !_activePause;
            if (_activePause == true)
            {
                Time.timeScale = 0;
            }
            else if (_activePause == false)
            {
                Time.timeScale = 1;
            }
        }

    }
    public void LoadLevel(string _Level)
    {
        SceneManager.LoadScene(_Level);
    }
    public void LoadLevelAssync(string _Level)
    {
       _currentLoadingScene = SceneManager.LoadSceneAsync(_Level);
    }

 
}
