using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackStates : MonoBehaviour
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
            if (PlaybackState(instance) != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
                instance.start();
            }
            else
            {
                Debug.Log("Instance is already playing!");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (PlaybackState(instance) == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                instance.release();
            }
            else
            {
                Debug.Log("Instance is not playing!");
            }         
        }
        text.SetText("Playback State: " + PlaybackState(instance).ToString());
    }

}
