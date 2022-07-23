using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Manager : MonoBehaviour
{
    public Bullet currentBullet;

    public Bullet defaultBullet;
    public Bullet fireBullet;






    void Start()
    {
        currentBullet = defaultBullet;
    }


    void Update()
    {
        
    }



    public void setBullet(Bullet newBullet)
    {

        currentBullet = newBullet; 

    }


    public Bullet GetBullet()
    {

        return currentBullet;

    }


    public void changeBullet()
    {
        if(currentBullet == defaultBullet)
        {
            setBullet(fireBullet);
        }
        else
        {
            setBullet(defaultBullet);
        }
            
            
    }
}
