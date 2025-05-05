using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D bulletPrefab;

    [SerializeField] private float shootDelay = 0.5f;
    private float lastShootTime = -Mathf.Infinity;

    [Header("Projectile Settings")]
    [SerializeField] private float gravity = -9.8f;  // แรงโน้มถ่วง (คุณสามารถปรับค่าได้)

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShootTime + shootDelay)
        {
            lastShootTime = Time.time;

            // แปลงตำแหน่งเมาส์ในจอ เป็นตำแหน่งในโลก 2D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // ย้าย Target ไปที่ตำแหน่งคลิก
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                // สร้างกระสุนใหม่
                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                // คำนวณทิศทางและระยะห่าง
                Vector2 direction = hit.point - (Vector2)shootPoint.position; 
                float distance = direction.magnitude; 
                direction.Normalize(); 

                // คำนวณเวลาที่จะใช้ในการยิง
                float timeToReach = Mathf.Sqrt(2 * Mathf.Abs(distance) / Mathf.Abs(gravity)); // คำนวณเวลาในการยิงเพื่อให้กระสุนถึงเป้าหมาย

                // คำนวณความเร็วในแกน Y
                float velocityY = (distance / timeToReach) + 0.5f * Mathf.Abs(gravity) * timeToReach;
                // คำนวณความเร็วในแกน X
                float velocityX = direction.x * (distance / timeToReach);

                // ใช้ความเร็วที่คำนวณมา
                Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
                firedBullet.velocity = projectileVelocity;

                // เพิ่ม BulletBehavior ให้กระสุน
                if (!firedBullet.GetComponent<BulletBehavior>())
                {
                    firedBullet.gameObject.AddComponent<BulletBehavior>();
                }

                // ทำลายกระสุนหลังจาก 3 วินาที
                Destroy(firedBullet.gameObject, 2f);
            }
        }
    }
}
