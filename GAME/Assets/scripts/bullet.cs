using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impacteffect;
    public float explosionRadius = 0f;
    public int damage = 50;
    public void seek(Transform _target)

    {
        target = _target;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;

        }
        Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisframe, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject ins =(GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(ins, 5f);
        if(explosionRadius >0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);

    }
    void Explode()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }
     void Damage(Transform enemy)
    {
        enemy e = enemy.GetComponent<enemy>();
        if (e != null)
        {
            e.Takedamage(damage);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
