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
        //スコアを「10」増やす
        score += 10;
        //お金を「10」減らす
        money -= 10;
        //ゲーム内のスコア表示をセット
        scoreText.text = string.Format("{0}", score);
        moneyText.text = money.ToString("00");

    }
}
