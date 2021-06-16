using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniversalRPG.Items;

[RequireComponent(typeof (Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    [field: SerializeField] public Health PlayerHealth { get; set; }
    [Range(0, 50f)] [SerializeField] private float speed;
    [Range(0, 128)] [SerializeField] private int startingInventoryCapacity;
    [SerializeField] private List<Item> startingEquipment;
    public Inventory Inventory { get; private set; }
    public Equipment Equipment { get; private set; }
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        InputSystem.Instance.Moved.AddListener(Move);
        Inventory = new Inventory(startingInventoryCapacity);
        Equipment = new Equipment(startingEquipment);
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
