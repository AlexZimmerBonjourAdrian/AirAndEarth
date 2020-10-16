using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSwitcher : MonoBehaviour
{
    public void SetState(string _name)
    {
        CGameManager.INST.LoadLevelAssync(_name);
    }
}
