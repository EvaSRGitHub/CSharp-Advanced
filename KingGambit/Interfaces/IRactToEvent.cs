﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    public interface IRactToEvent
    {
        void ReactToKingBeengAttacked(IAttackable king);
    }
}
