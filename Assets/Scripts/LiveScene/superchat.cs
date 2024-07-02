using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superchat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.01f, 0);
        if (transform.position.y > 3.5f)
        {
            transform.position = new Vector3(1, -1.5f, 0);
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            
        }
    }
}
