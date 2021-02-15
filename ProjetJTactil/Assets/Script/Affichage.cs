using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Affichage : MonoBehaviour
{
    public CharacterMouvement affice;
    public Text directiontext;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        directiontext.text = affice.direction.ToString();
    }
}
