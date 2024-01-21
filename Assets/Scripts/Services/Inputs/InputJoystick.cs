using Inputs;
using UnityEngine;

public class InputJoystick : MonoBehaviour, IInputHandler
{
    [SerializeField] private Joystick _joystick;

    public float HorizontalInput => _joystick.Horizontal;
    public float VerticalInput => _joystick.Vertical;
}
