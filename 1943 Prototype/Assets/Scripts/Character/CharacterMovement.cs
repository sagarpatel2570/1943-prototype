using UnityEngine;
using System.Collections;

/// <summary>
/// this class is responsible for player movement
/// </summary>
public class CharacterMovement : CharacterAbility
{
    public float moveSpeed = 3f;
    public float idleThreshold = 0.05f;
    public float acceleration = 1f;
    public float deceleration = 1f;

    public float MovementSpeed { get; set; }

    float horizontalMovement;
    float verticalMovement;
    Vector3 movementVector;
    public Vector2 CurrentInput;
    Vector2 normalizedInput;
    Vector2 lerpedInput = Vector2.zero;
    float currentAcceleration = 0f;

    public override void Init()
    {
        base.Init();
        MovementSpeed = moveSpeed;
        character.ChangeState(CharacterStates.IDLE);
    }

    public override void ProcessAbility()
    {
        HandleMovement();
    }

    protected override void HandleInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    protected virtual void HandleMovement()
    {
        if ((CurrentInput.magnitude > idleThreshold)
            && (character.state == CharacterStates.IDLE))
        {
            character.ChangeState(CharacterStates.MOVE);
        }

        if ((character.state == CharacterStates.MOVE)
            && (CurrentInput.magnitude <= idleThreshold))
        {
            character.ChangeState(CharacterStates.IDLE);
        }

        DoMovement();
    }

    void DoMovement()
    {
        movementVector = Vector3.zero;
        CurrentInput = Vector2.zero;

        CurrentInput.x = horizontalMovement;
        CurrentInput.y = verticalMovement;

        normalizedInput = CurrentInput.normalized;

        if ((acceleration == 0) || (deceleration == 0))
        {
            lerpedInput = CurrentInput;
        }
        else
        {
            if (normalizedInput.magnitude == 0)
            {
                currentAcceleration = Mathf.Lerp(currentAcceleration, 0f, deceleration * Time.deltaTime);
                lerpedInput = Vector2.Lerp(lerpedInput, lerpedInput * currentAcceleration, Time.deltaTime * deceleration);
            }
            else
            {
                currentAcceleration = Mathf.Lerp(currentAcceleration, 1f, acceleration * Time.deltaTime);
                lerpedInput = Vector2.ClampMagnitude(normalizedInput, currentAcceleration);
            }
        }

        movementVector = lerpedInput;
        movementVector *= MovementSpeed;
        if (movementVector.magnitude > MovementSpeed)
        {
            movementVector = Vector3.ClampMagnitude(movementVector, MovementSpeed);
        }
        
        if ((CurrentInput.magnitude <= idleThreshold) && (character.Controller.CurrentMovement.magnitude < idleThreshold))
        {
            movementVector = Vector3.zero;
        }
        
        character.Controller.SetMovement(movementVector);
    }
}