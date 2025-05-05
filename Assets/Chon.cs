using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision2D : MonoBehaviour
{
    [Header("��駪��ͫչ����ͧ�����Ŵ")]
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
