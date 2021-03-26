using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private CharacterMouvement playerMouvement;
    public GameObject Mort;

    // Start is called before the first frame update
    void Start()
    {
        playerMouvement = GameObject.FindObjectOfType<CharacterMouvement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            playerMouvement.Alive = false;
        }
    }
}
