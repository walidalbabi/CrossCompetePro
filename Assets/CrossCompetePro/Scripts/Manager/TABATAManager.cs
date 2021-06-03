using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TABATAManager : Singleton<TABATAManager>
{
    [HideInInspector]
    public float totalTime;

    [SerializeField]
    private InputField MinutesInput;
    [SerializeField]
    private InputField SecondsInput;

    [SerializeField]
    private InputField RestInput;

    [SerializeField]
    private InputField SetsInput;

    [HideInInspector]
    public int minutes, seconds, sets;

    [HideInInspector]
    public float rest;

    [SerializeField]
    private Text txt;

    TimeSpan timespan;
    public void GetDataFromInputFields()
    {
        if (MinutesInput.text != "")
        {
            minutes = int.Parse(MinutesInput.text);
        }
        else
        {
            minutes = 0;
        }

        if (SecondsInput.text != "")
        {
            seconds = int.Parse(SecondsInput.text);
        }
        else
        {
            seconds = 0;
        }


        if (RestInput.text != "")
        {
            rest = int.Parse(RestInput.text);
        }
        else
        {
            rest = 0;
        }



        if (SetsInput.text != "")
        {
            sets = int.Parse(SetsInput.text);

            if (sets == 0)
                sets = 1;
        }
        else
        {
            sets = 1;
        }



        totalTime = seconds + (minutes * 60f);

        timespan = TimeSpan.FromSeconds((totalTime + rest) * sets);
        txt.text = " Total Time: " + timespan.ToString(@"mm\:ss") + " min";
    }
}
