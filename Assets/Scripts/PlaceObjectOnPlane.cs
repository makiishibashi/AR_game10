using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    public static PlaceObjectOnPlane instance;
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public GameObject shoot;
    private Pose placementPose;
    private Transform placementTransform;
    private bool placementPoseIsValid = false;
    public bool isObjectPlaced;
   


    private TrackableId placedPlaneId = TrackableId.invalidId;

    ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public static event Action onPlacedObject;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        isObjectPlaced = false;
        m_RaycastManager = GetComponent<ARRaycastManager>();
        shoot.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isObjectPlaced)
        {
            UpdatePlacementPosition();
            UpdatePlacementIndicator();


            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
            shoot.SetActive(true);
        }
        }
    }
    
    


    private void UpdatePlacementPosition()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        if (m_RaycastManager.Raycast(screenCenter, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            placementPoseIsValid = s_Hits.Count > 0;
            if (placementPoseIsValid)
            {
                placementPose = s_Hits[0].pose;
                placedPlaneId = s_Hits[0].trackableId;

                var planeManager = GetComponent<ARPlaneManager>();
                ARPlane arPlane = planeManager.GetPlane(placedPlaneId);
                placementTransform = arPlane.transform;
            }
        }
    }//end of UpadatePlacementIndicatior

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementTransform.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }

    }
    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position, placementTransform.rotation);
        onPlacedObject?.Invoke();
        isObjectPlaced = true;
        placementIndicator.SetActive(false);
    }

}

