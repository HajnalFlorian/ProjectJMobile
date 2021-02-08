using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code provided by 
public class ControllingCameraAspectScript : MonoBehaviour
{
    void Start()
    {
        //Target ratio
        float targetaspect = 9f / 16f;

        //Get current width and height
        float windowaspect = (float)Screen.width / (float)Screen.height;

        //Calculates the height to apply
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        //Changes camera's rect to match given ratio
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

}