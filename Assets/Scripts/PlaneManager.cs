using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]

public class PlaneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ARPlaneManager manager;

    void Awake()
    {
        manager = GetComponent<ARPlaneManager>();
        manager.requestedDetectionMode = PlaneDetectionMode.None;
        manager.SetTrackablesActive(false);
    }

    // Update is called once per frame

    public void EnableTracking()
    {
        manager.requestedDetectionMode = PlaneDetectionMode.Horizontal;
        manager.SetTrackablesActive(true);
    }
}
