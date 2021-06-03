using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EMOMManager : Singleton<EMOMManager>
{
    [HideInInspector]
    public float totalTime;

    [SerializeField]
    private InputField MinutesInput;
    [SerializeField]
    private InputField SecondsInput;


    [SerializeField]
    private InputField SetsInput;

    [HideInInspector]
    public int minutes, seconds, sets;

    [SerializeField]
    private Text EMOMTitle , totalTimeText;

    [SerializeField]
    private GameObject AddSetsBtn, RemoveSetsBtn, setsText;

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


        if (SetsInput.gameObject.activeInHierarchy)
        {
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
        }
        else
            sets = 9999;
        



        totalTime = seconds + (minutes * 60f);

 

        timespan = TimeSpan.FromSeconds(totalTime);
        EMOMTitle.text = "Every " + timespan.ToString(@"mm\:ss") + " for " + (sets);

        if (sets < 999)
        {
            timespan = TimeSpan.FromSeconds(totalTime * sets);
            totalTimeText.text = " Total Time: " + timespan.ToString(@"mm\:ss") + " min";
        }
        else
        {
            totalTimeText.text = " Total Time: ~ min";
        }
    }
    


    public void RemoveSets()
    {
        AddSetsBtn.SetActive(true);
        RemoveSetsBtn.SetActive(false);
        setsText.SetActive(false);
        SetsInput.gameObject.SetActive(false);

        AddSetsBtn.transform.LeanMoveLocalY(-144f, 0.2f);
        RemoveSetsBtn.transform.LeanMoveLocalY(-144f, 0.1f);

    }

    public void AddSets()
    {
        AddSetsBtn.SetActive(false);
        RemoveSetsBtn.SetActive(true);
        setsText.SetActive(true);
        SetsInput.gameObject.SetActive(true);

        sets = 1;

        AddSetsBtn.transform.LeanMoveLocalY(-659.69f, 0.1f);
        RemoveSetsBtn.transform.LeanMoveLocalY(-659.69f, 0.2f);
    }
}
