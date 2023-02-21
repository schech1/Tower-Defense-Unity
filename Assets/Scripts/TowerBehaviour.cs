using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{

    [SerializeField] float shootingSpeed;
    [SerializeField] GameObject bullet;
    float range;
    [SerializeField] float coolDown;
    [SerializeField] GameObject rangeIndicator;
    [SerializeField] int damage;
    Collider2D[] enemiesInRange;
    float lastShotTime;

    void Start()
    {
        range = rangeIndicator.transform.localScale.x / 2;
    }


    void Update()
    {
        ShootAtEnemy();
    }

    void ShootAtEnemy()
    {
        if (Time.time > lastShotTime + coolDown)
        {


            enemiesInRange = Physics2D.OverlapCircleAll(rangeIndicator.transform.position, range, LayerMask.GetMask("Enemy"));
            if (enemiesInRange.Length > 0)
            {
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Vector2 vec2Enemy = enemiesInRange[0].transform.position - spawnedBullet.transform.position;
                spawnedBullet.GetComponent<Rigidbody2D>().AddForce(vec2Enemy * shootingSpeed, ForceMode2D.Impulse);
                lastShotTime = Time.time;
            }
        }
    }
}
