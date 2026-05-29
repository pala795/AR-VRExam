using UnityEngine;
using UnityEngine.UI;

public class UIInputLogger : MonoBehaviour
{
    public QuestInputLogger action;
    float triggerValue;
    float gripValue;
    Vector2 thumbstickValue;
    bool primaryButtonPressed;
    bool secondaryButtonPressed;
    bool menuButtonPressed;
    public Slider trigger;
    public Slider grip;
    public Toggle primaryButton;
    public Toggle secondaryButton;
    public Toggle menuButton;
    

    void Start()
    {
        trigger.onValueChanged.AddListener(delegate { TriggerSlider(); });
        grip.onValueChanged.AddListener(delegate { GripSlider(); });
        primaryButtonPressed = action.primaryButtonValue;
        secondaryButtonPressed = action.secondaryButtonValue;
        menuButtonPressed = action.menuButtonValue;
    }

    private void Update()
    {
        TriggerSlider();
        GripSlider();
        Buttons(primaryButtonPressed, primaryButton);
        Buttons(secondaryButtonPressed, secondaryButton);
        Buttons(menuButtonPressed, menuButton);
    }
    void TriggerSlider()
    {
        triggerValue = action.triggerValue;
        trigger.value = triggerValue;
    }
    void GripSlider()
    {
        gripValue = action.gripValue;
        grip.value = gripValue;
    }

    void Buttons(bool value, Toggle button)
    {
        if (value) button.isOn = true;
        else
        {
            button.isOn = false;
        }
    }
}