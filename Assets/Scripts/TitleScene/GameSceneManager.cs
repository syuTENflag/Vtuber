using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void PushRoll()
    {
        Invoke(nameof(timePushRoll), 1f);
        //SceneManager.LoadScene("GameTitle");
    }
    public void timePushRoll()
    {
        SceneManager.LoadScene("TutorialScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
