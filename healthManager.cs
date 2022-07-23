using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class healthManager : MonoBehaviour
{

    public Light2D playerLight; 
    public int tempHealth = 10;



    void Start()
    {
        playerLight = gameObject.transform.Find("Point Light 2D").GetComponent<Light2D>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            if(playerLight.pointLightOuterRadius>0.1f)
                playerLight.pointLightOuterRadius -= 0.10f;
            

            tempHealth--;
            Debug.Log(tempHealth);
        }
    }
}
