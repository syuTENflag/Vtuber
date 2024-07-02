using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutin : MonoBehaviour
{
    [SerializeField]
    private AudioSource horagai_;
    [SerializeField]
    private AudioSource voice_;
    [SerializeField]
    private AudioSource kansei_;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutIn()
    {
        GetComponent<Animator>().Play(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0f);
        horagai_.Play();
        voice_.Play();
        kansei_.Play();
    }
}
