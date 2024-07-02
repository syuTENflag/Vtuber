using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = GetComponent<RectTransform>().position;
        Debug.Log(pos);
    }
    public void Skip()
    {
        transform.position = new Vector3(0, 4f, 0);
    }

}
