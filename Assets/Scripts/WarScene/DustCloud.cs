using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustCloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
