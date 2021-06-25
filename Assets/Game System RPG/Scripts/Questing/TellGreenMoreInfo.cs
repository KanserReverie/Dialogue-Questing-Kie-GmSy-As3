using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Quests
{
    public class TellGreenMoreInfo : Quest
    {
        public bool ToldInfoGreen = false;

        public override bool CheckQuestCompletion()
        {
            if (ToldInfoGreen)
            {
                return true;
            }
            else
                return false;

        }
    }
}