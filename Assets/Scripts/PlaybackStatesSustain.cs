using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackStatesSustain : MonoBehaviour
{

    private FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    [SerializeField]
    private TMPro.TMP_Text text;

    FMOD.Studio.PLAYBACK_STATE PlaybackState(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlaybackState(instance) != FMOD.Studio.PLAYBACK_STATE.PLAYING && PlaybackState(instance) != FMOD.Studio.PLAYBACK_STATE.SUSTAINING)
            {
                instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
                instance.start();
            }
            else if (PlaybackState(instance) == FMOD.Studio.PLAYBACK_STATE.SUSTAINING)
            {
                instance.triggerCue();
            }
            else
            {
                Debug.Log("Instanz is already playing!");
            }
        }
      
        text.SetText("Playback State: " + PlaybackState(instance).ToString());
    }

}
