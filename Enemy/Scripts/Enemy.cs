using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 5;
    //[SerializeField] private int damage = 1;
    [SerializeField] private GameObject floatingDamageParentPrefab;
    [SerializeField] private GameObject floatingCritDamageParentPrefab;
    [SerializeField] private GameObject deathEffect;
    

    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private Light2D playerLight;







    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        playerLight = GameObject.FindGameObjectWithTag("Player").transform.Find("Point Light 2D").GetComponent<Light2D>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction; 
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }



    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)rb.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damage, bool crit) {


        showDamage(damage.ToString(), crit);
        health -= damage;
        if (health <= 0)
        {
            playerLight.pointLightOuterRadius += 0.10f;
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

}



    void showDamage(string text, bool crit) //recibe el daño y si ha sido un golpe crítico o no
    {
        Vector3 randomPosition = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        if (crit && floatingCritDamageParentPrefab)
        {

                GameObject prebaf = Instantiate(floatingCritDamageParentPrefab, transform.position + randomPosition, Quaternion.identity);
                prebaf.GetComponentInChildren<TextMesh>().text = text;
            
        }
        else if(!crit && floatingDamageParentPrefab)
        {
                GameObject prebaf = Instantiate(floatingDamageParentPrefab, transform.position + randomPosition, Quaternion.identity);
                prebaf.GetComponentInChildren<TextMesh>().text = text;
            }
        }




}




