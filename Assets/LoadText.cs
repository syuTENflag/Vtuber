using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{

    //�@�ǂݍ��񂾃e�L�X�g���o�͂���UI�e�L�X�g
    [SerializeField]
    private Text dataText;
    [SerializeField]
    private Text dataText2;
    [SerializeField]
    private Text dataText3;
    [SerializeField]
    private Text dataText4;
    //�@�ǂލ��ރe�L�X�g���������܂�Ă���.txt�t�@�C��
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private TextAsset textAsse2;
    [SerializeField]
    private TextAsset textAsset3;
    //�@�e�L�X�g�t�@�C������ǂݍ��񂾃f�[�^
    private string loadText1;
    private string loadText3;
    private string loadText5;
    private string loadText7;
    //�@Resources�t�H���_���璼�ڃe�L�X�g��ǂݍ���
    private string loadText2;
    private string loadText4;
    private string loadText6;
    private string loadText8;
    //�@���s�ŕ������Ĕz��ɓ����
    private string[] splitText1;
    private string[] splitText3;
    private string[] splitText5;
    private string[] splitText7;
    //�@���s�ŕ������Ĕz��ɓ����
    private string[] splitText2;
    private string[] splitText4;
    private string[] splitText6;
    private string[] splitText8;
    //�@���ݕ\�����e�L�X�g1�ԍ�
    private int textNum1;
    //�@���ݕ\�����e�L�X�g2�ԍ�
    private int textNum2;
    private int textNum3;
    private int textNum4;
    private int textNum5;

    void Start()
    {
        

        loadText1 = textAsset.text;
        loadText2 = (Resources.Load("Test2", typeof(TextAsset)) as TextAsset).text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        splitText2 = loadText2.Split(char.Parse("\n"));
        textNum1 = 1;
        textNum2 = 0;
        dataText.text = "�}�E�X�̍��N���b�N�Œʏ�̃e�L�X�g�t�@�C���̓ǂݍ��݁A�E�N���b�N��Resources�t�H���_���̃e�L�X�g�t�@�C���ǂݍ��݂����e�L�X�g���\������܂��B";
        
        loadText3 = textAsset.text;
        loadText4 = (Resources.Load("Test2", typeof(TextAsset)) as TextAsset).text;
        splitText3 = loadText3.Split(char.Parse("\n"));
        splitText4 = loadText4.Split(char.Parse("\n"));
        textNum3 = 2;

        loadText5 = textAsset.text;
        loadText6 = (Resources.Load("Test2", typeof(TextAsset)) as TextAsset).text;
        splitText5 = loadText5.Split(char.Parse("\n"));
        splitText6 = loadText6.Split(char.Parse("\n"));
        textNum4 = 4;

        loadText7 = textAsset.text;
        loadText8 = (Resources.Load("Test2", typeof(TextAsset)) as TextAsset).text;
        splitText7 = loadText7.Split(char.Parse("\n"));
        splitText8 = loadText8.Split(char.Parse("\n"));
        textNum5 = 6;

    }


    
    void Update()
    {
        //text1
        //�@�ǂݍ��񂾃e�L�X�g�t�@�C���̓��e��\��

        if (Input.GetButtonDown("Fire1"))
        {
            if (splitText1[textNum1] != "")
            {
                dataText.text = splitText1[textNum1];
                textNum1 = textNum1 + 7;
                if (textNum1 >= splitText1.Length)
                {
                    textNum1 = 1;
                }
            }
            else
            {
                dataText.text = "";
                textNum1++;
            }
            //�@Resources�t�H���_�ɔz�u�����e�L�X�g�t�@�C���̓��e��\��
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (splitText2[textNum2] != "")
            {
                dataText.text = splitText2[textNum2];
                textNum2++;
                if (textNum2 >= splitText2.Length)
                {
                    textNum2 = 0;
                }
            }
            else
            {
                dataText.text = "";
                textNum2++;
            }
        }
        //text2
        //�@�ǂݍ��񂾃e�L�X�g�t�@�C���̓��e��\��
        if (Input.GetButtonDown("Fire1"))
        {
            if (splitText3[textNum3] != "")
            {
                dataText2.text = splitText3[textNum3];
                textNum3 = textNum3 + 7;
                if (textNum3 >= splitText3.Length)
                {
                    textNum3 = 2;
                }
            }
            else
            {
                dataText2.text = "";
                textNum3++;
            }
            //�@Resources�t�H���_�ɔz�u�����e�L�X�g�t�@�C���̓��e��\��
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (splitText4[textNum2] != "")
            {
                dataText2.text = splitText4[textNum2];
                textNum2++;
                if (textNum2 >= splitText4.Length)
                {
                    textNum2 = 0;
                }
            }
            else
            {
                dataText2.text = "";
                textNum2++;
            }
        }
        //text3
        //�@�ǂݍ��񂾃e�L�X�g�t�@�C���̓��e��\��
        if (Input.GetButtonDown("Fire1"))
        {
            if (splitText5[textNum4] != "")
            {
                dataText3.text = splitText5[textNum4];
                textNum4 = textNum4 + 7;
                if (textNum4 >= splitText5.Length)
                {
                    textNum4 = 4;
                }
            }
            else
            {
                dataText3.text = "";
                textNum4++;
            }
            //�@Resources�t�H���_�ɔz�u�����e�L�X�g�t�@�C���̓��e��\��
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (splitText6[textNum2] != "")
            {
                dataText3.text = splitText6[textNum2];
                textNum2++;
                if (textNum2 >= splitText6.Length)
                {
                    textNum2 = 0;
                }
            }
            else
            {
                dataText3.text = "";
                textNum2++;
            }
        }
        //text4
        //�@�ǂݍ��񂾃e�L�X�g�t�@�C���̓��e��\��
        if (Input.GetButtonDown("Fire1"))
        {
            if (splitText7[textNum5] != "")
            {
                dataText4.text = splitText5[textNum5];
                textNum5 = textNum5 + 7;
                if (textNum5 >= splitText5.Length)
                {
                    textNum5 = 6;
                }
            }
            else
            {
                dataText4.text = "";
                textNum5++;
            }
            //�@Resources�t�H���_�ɔz�u�����e�L�X�g�t�@�C���̓��e��\��
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (splitText8[textNum2] != "")
            {
                dataText4.text = splitText6[textNum2];
                textNum2++;
                if (textNum2 >= splitText6.Length)
                {
                    textNum2 = 0;
                }
            }
            else
            {
                dataText4.text = "";
                textNum2++;
            }
        }
    }
    public void OnClick()
    {

    }
}