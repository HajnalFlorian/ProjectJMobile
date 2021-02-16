using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMouvement : MonoBehaviour
{
    private Vector3 startTouchPosition, endTouchPosition;
    public Vector2 startPos, direction;

    Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 0.1f;

    private float dirX;
    private float cpt = 0;
    private float tempsMax = 0.1f;
    private bool allowCpt;

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
                    JumpIfAllowed();
                    break;
            }
            
        }
        
        if (allowCpt)
        {
            cpt += Time.deltaTime;
            
            if (cpt >= tempsMax)
            {
                allowCpt = false;
                //JumpIfAllowed();
                cpt = 0;
            }
        }
        

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * dirX * speed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
    }
    

    private void JumpIfAllowed()
    {
        if (isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

    }

    private bool isGrounded()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
        foreach(Collider col in hitColliders)
        {
            if(col.tag == "Ground")
            {
                return true;
            }
        }

        return false;

        
    }
}
