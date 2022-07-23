using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Camera cam;
    public Light2D pointLight2D;

    public Transform mousePosition;

    private bool isFacingRight;

    Vector2 movement;

    Animator animator;

    SpriteRenderer monkHead, monkBody;





    private void Start()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        monkHead = transform.GetChild(0).GetComponent<SpriteRenderer>();
        monkBody = transform.GetChild(1).GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));


        if (mousePosition.position.x < transform.position.x)
        {
            monkHead.flipX = true;

        }
        else
        {
            monkHead.flipX = false;




        }

    }


    void FixedUpdate()
    {

        if (movement.x < 0)
        {
            monkBody.flipX = true;
            animator.SetBool("isMovingLeft", true);
            animator.SetBool("isMovingRight", false);


        }
        else
        {
            monkBody.flipX = false;
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", true);
        }





        if (movement != Vector2.zero)
        {

            rb.MovePosition(rb.position + (movement * moveSpeed * Time.deltaTime));


        }
        else
        {
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingLeft", false);

        }


        // Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

    }


    }

