using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : MonoBehaviour
{
    public enum AttackMode
    {
        NONE,
        ATTACK,
        DEFENCE,
        COUNT
    }

    private AttackMode attackMode_;

    public AttackMode Mode
    {
        get { return attackMode_; }
        set { attackMode_ = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
