using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteBack : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public GameObject btn;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public int head = 1;

    // Start is called before the first frame update
    void Start()
    {
        btn.SetActive(false);
    }

    public void BackImage()
    {
        head--;
        var img = GetComponent<Image>();
        switch (head)
        {
            case 1:
                img.sprite = sprite1;
                btn.SetActive(false);
                text1.SetActive(true);
                text2.SetActive(false);
                break;
            case 2:
                img.sprite = sprite2;
                text1.SetActive(false);
                text3.SetActive(false);
                text2.SetActive(true);
                break;
            case 3:
                img.sprite = sprite3;
                text2.SetActive(false);
                text4.SetActive(false);
                text3.SetActive(true);
                break;
            case 4:
                img.sprite = sprite4;
                btn2.SetActive(true);
                text3.SetActive(false);
                text5.SetActive(false);
                text4.SetActive(true);
                btn3.SetActive(false);
                break;
            case 5:
                img.sprite = sprite1;
                text4.SetActive(false);
                btn3.SetActive(true);
                break;
        }
        SpriteChange spritechange = GetComponent<SpriteChange>();
        spritechange.head = head;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
