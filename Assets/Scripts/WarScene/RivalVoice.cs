using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalVoice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(voicePlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator voicePlay()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Play();
    }
}
