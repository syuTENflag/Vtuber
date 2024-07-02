using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;
using static WarManager;

public class LiveManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private LiveEventManager lemgr_;

    [SerializeField]
    private Text targetFansText_;
    [SerializeField]
    private Text fansText_;
    [SerializeField]
    private Text moneyText_;
    [SerializeField]
    private Text audienceText_;

    [SerializeField]
    private GameObject addDrawBase_;
    [SerializeField]
    private AddScoreDraw addFansDraw_;
    [SerializeField]
    private AddScoreDraw addAudienceDraw_;

    [SerializeField]
    private ImageColorLeap black_;
    [SerializeField]
    private GameObject[] endEventObjects_;

    [SerializeField]
    private float fansNum_;

    [SerializeField]
    private AudioSource miss_;

    public float FansNum // �t�@���̐�.
    {
        get { return fansNum_; }
        set { fansNum_ = value; }
    }

    [SerializeField]
    private float targetFansNum_;
    public float TargetFansNum // ����t�@���̐�.
    {
        get { return targetFansNum_; }
        set { targetFansNum_ = value; }
    }

    [SerializeField]
    private float audienceNum_;

    public float AudienceNum // �����҂̐�.
    {
        get { return audienceNum_; }
        set { audienceNum_ = value; }
    }

    [SerializeField]
    private float money_;
    public float Money // �R����.
    {
        get { return money_; }
        set { money_ = value; }
    }

    [SerializeField]
    private float audienceRatio_ = 0.005f;
    [SerializeField]
    private float fansRatio_ = 0.001f;
    [SerializeField]
    private float moneyAudienceRatio_ = 0.5f;
    [SerializeField]
    private float moneyFansRatio_ = 0.5f;

    private bool isEnd_ = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(liveEvent(3f));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(warEvent());
        }*/

        if (timeManager.CountDownTime <= 0)
        {
            if (isEnd_ == false)
            {
                isEnd_ = true;
                StartCoroutine(warEvent());
            }
        }
        else
        {
            paramUpdate();
        }
        textUpdate();

    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // �V�[���؂�ւ���̃X�N���v�g���擾
        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<WarManager>();

        // �f�[�^��n������
        gameManager.FansNum = FansNum;
        gameManager.Money = (int)Money;
        gameManager.EnemyFansNum = targetFansNum_;

        // �C�x���g����폜
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    // �e��p�����[�^�̃A�b�v�f�[�g.
    private void paramUpdate()
    {
        AudienceNum += AudienceNum * audienceRatio_ * Time.deltaTime;
        FansNum += AudienceNum * fansRatio_ * Time.deltaTime;
        Money += AudienceNum * moneyAudienceRatio_ * Time.deltaTime;
        Money += FansNum * moneyFansRatio_ * Time.deltaTime;
    }

    // �\���e�L�X�g�̍X�V.
    private void textUpdate()
    {
        fansText_.text = ((int)FansNum).ToString();
        targetFansText_.text = ((int)TargetFansNum).ToString();
        moneyText_.text = ((int)Money).ToString();
        audienceText_.text = ((int)audienceNum_).ToString();
    }

    // �t�@�������Ɏ����Ґ��̉e���x�������|�C���g����.
    public void PointUpA(int num)
    {
        audienceNum_ += num;                    // �|�C���g�������ґ���.
        addAudienceDraw_.ScoreDraw(num);
        FansNum += audienceNum_ * 0.1f;    // �|�C���g�Ǝ����҂ɉ����ăt�@������.

        var pos = Input.mousePosition;
        pos.z = 10.0f;
        addDrawBase_.transform.position = Camera.main.ScreenToWorldPoint(pos);
        addFansDraw_.ScoreDraw((int)(audienceNum_ * 0.1f));
        if (num < 30)
        {
            miss_.Play();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // �t�@�������Ɏ����Ґ��̉e���x�̒Ⴂ�|�C���g����.
    public void PointUpB(int num)
    {
        audienceNum_ += num;                    // �|�C���g�������ґ���.
        addAudienceDraw_.ScoreDraw(num);
        FansNum += audienceNum_ * 0.01f;    // �|�C���g�Ǝ����҂ɉ����ăt�@������.

        var pos = Input.mousePosition;
        pos.z = 10.0f;
        addDrawBase_.transform.position = Camera.main.ScreenToWorldPoint(pos);
        addFansDraw_.ScoreDraw((int)(audienceNum_ * 0.01f));
        if (num < 30)
        {
            miss_.Play();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator warEvent()
    {
        // �I���\��.
        foreach (var e in endEventObjects_)
        {
            e.SetActive(true);
        }
        yield return new WaitForSeconds(2f);

        // �Ö�.
        black_.ChangeColor(new Color(0, 0, 0, 1), 1.0f);
        yield return new WaitForSeconds(1f);

        // �V�[���J��.
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene("WarScene");
    }

    private IEnumerator liveEvent(float time)
    {
        yield return new WaitForSeconds(time);
        lemgr_.eventStart();
        StartCoroutine(liveEvent(Random.Range(10.0f, 13.0f)));
    }
}
