using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
       
    }
   public void PushStart()
    { 
        Invoke(nameof(timePushStart), 1f);
    }

    public void timePushStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void OnDestroy()
    {
        // Destroy���ɓo�^����Invoke�����ׂăL�����Z��
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
