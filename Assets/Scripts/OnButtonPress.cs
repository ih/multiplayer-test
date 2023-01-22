/**
 * From learn.unity.com VR Project Setup
 * https://learn.unity.com/tutorial/vr-project-setup?pathwayId=627c12d8edbc2a75333b9185&missionId=62554983edbc2a76a27486cb#
 *
 * This asset is governed by the Asset Store EULA
 */

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Checks for button input on an input action
/// </summary>
public class OnButtonPress : MonoBehaviour
{
    [Tooltip("Actions to check")]
    public InputAction action = null;

    // When the button is pressed
    public UnityEvent OnPress = new UnityEvent();

    // When the button is released
    public UnityEvent OnRelease = new UnityEvent();

    private void Awake()
    {
        action.started += Pressed;
        action.canceled += Released;
    }

    private void OnDestroy()
    {
        action.started -= Pressed;
        action.canceled -= Released;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        OnPress.Invoke();
    }

    private void Released(InputAction.CallbackContext context)
    {
        OnRelease.Invoke();
    }
}
