using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RollScript : MonoBehaviour
{
    [SerializeField]
    private float textScrollSpeed = 0.1f;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 360f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;
    //　シーン移動用コルーチン
    private Coroutine RollCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = GetComponent<RectTransform>().position;
        Debug.Log(pos);
        //　エンドロールが終了した時
        if (isStopEndRoll)
        {
            RollCoroutine = StartCoroutine(GoToNextScene());
        }
        else
        {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (pos.y <= limitPosition)
            {
                pos = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
                GetComponent<RectTransform>().position = pos;
            }
            else
            {
                isStopEndRoll = true;
            }
        }
    }
    IEnumerator GoToNextScene()
    {
        //　5秒間待つ
        yield return new WaitForSeconds(5f);

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(RollCoroutine);
            SceneManager.LoadScene("GameTitle");
        }

        yield return null;
    }

}
