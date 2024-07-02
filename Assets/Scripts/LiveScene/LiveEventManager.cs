using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveEventManager : MonoBehaviour
{
    [SerializeField]
    private LiveManager lm_;

    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset_;

    [SerializeField]
    private GameObject mainText_;

    [SerializeField]
    private GameObject[] choice_;

    struct EventData
    {
        public string text;
        public string[] choice;
        public int[] score;
    }
    private int dataId_;
    private int dataNum_;
    private EventData[] dataList_;

    // Start is called before the first frame update
    void Start()
    {
        choice_[0].GetComponent<Button>().onClick.AddListener(button0);
        choice_[1].GetComponent<Button>().onClick.AddListener(button1);
        choice_[2].GetComponent<Button>().onClick.AddListener(button2);

        var data = textAsset_.text.Split(char.Parse("\n"));
        dataNum_ = int.Parse(data[0]);
        dataList_ = new EventData[dataNum_];

        for (int i = 0; i < dataNum_; ++i)
        {
            dataList_[i].choice = new string[3];
            dataList_[i].score = new int[3];

            dataList_[i].text = data[i * 7 + 1];
            dataList_[i].choice[0] = data[i * 7 + 2];
            dataList_[i].score[0] = int.Parse(data[i * 7 + 3]);
            dataList_[i].choice[1] = data[i * 7 + 4];
            dataList_[i].score[1] = int.Parse(data[i * 7 + 5]);
            dataList_[i].choice[2] = data[i * 7 + 6];
            dataList_[i].score[2] = int.Parse(data[i * 7 + 7]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            eventStart();
        }
    }

    public void eventStart()
    {
        eventInit();
        StartCoroutine(eventEnd(8f));
    }

    private void eventInit()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        foreach (var e in choice_) { 
            e.gameObject.SetActive(true);
            e.gameObject.GetComponent<Button>().enabled = true;
        }

        dataId_ = Random.Range(0, dataNum_);

        mainText_.GetComponent<Text>().text = dataList_[dataId_].text;
        for (int i = 0; i < 3; ++i)
        {
            choice_[i].GetComponentInChildren<Text>().text = dataList_[dataId_].choice[i];
        }
    }

    private void button0()
    {
        lm_.PointUpA(dataList_[dataId_].score[0] * 10);
        choice_[0].gameObject.GetComponent<Button>().enabled = false;

        choice_[1].gameObject.SetActive(false);
        choice_[2].gameObject.SetActive(false);

        buttonEnd();
    }

    private void button1()
    {
        lm_.PointUpA(dataList_[dataId_].score[1] * 10);
        choice_[1].gameObject.GetComponent<Button>().enabled = false;

        choice_[0].gameObject.SetActive(false);
        choice_[2].gameObject.SetActive(false);

        buttonEnd();
    }

    private void button2()
    {
        lm_.PointUpA(dataList_[dataId_].score[2] * 10);
        choice_[2].gameObject.GetComponent<Button>().enabled = false;

        choice_[0].gameObject.SetActive(false);
        choice_[1].gameObject.SetActive(false);

        buttonEnd();
    }

    private void buttonEnd() {
        StopAllCoroutines();
        StartCoroutine(eventEnd(2f));
    }

    private IEnumerator eventEnd(float time)
    {
        yield return new WaitForSeconds(time);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
