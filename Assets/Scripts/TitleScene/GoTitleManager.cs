using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitleManager : MonoBehaviour
{
    public void PushGoTitle()
    {
        Invoke(nameof(timePushGoTitle), 1f);
    }

    public void timePushGoTitle()
    {
        SceneManager.LoadScene("GameTitle");
    }
    private void OnDestroy()
    {
        // DestroyŽž‚É“o˜^‚µ‚½Invoke‚ð‚·‚×‚ÄƒLƒƒƒ“ƒZƒ‹
        CancelInvoke();
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
