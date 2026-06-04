using System;
using UnityEngine;
using UnityEngine.XR.Hands.Gestures;

public class LastTpBox : MonoBehaviour
{
    [SerializeField] private DoorOpen doorOpen;
    [SerializeField] private GameObject continuosMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorOpen.SetOpen(true);
            continuosMovement.SetActive(true);
        }
    }
}
