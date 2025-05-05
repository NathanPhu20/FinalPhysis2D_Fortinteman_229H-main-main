using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy1"))
        {
            ScoreManager.AddScore(1); // ������ṹ

            Destroy(other.gameObject); // ź�ѵ��
            Destroy(gameObject);       // ź����ع
        }
    }
}
