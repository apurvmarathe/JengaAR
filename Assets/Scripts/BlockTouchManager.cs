using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTouchManager : MonoBehaviour
{
    private Touch touch;
    private Vector3 worldPos;
    public float moveSpeed ;
    public static GameObject block;
    private GameObject blockCopy;
    private Vector3 touchPosNear;
    private Vector3 touchPosFar;
    private Vector3 newPos;
    private Vector3 newTouch;
    private Vector3 updatedPos;
    private Ray projectRay;
    private RaycastHit hit;
    private int layerMask =  1 << 6;
    

    private void FixedUpdate()
    {

        if(Input.touchCount > 0 && block != null)
        {
         
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                projectRay = GenerateRay(touch);

                if(Physics.Raycast(projectRay.origin, projectRay.direction, out hit,layerMask))
                {
                    if(block == hit.transform.gameObject)
                    {
                        blockCopy = hit.transform.gameObject;
 
                    }
                }
            }

            if(touch.phase == TouchPhase.Moved )
            {
                touch = Input.GetTouch(0);
                projectRay = GenerateRay(touch);
                if (Physics.Raycast(projectRay.origin, projectRay.direction, out hit, layerMask))
                {
                    if (blockCopy == hit.transform.gameObject)
                    {
                        //newTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,hit.transform.position.z));
                        //newPos = new Vector3(newTouch.x, newTouch.y,hit.transform.position.z);
                        //print(touch.position);
                        newPos = Camera.main.WorldToScreenPoint(hit.transform.position);
                        hit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,newPos.y,newPos.z));
                        //hit.transform.position = Camera.main.ScreenToWorldPoint(updatedPos);
                        //Debug.DrawLine(Camera.main.transform.position,newPos, Color.green);
                    }
                }
            }
            

        }
        
    }

    private Ray GenerateRay(Touch touch)
    {
        touchPosNear = new Vector3(touch.position.x,touch.position.y, Camera.main.nearClipPlane);
        touchPosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
        Vector3 touchposN = Camera.main.ScreenToWorldPoint(touchPosNear);
        Vector3 touchposF = Camera.main.ScreenToWorldPoint(touchPosFar);
        Ray tempRay = new Ray(touchposN, touchposF - touchposN);
        return tempRay;
    }
}
