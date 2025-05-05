using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D bulletPrefab;

    [SerializeField] private float shootDelay = 0.5f;
    private float lastShootTime = -Mathf.Infinity;

    [Header("Projectile Settings")]
    [SerializeField] private float gravity = -9.8f;  // �ç�����ǧ (�س����ö��Ѻ�����)

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShootTime + shootDelay)
        {
            lastShootTime = Time.time;

            // �ŧ���˹������㹨� �繵��˹���š 2D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // ���� Target 价����˹觤�ԡ
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                // ���ҧ����ع����
                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                // �ӹǳ��ȷҧ���������ҧ
                Vector2 direction = hit.point - (Vector2)shootPoint.position; 
                float distance = direction.magnitude; 
                direction.Normalize(); 

                // �ӹǳ���ҷ�����㹡���ԧ
                float timeToReach = Mathf.Sqrt(2 * Mathf.Abs(distance) / Mathf.Abs(gravity)); // �ӹǳ����㹡���ԧ����������ع�֧�������

                // �ӹǳ���������᡹ Y
                float velocityY = (distance / timeToReach) + 0.5f * Mathf.Abs(gravity) * timeToReach;
                // �ӹǳ���������᡹ X
                float velocityX = direction.x * (distance / timeToReach);

                // ��������Ƿ��ӹǳ��
                Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
                firedBullet.velocity = projectileVelocity;

                // ���� BulletBehavior ������ع
                if (!firedBullet.GetComponent<BulletBehavior>())
                {
                    firedBullet.gameObject.AddComponent<BulletBehavior>();
                }

                // ����¡���ع��ѧ�ҡ 3 �Թҷ�
                Destroy(firedBullet.gameObject, 2f);
            }
        }
    }
}
