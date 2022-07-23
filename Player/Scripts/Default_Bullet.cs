using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Bullet : Bullet
{
    /*
    public GameObject hitEffect;
    public int damage = 3;
    public int critChance = 1;
    public int critDamageMultiplier = 2;
    public int speed = 4;
    */
    


    private void Start()
    {
     
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        Destroy(gameObject, 1f);

    }


    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Bullet")
        {

         if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
               
                
                if (enemy != null)
                {
                    
                    enemy.TakeDamage(critChanceCalculator(), isCrit);
                   
                   
                }


            }


                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.1f);
                Destroy(gameObject);


        }
    }
    


    int critChanceCalculator()
    {
        int crit = Random.Range(1, 101);
        if (crit <= critChance) { isCrit = true; return damage * critDamageMultiplier; }
        isCrit = false;
        return damage;

    }

}
