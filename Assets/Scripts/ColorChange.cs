using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    private void OnMouseDown()
    {
        if(gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            BlockTouchManager.block = gameObject;
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
    }
}
