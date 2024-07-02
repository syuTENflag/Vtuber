using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarManager : MonoBehaviour
{
    public enum ObjType
    {
        NONE = -1,
        PLAYER,
        ENEMY,
        COUNT
    }

    [SerializeField]
    private ObjType win_;
    public ObjType Win
    {
        get { return win_; }
    }

    [SerializeField]
    private GameObject[] fansBaseObject_;

    [SerializeField]
    private float[] fansNum_ = new float[(int)ObjType.COUNT];

    public float FansNum // ÉtÉ@ÉìÇÃêî.
    {
        get { return fansNum_[(int)ObjType.PLAYER]; }
        set { fansNum_[(int)ObjType.PLAYER] = value; }
    }
    public float EnemyFansNum // ëäéËÉtÉ@ÉìÇÃêî.
    {
        get { return fansNum_[(int)ObjType.ENEMY]; }
        set { fansNum_[(int)ObjType.ENEMY] = value; }
    }

    [SerializeField]
    private int money_;
    public int Money // åRéëã‡.
    {
        get { return money_; }
        set { money_ = value; }
    }

    [SerializeField]
    private GameObject[] fansText_ = new GameObject[(int)ObjType.COUNT];

    [SerializeField]
    private GameObject black_;

    [SerializeField]
    private float hitLine_;
    public float HitLine
    {
        get { return hitLine_; }
    }

    [SerializeField]
    private float playerSpeedRatio_ = 1.0f;
    [SerializeField]
    private float enemySpeedRatio_ = 1.0f;

    [SerializeField]
    private GameObject AttackButton_;

    [SerializeField]
    private GameObject playerCutIn_;

    [SerializeField]
    private GameObject enemyCutIn_;

    [SerializeField]
    private GameObject clearPanel_;

    [SerializeField]
    private GameObject losePanel_;

    [SerializeField]
    private GameObject gauge_;

    [SerializeField]
    private AudioObject audioObject_;

    private bool enemyAttacked_ = false; 
    // Start is called before the first frame update
    void Start()
    {
        if (black_.activeSelf)
        {
            black_.GetComponent<ImageColorLeap>().ChangeColor(Color.clear, 1.0f);
        }
        paramUpdate();
        foreach (GameObject obj in fansBaseObject_) {
            obj.transform.position = new Vector3(hitLine_, 0f, 0f);
        }

        AttackButton_.GetComponent<Button>().onClick.AddListener(AttackButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (win_ == ObjType.NONE)
        {
            paramUpdate();
            EnemyAttack();
            win_ = winCheck();
        }
        Soldier.Win = win_;

        numTextUpdate();
    }

    private void numTextUpdate()
    {
        fansText_[(int)ObjType.PLAYER].GetComponent<Text>().text = ((int)FansNum).ToString();
        fansText_[(int)ObjType.ENEMY].GetComponent<Text>().text = ((int)EnemyFansNum).ToString();
    }

    private void paramUpdate()
    {
        int num = 360;

        switch (fansBaseObject_[(int)ObjType.PLAYER].GetComponent<SoldierBase>().Mode)
        {
            case SoldierBase.AttackMode.NONE:
                enemySpeedRatio_ = 1.0f;
                break;

            case SoldierBase.AttackMode.ATTACK:
                enemySpeedRatio_ = 2.0f;
                break;

            case SoldierBase.AttackMode.DEFENCE:
                enemySpeedRatio_ = 0.75f;
                break;

            default:
                break;
        }
        switch (fansBaseObject_[(int)ObjType.ENEMY].GetComponent<SoldierBase>().Mode)
        {
            case SoldierBase.AttackMode.NONE:
                playerSpeedRatio_ = 1.0f;
                break;

            case SoldierBase.AttackMode.ATTACK:
                playerSpeedRatio_ = 2.0f;
                break;

            case SoldierBase.AttackMode.DEFENCE:
                playerSpeedRatio_ = 0.75f;
                break;

            default:
                break;
        }
        
        // TODO  ñhâqå¯â Ç™ñ¢é¿ëï.

        FansNum -= (num * Time.deltaTime) * playerSpeedRatio_;
        EnemyFansNum -= (num * Time.deltaTime) * enemySpeedRatio_;
        
        if (EnemyFansNum <= 0)
        {
            EnemyFansNum = 0;
        }
        if (FansNum <= 0)
        {
            FansNum = 0;
        }


        gauge_.GetComponent<Gauge>().Ratio = FansNum / (FansNum + EnemyFansNum);
        if (EnemyFansNum > 0)
        {

            if (FansNum > EnemyFansNum)
            {
                hitLine_ = (FansNum / EnemyFansNum - 1);
                hitLine_ *= hitLine_;
            }
            else
            {
                hitLine_ = (EnemyFansNum / FansNum - 1);
                hitLine_ *= hitLine_;
                hitLine_ *= -1;
            }
            hitLine_ *= 7;
            if (hitLine_ > 7f)
            {
                hitLine_ = 7f;
            }else if(hitLine_ < -7f)
            {
                hitLine_ = -7f;
            }
        }
        else
        {
            hitLine_ = 2 * 7;
        }

        Soldier.HitLine = hitLine_;

    }

    // èüîsîªíËÇçsÇ¢Ç‹Ç∑.
    // èüóòë§ÇÃObjTypeÇÃílÇï‘ÇµÇ‹Ç∑.
    // îÒåàíÖÇÃèÍçáÇÕObjType.NONEÇï‘ÇµÇ‹Ç∑.
    private ObjType winCheck()
    {
        if(EnemyFansNum <= 0)
        {
            if (FansNum <= 0)
            {
                FansNum = 1;
            }
            GetComponent<AudioSource>().Play();
            StartCoroutine(objectAwake(clearPanel_, 3.0f));
            return ObjType.PLAYER;
        }
        else if (FansNum <= 0)
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(objectAwake(losePanel_, 3.0f));
            return ObjType.ENEMY;
        }

        return ObjType.NONE;
    }

    private void AttackButton()
    {
        if (fansBaseObject_[(int)ObjType.PLAYER].GetComponent<SoldierBase>().Mode != SoldierBase.AttackMode.ATTACK)
        {
            fansBaseObject_[(int)ObjType.PLAYER].GetComponent<SoldierBase>().Mode = SoldierBase.AttackMode.ATTACK;
            playerCutIn_.GetComponent<cutin>().CutIn();
            StartCoroutine(AttackModeEnd(ObjType.PLAYER, 5.0f));
            AttackButton_.GetComponent<Button>().interactable = false;
        }
    }

    private void EnemyAttack()
    {
        if (enemyAttacked_ || EnemyFansNum > 5000)
        {
            return;
        }

        fansBaseObject_[(int)ObjType.ENEMY].GetComponent<SoldierBase>().Mode = SoldierBase.AttackMode.ATTACK;
        enemyCutIn_.GetComponent<cutin>().CutIn();
        StartCoroutine(AttackModeEnd(ObjType.ENEMY, 5.0f));
        enemyAttacked_ = true;

    }

    private IEnumerator AttackModeEnd(ObjType type, float time)
    {
        yield return new WaitForSeconds(time);
        if(fansBaseObject_[(int)type].GetComponent<SoldierBase>().Mode == SoldierBase.AttackMode.ATTACK)
        {
            fansBaseObject_[(int)type].GetComponent<SoldierBase>().Mode = SoldierBase.AttackMode.NONE;
        }

    }

    private void DefenceButton()
    {
        // TODO.
    }

    private IEnumerator objectAwake(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time / 2);
        black_.GetComponent<ImageColorLeap>().ChangeColor(new Color(0, 0, 0, 1), time / 2);
        yield return new WaitForSeconds(time / 2);
        audioObject_.Stop();
        black_.GetComponent<ImageColorLeap>().ChangeColor(new Color(0, 0, 0, 0), 1);

        yield return null;

        obj.SetActive(true);

    }
}
