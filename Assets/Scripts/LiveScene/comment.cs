using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comment : MonoBehaviour
{

    //�@�ǂݍ��񂾃e�L�X�g���o�͂���UI�e�L�X�g
    [SerializeField]
    private Text dataText;

    //�@�ǂލ��ރe�L�X�g���������܂�Ă���.txt�t�@�C��
    [SerializeField]
    private TextAsset textAsset;

    //�@�e�L�X�g�t�@�C������ǂݍ��񂾃f�[�^
    private string loadText1;
    //�@���s�ŕ������Ĕz��ɓ����
    private string[] splitText1;



    public float span = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("commentUp", span, span);
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        string character = splitText1[0];
        int num = int.Parse(character.ToString());
        int rnd = Random.Range(1, num + 1);
        dataText.text = splitText1[rnd];
    }

    // Update is called once per frame
    void Update()
    {     
       
    }

    void commentUp()
    {
        //transform.Translate(0, 0.01f, 0);
        transform.position += new Vector3(0, 0.6f, 0);
        if (transform.position.y > 3.8f)
        {
            Destroy(gameObject);
        }
    }
}
