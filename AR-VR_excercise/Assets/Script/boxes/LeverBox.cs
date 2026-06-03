using System;
using UnityEngine;

public class LeverBox : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Handle") animator.SetBool("LeverPulled", true);
        if(other.tag == "Player") animator.SetBool("PlayerPassed", false);
    }
}
