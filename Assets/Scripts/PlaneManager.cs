using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARRaycastManager))]

public class PlaneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ARPlaneManager manager;
    private ARRaycastManager rayManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject popUp;
    [SerializeField]
    private GameObject JengBlocks;

    private GameObject tempBlocks;
    private bool status = true;

    public void EnableTracking()
    {
        manager.requestedDetectionMode = PlaneDetectionMode.Horizontal;
        manager.SetTrackablesActive(true);
        startButton.SetActive(false);
        popUp.SetActive(true);
    }

    private bool SetTouch(out Vector2 touchpos)
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            touchpos = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchpos = default;
            return false;
        }
    }
    void Awake()
    {
        popUp.SetActive(false);
        rayManager = GetComponent<ARRaycastManager>();
        manager = GetComponent<ARPlaneManager>();
        manager.requestedDetectionMode = PlaneDetectionMode.None;
        manager.SetTrackablesActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(SetTouch(out Vector2 touchPos))
        {
            if (rayManager.Raycast(touchPos, hits,TrackableType.PlaneWithinPolygon) && status)
            {
                popUp.SetActive(false);
                var hitPos = hits[0].pose;
                Instantiate(JengBlocks, hitPos.position, Quaternion.identity);
                status = false;
                manager.SetTrackablesActive(false);
                manager.requestedDetectionMode = PlaneDetectionMode.None;
                
            }
        } 
    }
}
