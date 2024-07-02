using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] sources_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        foreach(var audio in sources_)
        {
            audio.Play();
        }
    }

    public void Stop()
    {
        foreach (var audio in sources_)
        {
            audio.Stop();
        }
    }
}
