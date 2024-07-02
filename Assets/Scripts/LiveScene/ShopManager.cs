using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private LiveManager liveMgr_;

    [SerializeField]
    private GameObject[] typeA_;

    [SerializeField]
    private GameObject[] typeB_;

    [SerializeField]
    private int[] typeACost_;
    [SerializeField]
    private int[] typeBCost_;

    [SerializeField]
    private int[] typeACount_;
    [SerializeField]
    private int[] typeBCount_;



    // Start is called before the first frame update
    void Start()
    {
        typeACount_ = new int[typeA_.Length];
        typeBCount_ = new int[typeB_.Length];
 
        typeA_[0].GetComponent<Button>().onClick.AddListener(typeA0);
        typeA_[1].GetComponent<Button>().onClick.AddListener(typeA1);
        typeB_[0].GetComponent<Button>().onClick.AddListener(typeB0);
        typeB_[1].GetComponent<Button>().onClick.AddListener(typeB1);

        typeA_[0].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeACost_[0].ToString();
        typeA_[1].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeACost_[1].ToString();
        typeB_[0].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeBCost_[0].ToString();
        typeB_[1].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeBCost_[1].ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void typeA0()
    {
        AFunc(0);
    }
    private void typeA1()
    {
        AFunc(1);
    }
    private void typeB0()
    {
        BFunc(0);
    }
    private void typeB1()
    {
        BFunc(1);
    }

    private void AFunc(int num)
    {
        int cost = typeACost_[num];
        if (liveMgr_.Money >= cost)
        {
            liveMgr_.Money -= cost;
            liveMgr_.PointUpA(cost / 25);
            ++typeACount_[num];
            typeACost_[num] *= 2;
            typeA_[num].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeACost_[num].ToString();
        }
    }

    private void BFunc(int num)
    {
        int cost = typeBCost_[num];
        if (liveMgr_.Money >= cost)
        {
            liveMgr_.Money -= cost;
            liveMgr_.PointUpB(cost / 5);
            ++typeBCount_[num];
            typeBCost_[num] *= 2;
            typeB_[num].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = typeBCost_[num].ToString();
        }

    }
}
