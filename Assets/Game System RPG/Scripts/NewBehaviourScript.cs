using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicONGUI.GamesSystemCert4Assignment3
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private Vector2 scr;
        void OnGUI()//OnGUI
        {
            //set up our ratio messurements for 16:9
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;

            GUI.Box(new Rect(0, Screen.height / 2 - (Screen.height / 7) * 3, Screen.width, Screen.height / 7), "NPC Dialogue");

            GUI.Box(new Rect(0, Screen.height / 2 - Screen.height / 15, Screen.width, Screen.height / 2 + Screen.height / 15), "Dialogue options");
            for (int i = 0; i < 3; i++)
            {
                int y = i + 1;
                GUI.Box(new Rect(Screen.width * 1 / 24, Screen.height / 2 + (Screen.height / 6) * i, Screen.width * 22 / 24, Screen.height / 6), "Response " + y);

            }
        }
    }
}