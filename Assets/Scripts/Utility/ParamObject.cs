using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamObject : MonoBehaviour
{
    [SerializeField]
    private int fansNum;
    public int FansNum // �t�@���̐�.
    {
        get { return fansNum; }
        set { fansNum = value; }
    }

    [SerializeField]
    private int enemyFansNum;
    public int EnemyFansNum // ����t�@���̐�.
    {
        get { return enemyFansNum; }
        set { enemyFansNum = value; }
    }

    [SerializeField]
    private int funds;
    public int Funds // �R����.
    {
        get { return funds; }
        set { funds = value; }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
