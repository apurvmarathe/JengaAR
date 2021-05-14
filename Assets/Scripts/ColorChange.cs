using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        if(gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            if(ColorManager.currentGO == null)
            {
                ColorManager.CurrentGO(gameObject);
            }
            else if(ColorManager.currentGO != gameObject)
            {
                ColorManager.currentGO.GetComponent<Renderer>().material.color = Color.white;
                ColorManager.CurrentGO(gameObject);
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
