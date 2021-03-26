using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMouvement : MonoBehaviour
{
    private Vector3 startTouchPosition, endTouchPosition;
    public Vector2 startPos, direction;

    Rigidbody rb;

<<<<<<< Updated upstream
    public float speed = 10f;
=======
    public GameObject score;
    public ScoreManager scoreManager;
    public Text scoreText;
    public Text highScoreText;

    private float speed = 8.0f;
>>>>>>> Stashed changes
    public float gyroSpeed = 5f;
    public float jumpForce = 0.1f;

    private float dirX;
    private float cpt = 0;
    private float tempsMax = 0.1f;
    private bool allowCpt;

<<<<<<< Updated upstream
    bool Alive = true;
=======
    private float scoreF;


    public bool Alive;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        dirX = Input.acceleration.x * gyroSpeed;
=======
        if (Alive)
        {
            dirX = Input.acceleration.x * gyroSpeed;

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
                        //JumpIfAllowed();
                        break;
                }

            }

            if (allowCpt)
            {
                cpt += Time.deltaTime;

                if (cpt >= tempsMax)
                {
                    allowCpt = false;
                    JumpIfAllowed();
                    cpt = 0;
                }
            }
>>>>>>> Stashed changes

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

        if (!Alive)
        {
            return;
        }
<<<<<<< Updated upstream
        if (transform.position.y < -5)
=======
        else if (!Alive)
>>>>>>> Stashed changes
        {
            Die();
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * dirX * speed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        speed += 0.001f;

        
        
    }

    public void Die()
    {
<<<<<<< Updated upstream
        Alive = false;
        // restart the game 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
=======
        deatthMenu.SetActive(true);
        Time.timeScale = 0;
        score.SetActive(false);
        scoreF = scoreManager.score;
        if(PlayerPrefs.GetFloat("HighScore") < scoreF)
        {
            PlayerPrefs.SetFloat("HighScore", scoreF);
        }
        highScoreText.text = "highScore: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        Debug.Log(PlayerPrefs.GetFloat("HighScore"));
        Debug.Log(scoreF);

        scoreText.text = "Score: " + Mathf.Round(scoreManager.score);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
    // augmentation de la vitesse
    public void setSpeed(float modifier)
    {
        speed = 8.0f + modifier;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
       // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }
>>>>>>> Stashed changes
}
