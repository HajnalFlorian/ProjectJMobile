using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMouvement : MonoBehaviour
{
    private Vector3 startTouchPosition, endTouchPosition, jump;
    public Vector2 startPos, direction;
    Rigidbody rb;
    float dirX;
    float speed = 5f;
    public float jumpForce = 2f;
    private bool inJump = false;
    float cpt = 0;
    float tempsMax = 0.1f;
    bool allowCpt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * speed;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    allowCpt = true;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    inJump = true;
                    JumpIfAllowed();
                    break;
            }
            
        }

        //Si le compteur est actif, incrémente cpt. 
        if (allowCpt)
        {
            cpt += Time.deltaTime;

            //Si cpt est supérieur au temps max, lance la méthode de jump, 
            //set inJump à true, reset le compteur et sort de l'incrémentation en settant allowCpt à false;
            if (cpt >= tempsMax)
            {
                allowCpt = false;
                inJump = true;
                JumpIfAllowed();
                cpt = 0;
            }
        }
        //swipeCheck();
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * dirX * speed * Time.fixedDeltaTime;
        jump = transform.up * jumpForce * Time.deltaTime;   
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    /*private void swipeCheck()
    {
        /* if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
             startTouchPosition = Input.GetTouch(0).position;
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
             endTouchPosition = Input.GetTouch(0).position;
         if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
             inJump = true;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    inJump = true;
                    break;
            }
        }
    }*/
        private void JumpIfAllowed()
        {
            if (inJump)
            {
            rb.MovePosition(rb.position + jump);
            //rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                inJump = false;

            }
        }

        private void FixedUpdate()
        {


        }
}
