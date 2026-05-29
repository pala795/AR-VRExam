using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestInputLogger : MonoBehaviour
{
    public InputAction triggerAction;
    public InputAction gripAction;
    public InputAction thumbstickAction;
    public InputAction primaryButtonAction;
    public InputAction secondaryButtonAction;
    public InputAction menuButtonAction;

    public float triggerValue { get; private set; }
    public float gripValue { get; private set; }
    public Vector2 thumbstickValue { get; private set; }
    public bool primaryButtonValue { get; private set; }
    public bool secondaryButtonValue { get; private set; }
    public bool menuButtonValue { get; private set; }

    private void Awake()
    {
        BindAction(triggerAction, OnTriggerPerformed, OnTriggerCanceled);
        BindAction(gripAction, OnGripPerformed, OnGripCanceled);
        BindAction(thumbstickAction, OnThumbstickPerformed, OnThumbstickCanceled);
        BindAction(primaryButtonAction, OnPrimaryButtonPerformed, OnPrimaryButtonCanceled);
        BindAction(secondaryButtonAction, OnSecondaryButtonPerformed, OnSecondaryButtonCanceled);
        BindAction(menuButtonAction, OnMenuButtonPerformed, OnMenuButtonCanceled);
    }

    private void OnMenuButtonPerformed(InputAction.CallbackContext obj)
    {
        menuButtonValue = true;
    }
    
    private void OnSecondaryButtonPerformed(InputAction.CallbackContext obj)
    {
        secondaryButtonValue = true;
    }
    
    private void OnPrimaryButtonPerformed(InputAction.CallbackContext obj)
    {
        primaryButtonValue = true;
    }
    
    private void OnThumbstickPerformed(InputAction.CallbackContext obj)
    {
        thumbstickValue = obj.ReadValue<Vector2>();
    }
    
    private void OnGripPerformed(InputAction.CallbackContext obj)
    {
        gripValue = obj.ReadValue<float>();
    }
    
    private void OnTriggerPerformed(InputAction.CallbackContext obj)
    {
        triggerValue = obj.ReadValue<float>();
    }

    private void OnTriggerCanceled(InputAction.CallbackContext obj)
    {
        triggerValue = 0;
    }

    private void OnGripCanceled(InputAction.CallbackContext obj)
    {
        gripValue = 0;
    }

    private void OnThumbstickCanceled(InputAction.CallbackContext obj)
    {
        thumbstickValue = Vector2.zero;
    }

    private void OnPrimaryButtonCanceled(InputAction.CallbackContext obj)
    {
        primaryButtonValue = false;
    }

    private void OnSecondaryButtonCanceled(InputAction.CallbackContext obj)
    {
        secondaryButtonValue = false;
    }

    private void OnMenuButtonCanceled(InputAction.CallbackContext obj)
    {
        menuButtonValue = false;
    }

    private void BindAction(InputAction action, Action<InputAction.CallbackContext> performed,
        Action<InputAction.CallbackContext> canceled)
    {
        if (action != null)
        {
            action.performed += performed;
            action.canceled += canceled;
            action.Enable();
        }
    }

    private void OnDisable()
    {
        triggerAction?.Disable();
        gripAction?.Disable();
        thumbstickAction?.Disable();
        primaryButtonAction?.Disable();
        secondaryButtonAction?.Disable();
        menuButtonAction?.Disable();
    }

    private void LogInput(InputAction.CallbackContext obj)
    {
        Debug.Log($"{obj.action.name} : {obj.ReadValueAsObject()}");
    }
}