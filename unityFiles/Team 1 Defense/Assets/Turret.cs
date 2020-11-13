using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    public float range = 15f;
    // shooting
    public float fireRate = 1f;
    private float fireCountdown = 0f; // makes sure that shooting is of fixed update
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        // eventually change to target enemies closest to home base and in tower's range
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance ) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        // enemy within range
        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            return;
        }
        // Target Lock On:
        Vector3 direction = target.position - transform.position;
        // unity's way of rotations
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 newRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // set y rotation
        partToRotate.rotation = Quaternion.Euler(0f, newRotation.y, 0);

        // Shooting
        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject this_bullet = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = this_bullet.GetComponent<Bullet>();
        if (bullet != null) {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
