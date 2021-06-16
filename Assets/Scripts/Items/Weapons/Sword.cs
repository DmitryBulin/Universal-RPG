using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniversalRPG.Items
{
    [CreateAssetMenu(fileName = "New Sword", menuName = "Items/Weapons/Sword")]
    public class Sword : Weapon
    {
        [field: SerializeField] [field : Range(0, 5000)] public int Damage { get; private set; }
        public override void Use(PlayerControl player)
        {

        }
    }
}