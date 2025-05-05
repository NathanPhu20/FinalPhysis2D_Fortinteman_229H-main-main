using UnityEngine;
using UnityEngine.UI;  // ������Ѻ UI
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public Button loadSceneButton;  // �����������Ŵ�ҡ
    public string sceneToLoad;  // ���ͧ͢�ҡ����ͧ�����Ŵ

    void Start()
    {
        // ��駤������������ͤ�ԡ�����¡�ѧ��ѹ LoadSceneByName
        loadSceneButton.onClick.AddListener(() => LoadSceneByName(sceneToLoad));
    }

    // �ѧ��ѹ��Ŵ�ҡ
    void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
