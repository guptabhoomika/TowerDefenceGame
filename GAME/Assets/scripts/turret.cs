using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    
    private Transform target;
    private enemy targetEnemy;
    [Header("General")]
    public float range = 15f;
    [Header("Use bullets (defaults)")]

    public float firerate = 1f;
    private float firecountdown = 0f;
    public GameObject bulletPrefab;
    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRend;
    public int damageOvertime = 30;
    public float slowPct = 0.5f;



    [Header("Unity required variables")]
    public string enemytag = "enemy";
    public Transform pathtorotate;
    public float  turnSpeed= 10f;
   
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("UpdateTarget" , 0f , 0.5f); 
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shordist = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToenemy < shordist)
            {
                shordist = distanceToenemy;
                nearestEnemy = enemy;
            }


        }
        if (nearestEnemy != null && shordist <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<enemy>();
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            if(useLaser)
            {
                if(lineRend.enabled)
                {
                    lineRend.enabled = false;

                }
            }
            return;
        }
        LockOnTarget();
        if(useLaser)
        {
            Laser();
        }
        else
        {
            if (firecountdown <= 0f)
            {
                Shoot();
                firecountdown = 1f / firerate;
            }
            firecountdown -= Time.deltaTime;

        }




    }
     void Laser()
    {
        targetEnemy.Takedamage(damageOvertime * Time.deltaTime);

        targetEnemy.Slow(slowPct);
        

        if (!lineRend.enabled)
            lineRend.enabled = true;
        lineRend.SetPosition(0, firePoint.position);
        lineRend.SetPosition(1, target.position);
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotaion = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(pathtorotate.rotation, lookRotaion, Time.deltaTime * turnSpeed).eulerAngles;
        pathtorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
          GameObject bulletGO =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        if (bullet!= null)
            {
            bullet.seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
           
    }
}
