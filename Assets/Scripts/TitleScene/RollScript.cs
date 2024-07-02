using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RollScript : MonoBehaviour
{
    [SerializeField]
    private float textScrollSpeed = 0.1f;
    //�@�e�L�X�g�̐����ʒu
    [SerializeField]
    private float limitPosition = 360f;
    //�@�G���h���[�����I���������ǂ���
    private bool isStopEndRoll;
    //�@�V�[���ړ��p�R���[�`��
    private Coroutine RollCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = GetComponent<RectTransform>().position;
        Debug.Log(pos);
        //�@�G���h���[�����I��������
        if (isStopEndRoll)
        {
            RollCoroutine = StartCoroutine(GoToNextScene());
        }
        else
        {
            //�@�G���h���[���p�e�L�X�g�����~�b�g���z����܂œ�����
            if (pos.y <= limitPosition)
            {
                pos = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
                GetComponent<RectTransform>().position = pos;
            }
            else
            {
                isStopEndRoll = true;
            }
        }
    }
    IEnumerator GoToNextScene()
    {
        //�@5�b�ԑ҂�
        yield return new WaitForSeconds(5f);

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(RollCoroutine);
            SceneManager.LoadScene("GameTitle");
        }

        yield return null;
    }

}
