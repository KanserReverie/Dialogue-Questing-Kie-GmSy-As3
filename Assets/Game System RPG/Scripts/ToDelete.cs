using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debugging.Player;

namespace deletothischeato
{
    public class ToDelete : MonoBehaviour
    {
        [SerializeField] private Text thisTimer;
        [SerializeField] private Movement thisPlayer;
        [SerializeField] private AudioSource normalSound;
        [SerializeField] private AudioSource finishSound;
        private float x = 0;
        private bool doneAll = false;

        private void Update()
        {
            if (!doneAll)
            {
                x += Time.deltaTime;
                thisTimer.text = x.ToString();
            }
            CheckDoneAll();
        }
        private void CheckDoneAll()
        {
            if (thisPlayer.playerMoney >= 286 && thisPlayer.playerRocks >= 40 && FactionsManager.AreFactionsDone && !doneAll)
            {
                doneAll = true;
                normalSound.Pause();
                finishSound.Play();
            }
        }
    }
}