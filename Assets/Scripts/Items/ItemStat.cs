using UnityEngine;
using System;

namespace UniversalRPG.Items
{
    [Serializable]
    public struct ItemStat
    {
        [field: SerializeField] public ItemStatType StatType { get; private set; }
        [field: SerializeField] [field : Range(0, 1000f)] public float StatValue { get; private set; }
    }
}
