using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text moneyText;

    int score = 0;
    int money = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void OnClick()
    {
        //�X�R�A���u10�v���₷
        score += 10;
        //�������u10�v���炷
        money -= 10;
        //�Q�[�����̃X�R�A�\�����Z�b�g
        scoreText.text = string.Format("{0}", score);
        moneyText.text = money.ToString("00");

    }
}
