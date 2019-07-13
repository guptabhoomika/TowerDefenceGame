using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float health;

    [HideInInspector]
    public float speed;
    public Image healthbar;


    private bool isDead = false;
    public float startHealth = 100;
    public int gainMoney;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
        
    }
    public void Takedamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / startHealth;
        if(health <=0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
       
            playerStats.money += gainMoney;
        WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
        
       
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }











  
  
}
