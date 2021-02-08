using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum SIDE { Left, Mid, Right}

public class Character : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    public float newXpos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float Xvalue;
    private CharacterController m_char;
    private float x;
    public float DodgeSpeed;
    private Animator m_animator;


    // Start is called before the first frame update
    void Start()
    {
        m_char = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        if (SwipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                newXpos = -Xvalue;
                m_Side = SIDE.Left;
                m_animator.Play("Fox_Run_Left");
            }
            else if (m_Side == SIDE.Right)
            {
                newXpos = 0;
                m_Side = SIDE.Mid;
                m_animator.Play("Fox_Run_Left");
            }
        }
        if (SwipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                newXpos = Xvalue;
                m_Side = SIDE.Right;
                m_animator.Play("Fox_Run_Right");
            }
            else if (m_Side == SIDE.Left)
            {
                newXpos = 0;
                m_Side = SIDE.Mid;
                m_animator.Play("Fox_Run_Right");
            }
        }
        x = Mathf.Lerp(x, newXpos, Time.deltaTime * DodgeSpeed);
        m_char.Move((x - transform.position.x) * Vector3.right);
    }
}
