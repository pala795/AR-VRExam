using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class DoorLevel1 : MonoBehaviour
{
   [SerializeField] private ControllerInputActionManager _controllerInputActionManager;
   [SerializeField] private int level;
   private void Start()
   {
      if (level == 1)
      {
         _controllerInputActionManager.smoothMotionEnabled = false;
         _controllerInputActionManager.
      }
   }
}
