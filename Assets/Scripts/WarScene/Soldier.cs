using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WarManager;

public class Soldier : MonoBehaviour
{
    private SoldierBase parent_;

    [SerializeField]
    private static float hitLine_;
    public static float HitLine
    {
        set { hitLine_ = value; }
    }

    [SerializeField]
    private static ObjType win_;
    public static ObjType Win
    {
        get { return win_; }
        set { win_ = value; }
    }

    [SerializeField]
    private float speed_;
    [SerializeField]
    private float speedRatio_ = 1.0f;
    [SerializeField]
    private bool isLeft_;
    [SerializeField]
    private bool isBlown_ = false;

    private float posy;

    // Start is called before the first frame update
    void Start()
    {
        posy = transform.position.y;
        parent_ = transform.parent.gameObject.GetComponent<SoldierBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlown_)
        {
            blown();
        }
        else
        {
            move();
        }

    }
   public void init(Vector3 position)
    {
        isBlown_ = false;
        transform.position = position;
        transform.localRotation = Quaternion.identity;
    }

    private void move()
    {
        switch (parent_.Mode){
            case SoldierBase.AttackMode.NONE:
                speedRatio_ = 1.0f;
                break;

            case SoldierBase.AttackMode.ATTACK:
                speedRatio_ = 2.0f;
                break;

            case SoldierBase.AttackMode.DEFENCE:
                speedRatio_ = 0.5f;
                break;
            
            default: 
                break;
        }

        var speed = speed_ * speedRatio_;
        if (isLeft_)
        {
            speed *= -1;
        }

        var s = transform.localScale;
        if (isLeft_ && s.x < 0)
        {
            s.x *= -1;
        }
        if (!isLeft_ && s.x > 0)
        {
            s.x *= -1;
        }
        transform.localScale = s;

        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (hitLine_ > -7f || hitLine_ < 7f)
        {
            if (isLeft_ && win_ != ObjType.ENEMY)
            {
                if (pos.x < hitLine_)
                {
                    isBlown_ = true;
                }

            }
            else if (!isLeft_ && win_ != ObjType.PLAYER)
            {
                if (pos.x > hitLine_)
                {
                    isBlown_ = true;
                }
            }
        }
    }

    private void blown()
    {
        var speed = -speed_ * speedRatio_ * 3f;
        if (isLeft_)
        {
            speed *= -1;


            transform.Rotate(new Vector3(0, 0, -360f * 3 * speedRatio_ * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 360f * 3 * speedRatio_ * Time.deltaTime));
        }


        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        pos.y += speed_ * speedRatio_ * Time.deltaTime;
        transform.position = pos;

        if (win_ == ObjType.NONE)
        {
            if (pos.x > 12 || pos.x < -12)
            {
                // ‰¼.

                pos.y = posy;
                if (isLeft_)
                {
                    init(pos);
                }
                else
                {
                    init(pos);
                }
            }
        }
    }
}
