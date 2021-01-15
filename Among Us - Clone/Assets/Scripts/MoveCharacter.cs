using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour, IDependencyFiller
{

    public Action<bool> characterMovingEvent;

    private PlayerInput playerInput;
    private Rigidbody2D rigidbody2D;

    private Vector2 movementForce;
    [SerializeField] private float movementSpeed = 1f;
    bool isMoving;


    void Start()
    {
        FillClassDependencies();
    }

    void FixedUpdate()
    {
        movementForce = calculateMovementForce();
        rigidbody2D.velocity = movementForce;
        UpdateIsCharacterMoving(movementForce);
    }

    private void UpdateIsCharacterMoving(Vector2 movementForce)
    {
        bool isCharacterMovingCurrentFrame = movementForce.magnitude > 0;
        CheckIfMovingEventNeedsTriggering(isCharacterMovingCurrentFrame);
    }

    private void CheckIfMovingEventNeedsTriggering(bool isCharacterMovingCurrentFrame)
    {
        if (isMoving != isCharacterMovingCurrentFrame)
        {
            isMoving = isCharacterMovingCurrentFrame;
            characterMovingEvent?.Invoke(isMoving);
        }
    }

    private Vector2 calculateMovementForce()
    {
        Vector2 inputDirection = playerInput.VerticalHorizontalInputValue;
        Vector2 calculatedForce = multiplyDirectionBySpeed(inputDirection);
        return calculatedForce;
    }

    private Vector2 multiplyDirectionBySpeed(Vector2 inputDirection)
    {
        Vector2 speedModifiedForce = inputDirection * movementSpeed;
        return speedModifiedForce;
    }

    public void FillClassDependencies()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
