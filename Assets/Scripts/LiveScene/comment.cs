using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comment : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    [SerializeField]
    private Text dataText;

    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;

    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　改行で分割して配列に入れる
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
