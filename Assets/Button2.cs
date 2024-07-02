using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Button2 : MonoBehaviour
{
    [SerializeField]
    private Text Text;

    int score;
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
        score += 5;
        //ゲーム内のスコア表示をセット
        Text.text = string.Format("{0}", score);
    }
}
