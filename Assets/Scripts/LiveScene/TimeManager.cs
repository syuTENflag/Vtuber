using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float CountDownTime
    {
        get; set;
    }

    [SerializeField]
    private Text TextCountDown;

    // Start is called before the first frame update
    void Start()
    {
        CountDownTime = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TextCountDown.text = string.Format("écÇËîzêMéûä‘:     0:{0:00}", CountDownTime);
        CountDownTime -= Time.deltaTime;
        if(CountDownTime <= 0.0f)
        {
            CountDownTime = 0.0f;
        }
    }
}
