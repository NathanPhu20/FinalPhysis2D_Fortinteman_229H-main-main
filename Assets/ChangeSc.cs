using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSc : MonoBehaviour
{
    public string sceneToLoad; // ���ͫչ����ͧ�����Ŵ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ��Ǩ�ͺ����繼������������
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
