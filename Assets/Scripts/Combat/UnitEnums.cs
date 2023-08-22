using System;

namespace AFSInterview
{
    public enum UnitName
    {
        LongSwordKnight,
        Archer,
        Druid,
        Catapult,
        Ram
    }

    [Flags]
    public enum UnitAtribute
    {
        None = 0,
        Light = 1 << 0,
        Armored = 1 << 1,
        Mechanical = 1 << 2,
    }
}
