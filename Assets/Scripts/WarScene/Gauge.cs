using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Gauge : MonoBehaviour
{

    [SerializeField]
    private float ratio_;

    public float Ratio
    {
        get { return ratio_; }
        set { ratio_ = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Ratio = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Ratio = Mathf.Clamp(Ratio, 0f, 1f);

        GameObject child = transform.Find("RedGauge").gameObject;
        child.SetActive(true);
        //Vector3 child = GameObject.Find("RedGauge").transform.localScale;

        child.transform.localScale = new Vector3(Ratio, 1f, 1f);
    }
}
