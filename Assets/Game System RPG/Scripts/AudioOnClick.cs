using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicAudio.GamesSystemCert4Assignment3
{
    public class AudioOnClick : MonoBehaviour
    {
        public AudioSource clickSound;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                clickSound.Play();
            }
        }
    }
}