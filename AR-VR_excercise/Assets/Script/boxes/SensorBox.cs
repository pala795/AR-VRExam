using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Hands.Gestures;

public class SensorBox : MonoBehaviour
{
    
    [SerializeField] private XRHandPose handPose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
