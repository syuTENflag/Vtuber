using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreDraw : MonoBehaviour
{
    [SerializeField]
    private string preText_;
    
    [SerializeField]
    private string afterText_;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreDraw(int num)
    {
        GetComponent<Text>().text = preText_ + num.ToString() + afterText_;
        GetComponent<Animator>().Play(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0f);
    }
}
