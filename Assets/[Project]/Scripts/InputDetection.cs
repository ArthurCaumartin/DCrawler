using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;

public class InputDetection : MonoBehaviour
{
    void Start()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            if (gamepad is DualShockGamepad)
            {
                print("PlayStation gamepad");
            }
            else if (gamepad is XInputController)
            {
                print("Xbox gamepad");
            }
        }
        else if (Keyboard.current != null || Mouse.current != null)
        {
            print("Mouse and keyboard");
        }
    }
}
