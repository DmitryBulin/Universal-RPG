using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    [Range(0, 50f)] [SerializeField] private float speed;
    [Range(0, 128)] [SerializeField] private int startingInventoryCapacity;
    public Health PlayerHealth { get => health; }
    [SerializeField] private Health health;
    public InventorySystem Inventory { get; private set; }
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        InputSystem.Instance.Moved.AddListener(Move);
        Inventory = new InventorySystem(startingInventoryCapacity);
    }
    
    private void Move(Vector3 movementVect)
    {
        rigidBody.velocity = movementVect * speed;
    }

    private void OnDisable()
    {
        InputSystem.Instance.Moved.RemoveListener(Move);
    }

}
