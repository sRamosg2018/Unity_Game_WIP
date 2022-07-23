using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    private Camera mainCamera;
    private Vector3 mousePos;

    public Bullet_Manager bm; 




    void Start()
    {
        
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButtonDown("Fire2")) bm.changeBullet();

    }



    public void Shoot()
    {

        mousePos = mousePos - transform.position;


        GameObject bullet = Instantiate(bm.GetBullet().gameObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(mousePos.x, mousePos.y).normalized * bm.GetBullet().speed;

    }
}
