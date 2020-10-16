using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPauseLogic : MonoBehaviour
{
    private GameObject _MenuAsset;
    private void Awake()
    {
        _MenuAsset = Resources.Load<GameObject>("MenuConfiramteExit");
    }
    public void ConfirmateMenu()
    {
        GameObject _instantite = (GameObject)Instantiate(_MenuAsset, Vector2.zero, Quaternion.identity);
    }
    public void ResumenMenu()
    {
        Destroy(gameObject);
    }
}
