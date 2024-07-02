using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentManager : MonoBehaviour
{
    public GameObject target;
    public GameObject comment;
    public float span = 1.0f;
    public float start = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Updatecommentprefab", start, span);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Updatecommentprefab()
    {
        GameObject prefab = (GameObject)Instantiate(comment);
        prefab.transform.SetParent(target.transform, false);
    }
}
