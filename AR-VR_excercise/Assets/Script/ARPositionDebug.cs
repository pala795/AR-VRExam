using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Script
{
    public class ARPositionDebug : MonoBehaviour
    {
        public ARTrackedImageManager trackedImagesManager;
    
        public Transform xrOrigin;
        public Transform cam; 
        private Transform _cube;
        private UnityEngine.XR.ARSubsystems.TrackingState _state = UnityEngine.XR.ARSubsystems.TrackingState.None;

        public TextMeshProUGUI camPosText;
        public TextMeshProUGUI cubePosText;

        private void Awake()
        {
            trackedImagesManager.trackablesChanged.AddListener(OnChanged);
        }

        private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args)
        {
            if (args.added.Count > 0)
            {
                //c'è stato uno spawn
                _cube = args.added[0].transform;
            }

            if (args.updated.Count > 0)
            {
                _state = args.updated[0].trackingState;
                if(_state != UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                    _cube = null;
                else
                    _cube = args.updated[0].transform;
            }      
        
        }

        void Update()
        {
            camPosText.text = "Camera position: " + cam.position.ToString("F2");

            // if (SpawnedItem.AllSpawnedItems.Count > 0)
            // {
            //     cubePosText.text = "Cube position: " + SpawnedItem.AllSpawnedItems[0].transform.position.ToString("F2");
            // }
            if (_cube != null)
            {
                cubePosText.text = "Cube position: " + _cube.position.ToString("F2");
            }
            else
            {
                cubePosText.text = "Cube position: N/A";
            }
        }
    }
}