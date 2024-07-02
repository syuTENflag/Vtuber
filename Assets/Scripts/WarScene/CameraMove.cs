using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float waitTime_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime_ -= Time.deltaTime;
        if (waitTime_ <= 0f)
        {
            waitTime_ = 0.02f;
            Vector3 pos = Random.insideUnitCircle * 0.05f;
            pos.z = -10f;
            transform.position = pos;
        }
    }
}
