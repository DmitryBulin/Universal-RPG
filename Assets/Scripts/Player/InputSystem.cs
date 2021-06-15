using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{

    [Range(0, 2f)] [SerializeField] private float mainAttackCooldown = 0.05f;
    [Range(0, 2f)] [SerializeField] private float secondaryAttackCooldown = 0.05f;
    [Range(0, 2f)] [SerializeField] private float useActionCooldown = 0.05f;
    [Range(0, 2f)] [SerializeField] private float interractActionCooldown = 0.05f;


    public UnityEvent<Vector3> Moved { get; private set; } = new UnityEvent<Vector3>();
    public UnityEvent MainAttackDone { get; private set; } = new UnityEvent();
    public UnityEvent SecondaryAttackDone { get; private set; } = new UnityEvent();
    public UnityEvent UseActionDone { get; private set; } = new UnityEvent();
    public UnityEvent InterractActionDone { get; private set; } = new UnityEvent();

    private InputControls actions;
    private float mainAttackTimer, secondaryAttackTimer, useActionTimer, interractActionTimer;
    private float deltaTimer;

    private bool AbleToControl => true;
    private bool AbleToMainAttack => mainAttackTimer >= mainAttackCooldown && actions.Gameplay.MainAttack.triggered;
    private bool AbleToSecondaryAttack => secondaryAttackTimer >= secondaryAttackCooldown && actions.Gameplay.SecondaryAttack.triggered;
    private bool AbleToUseAction => useActionTimer >= useActionCooldown && actions.Gameplay.Use.triggered;
    private bool AbleToInterractAction => interractActionTimer >= interractActionCooldown && actions.Gameplay.Interract.triggered;

    public static InputSystem Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
        actions = new InputControls();
        actions.Gameplay.MainAttack.performed += OperateMainAttackAction;
        actions.Gameplay.SecondaryAttack.performed += OperateSecondaryAttackAction;
        actions.Gameplay.Use.performed += OperateUseAction;
        actions.Gameplay.Interract.performed += OperateInterractAction;

    }

    private void OnEnable()
    {
        actions.Gameplay.Enable();
        mainAttackTimer = mainAttackCooldown;
        secondaryAttackTimer = secondaryAttackCooldown;
        useActionTimer = useActionCooldown;
        interractActionTimer = interractActionCooldown;
    }

    private void Update()
    {
        if (!AbleToControl) return;

        OperateMoveAction();

        deltaTimer = Time.deltaTime;
        mainAttackTimer += deltaTimer;
        secondaryAttackTimer += deltaTimer;
        useActionTimer += deltaTimer;
        interractActionTimer += deltaTimer;
    }

    private void OperateMoveAction()
    {
        Vector2 movementVector = actions.Gameplay.Move.ReadValue<Vector2>();
        Moved?.Invoke(
            new Vector3(
                movementVector.x,
                0,
                movementVector.y
                )
            );
    }

    private void OperateMainAttackAction(CallbackContext ctx)
    {
        if (!AbleToMainAttack || !AbleToControl) return;
        mainAttackTimer = 0;
        MainAttackDone?.Invoke();
    }

    private void OperateSecondaryAttackAction(CallbackContext ctx)
    {
        if (!AbleToSecondaryAttack || !AbleToControl) return;
        secondaryAttackTimer = 0;
        SecondaryAttackDone?.Invoke();
    }

    private void OperateUseAction(CallbackContext ctx)
    {
        if (!AbleToUseAction || !AbleToControl) return;
        useActionTimer = 0;
        UseActionDone?.Invoke();
    }

    private void OperateInterractAction(CallbackContext ctx)
    {
        if (!AbleToInterractAction || !AbleToControl) return;
        interractActionTimer = 0;
        InterractActionDone?.Invoke();
    }

    private void OnDisable()
    {
        actions.Gameplay.Disable();
    }

}
