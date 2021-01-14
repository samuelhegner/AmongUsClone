using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputAction verticalHorizontalInput;

    private Vector2 verticalHorizontalInputValue;

    public Vector2 VerticalHorizontalInputValue { get => verticalHorizontalInputValue; set => verticalHorizontalInputValue = value; }

    // Start is called before the first frame update
    void Awake()
    {
        verticalHorizontalInput.performed += ctx => verticalHorizontalInputValue = ctx.ReadValue<Vector2>();
        verticalHorizontalInput.canceled += ctx => verticalHorizontalInputValue = Vector2.zero;
    }
 

    private void OnEnable()
    {
        verticalHorizontalInput.Enable();
    }

    private void OnDisable()
    {
        verticalHorizontalInput.Disable();
    }
}
