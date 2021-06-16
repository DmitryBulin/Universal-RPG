using System.Collections.Generic;

namespace UniversalRPG.Items
{
    public interface ICharacterizeable
    {
        List<ItemStat> ItemStats { get; }
    }
}