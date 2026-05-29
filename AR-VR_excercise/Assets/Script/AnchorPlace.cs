using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

public class AnchorPlace : MonoBehaviour
{
    public Object anchorPrefab;
    private ARAnchorManager _anchorManager;
    private ARPlaneManager _planeManager;
    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Vector2 _touchPosition;
    private bool _spawnRequest;

    private void Awake()
    {
        _planeManager = GetComponent<ARPlaneManager>();
        _raycastManager = GetComponent<ARRaycastManager>();
        _anchorManager = GetComponent<ARAnchorManager>();
    }

    private void Update()
    {
        _spawnRequest = false;

#if UNITY_ANDROID && !UNITY_EDITOR
      if(Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
      {
          _touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        _spawnRequest = true;
      }
#else
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _touchPosition = Mouse.current.position.ReadValue();
                _spawnRequest = true;
            }
        }
#endif
        if (!_spawnRequest)
        {
            return;
        }

        if (_raycastManager.Raycast(_touchPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = _hits[0].pose;
            ARTrackable trackable = _hits[0].trackable;
            ARPlane hitPlane = trackable.GetComponent<ARPlane>();
            if (hitPlane != null)
            {
                ARAnchor anchor = _anchorManager.AttachAnchor(hitPlane, hitPose);
                if (anchor != null)
                {
                    if (anchorPrefab != null)
                    {
                        Instantiate(anchorPrefab, anchor.transform.position, anchor.transform.rotation * Quaternion.Euler(0, 180, 0));
                    }
                }
            }
        }
    }
}
