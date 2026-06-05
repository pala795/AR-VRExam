using System;
using UnityEngine;

public class TargetBox : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            animator.SetBool("Open", true);
        }
    }
}
