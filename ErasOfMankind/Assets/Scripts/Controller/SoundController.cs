using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController instance = null;

    public AudioSource audio;

    #region Start&Update
    void Awake() {
        instance = this;

        Data.OnSoundChange += OnSoundChangeHandler;
    }
    #endregion

    public void toogleSound() {
        Data.Sound = !Data.Sound;
    }

    #region Handler
    private void OnSoundChangeHandler(bool sound) {
        if (sound) {
            audio.mute = false;
        } else {
            audio.mute = true;
        }
    }
    #endregion
}
