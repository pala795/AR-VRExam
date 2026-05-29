using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

namespace Script
{
    public class PlaceOnPlane : MonoBehaviour
    {
        public Object VerticalObjToPlace;
        public Object HorizontalObjToPlace;

        private ARPlaneManager _planeManager;
        private ARRaycastManager _raycastManager;
        private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
        private Vector2 _touchPosition;
        private bool _spawnRequest;
        
        private bool _planeActivated;

        private void Awake()
        {
            _planeManager = GetComponent<ARPlaneManager>();
            _raycastManager = GetComponent<ARRaycastManager>();
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
                var trackableId = _hits[0].trackableId;
                var plane = _planeManager.GetPlane(trackableId);
                if (plane.alignment == PlaneAlignment.HorizontalUp)
                {
                    //usa il primo hit trovato
                    Pose hitPose = _hits[0].pose;
                    //istanzia l'oggetto 
                    Instantiate(HorizontalObjToPlace, hitPose.position, hitPose.rotation * Quaternion.Euler(0, 180, 0));
                }

                if (plane.alignment == PlaneAlignment.Vertical)
                {
                    //usa il primo hit trovato
                    Pose hitPose = _hits[0].pose;
                    //istanzia l'oggetto 
                    Instantiate(VerticalObjToPlace, hitPose.position, hitPose.rotation * Quaternion.Euler(0, 180, 0));
                }
            }
        }
    }
}
// ESERCIZIO: Spawnare sui muri dei quadri e sui pavimenti dei tappeti, a seconda dell'orientamento del piano colpito dal raycast.
// Suggerimenti: 
// ARRaycastHit.trackableId ci permette di recuperare l'id del trackable (in questo caso del piano) colpito dal raycast.
// ArPlaneManager.GetPlane(trackableId) ci permette di recuperare il piano associato a quell'id
// ARPlane.alignment ci permette di recuperare l'orientamento del piano