using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRedRocket : MonoBehaviour {

    private GameObject Rocket;
    [SerializeField]
    private float _SpeedRocket = 5f;
    private const int STATE_FLY = 0;
    private const int STATE_DEATH = 1;
    private int _State = 0;
    private Rigidbody _Rigidbody;
    private float Heatlth = 10;

    // Use this for initialization
    private void Awake()
    {
        _State = 0;
        _Rigidbody = GetComponent<Rigidbody>();
    }
	void Start ()
    {
       
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
            Destroy(gameObject);
        }
    }
    public void PreState()
    {
        if (_State == STATE_FLY)
        {

        }
        else if (_State == STATE_DEATH)
        {

        }
    }
    public void SetState(int aState)
    {
        PreState();
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
            SetState(STATE_DEATH);
        }
    }
    public void MovementRocket()
    {
       // _SpeedRocket = aSpeedRocket * Time.deltaTime;
        transform.position += Vector3.forward * (-_SpeedRocket * Time.deltaTime); 
    }
}
