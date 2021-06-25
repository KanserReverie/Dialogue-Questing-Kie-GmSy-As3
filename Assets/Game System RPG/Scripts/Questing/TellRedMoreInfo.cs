using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    public class TellRedMoreInfo : Quest
    {
        public bool ToldInfoRed = false;

        public override bool CheckQuestCompletion()
        {
            if (ToldInfoRed)
            {
                return true;
            }
            else
                return false;

        }
    }
}
