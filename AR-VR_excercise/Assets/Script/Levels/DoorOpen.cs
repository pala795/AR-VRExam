using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool open = false;
    [SerializeField] private GameObject objectToActive;
    [SerializeField] private GameObject objectToDeActive;
    [SerializeField] private DoorLevel1 doorLevel1;    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && open)
        {
            objectToActive.SetActive(true);
            objectToDeActive.SetActive(false);
            
            
        }
    }

    public bool SetOpen(bool value)
    {
        open = value;
        return open;
    }

    private bool GetOpen()
    {
        return open;
    }
}
