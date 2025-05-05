using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy1"))
        {
            ScoreManager.AddScore(1); // เพิ่มคะแนน

            Destroy(other.gameObject); // ลบศัตรู
            Destroy(gameObject);       // ลบกระสุน
        }
    }
}
