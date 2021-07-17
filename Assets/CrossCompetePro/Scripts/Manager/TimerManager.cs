using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour
{

    //To Eterate through rest and totaltime and rounds
    [HideInInspector]
    public int rounder, determiner, countForRounds;
    [SerializeField]
    private GameObject FinishBtns, timerPanel;

    private bool canCountAgain;

    private float halfTime;

    #region Counter
    [SerializeField]
    private InputField HoursInput;
    [SerializeField]
    private InputField MinutesInput;
    [SerializeField]
    private InputField SecondsInput;

    [SerializeField]
    private Slider fillSlider;
    [SerializeField]
    private Text[] counterText;

    [SerializeField]
    private GameObject[] CounterBtns;

    private int hours, minutes, seconds;

    private float totalTimeForReset, totalTime;

    private bool StartCounting;

    TimeSpan timerrr;


    #endregion Counter

    #region AMRAP

    [SerializeField]
    private GameObject AmrapProgress;

    [SerializeField]
    private GameObject[] amrapBackBtn;

    [SerializeField]
    private Slider AmrapFillSlider;
    [SerializeField]
    private Text[] AmrapText, AmrapState, AmrapTitle;

    private float amrapTotalTime;

    private bool StartAmrapbool;

    #endregion AMRAP

    #region ForTime

    [SerializeField]
    private GameObject ForTimeProgress;

    [SerializeField]
    private GameObject[] ForTimeBackBtn;

    [SerializeField]
    private Slider ForTimeFillSlider;
    [SerializeField]
    private Text[] ForTimeText, ForTimeState, ForTimeTitle;

    private float ForTimeTotalTime;

    private bool StartForTimebool;

    #endregion ForTime

    #region EMOM

    [SerializeField]
    private GameObject EMOMProgress;

    [SerializeField]
    private GameObject[] EMOMBackBtn;

    [SerializeField]
    private Slider EMOMFillSlider;
    [SerializeField]
    private Text[] EMOMText, EMOMState, EMOMTitle;

    private float EMOMTotalTime;

    private bool StartEMOMbool;

    #endregion EMOM

    #region TABATA

    [SerializeField]
    private GameObject TABATAProgress;

    [SerializeField]
    private GameObject[] TABATABackBtn;

    [SerializeField]
    private Slider TABATAFillSlider;
    [SerializeField]
    private Text[] TABATAText, TABATAState, TABATATitle;

    private float TABATATotalTime;

    private bool StartTABATAbool;

    #endregion TABATA

    // Update is called once per frame
    void Update()
    {
        if (!timerPanel.activeInHierarchy)
            return;

        if (StartCounting)
        {
            fillSlider.value = (float)timerrr.TotalSeconds;
            SetCounter();
            foreach (var txt in counterText)
                txt.text = timerrr.ToString(@"hh\:mm\:ss");
        }

        if (countForRounds <= rounder && canCountAgain && AmrapProgress.activeInHierarchy)
        {
            StartAmrap();
        }

        if (countForRounds <= rounder && canCountAgain && ForTimeProgress.activeInHierarchy)
        {
            StartForTime();
        }

        if (countForRounds <= rounder && canCountAgain && EMOMProgress.activeInHierarchy)
        {
            StartEMOM();
        }

        if (countForRounds <= rounder && canCountAgain && TABATAProgress.activeInHierarchy)
        {
            StartTABATA();
        }

        if (StartAmrapbool)
        {
            AmrapFillSlider.value = (float)timerrr.TotalSeconds;
            SetAmrapCounter();
            foreach (var txt in AmrapText)
                txt.text = timerrr.ToString(@"mm\:ss");

            foreach (var txt in AmrapState)
                switch (determiner)
                {
                    case 1:
                            if(countForRounds != 0)
                            txt.text = "Rest";
                            else
                            txt.text = "Get Ready!";

                        break;
                    case 2:
                        txt.text = "Seconds";
                        break;
                }


        }

        if (StartForTimebool)
        {
            ForTimeFillSlider.value = (float)timerrr.TotalSeconds;
            SetForTimeCounter();
            foreach (var txt in ForTimeText)
                txt.text = timerrr.ToString(@"mm\:ss");

            foreach (var txt in ForTimeState)
                switch (determiner)
                {
                    case 1:
                        if (countForRounds != 0)
                            txt.text = "Rest";
                        else
                            txt.text = "Get Ready!";
                        break;
                    case 2:
                        txt.text = "Seconds";
                        break;
                }


        }

        if (StartEMOMbool)
        {
            EMOMFillSlider.value = (float)timerrr.TotalSeconds;
            SetEMOMCounter();
            foreach (var txt in EMOMText)
                txt.text = timerrr.ToString(@"mm\:ss");

            foreach (var txt in EMOMState)
                txt.text = "Seconds";


        }

        if (StartTABATAbool)
        {
            TABATAFillSlider.value = (float)timerrr.TotalSeconds;
            SetTABATACounter();
            foreach (var txt in TABATAText)
                txt.text = timerrr.ToString(@"mm\:ss");

            foreach (var txt in TABATAState)
                switch (determiner)
                {
                    case 1:
                        if (countForRounds != 0)
                            txt.text = "Rest";
                        else
                            txt.text = "Get Ready!";
                        break;
                    case 2:
                        txt.text = "Seconds";
                        break;
                }


        }

    }

    public void OnFinishPressed(bool AndPause)
    {
        if (!AndPause)
        {
            totalTime = 1;
        }
        else
        {
            amrapTotalTime = 1;
            EMOMTotalTime = 1;
            ForTimeTotalTime = 1;
            TABATATotalTime = 1;
            StartAmrapbool = false;
            StartEMOMbool = false;
            StartForTimebool = false;
            StartTABATAbool = false;

            FinishBtns = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            FinishBtns.SetActive(false);
        }
    }

    #region CounterFunctions

    public void StartCounter()
    {
        hours = int.Parse(HoursInput.text);
        minutes = int.Parse(MinutesInput.text);
        seconds = int.Parse(SecondsInput.text);

        if (HoursInput.text == "")
            hours = 0;
        if (MinutesInput.text == "")
            minutes = 0;
        if (SecondsInput.text == "")
            seconds = 0;

        // There IS Time To Count
        if (hours + minutes + seconds >= 1)
        {
            SetCounterForm();
            StartCounting = true;


            //SetBtns
            CounterBtns[0].LeanMoveLocal(new Vector2(0f, -1415.5f), 0.3f);
            CounterBtns[1].LeanMoveLocal(new Vector2(0f, -618.88f), 0.3f);
            CounterBtns[2].LeanMoveLocal(new Vector2(0f, -874.89f), 0.3f);

        }
        else
        {
            StopCounter();
        }
    }

    public void StopCounter()
    {
        StartCounting = false;

        //SetBtns
        CounterBtns[0].LeanMoveLocal(new Vector2(0f, -742.92f), 0.3f);
        CounterBtns[1].LeanMoveLocal(new Vector2(0f, -1415.5f), 0.3f);
        CounterBtns[2].LeanMoveLocal(new Vector2(0f, -1415.5f), 0.3f);
    }

    public void ResetCounter()
    {
        totalTime = totalTimeForReset;
    }

    //Setting Counter Form
    private void SetCounterForm()
    {
        totalTime = seconds + (minutes * 60) + (hours * 3600);
        halfTime = totalTime / 2;
        totalTimeForReset = seconds + (minutes * 60) + (hours * 3600);
        timerrr = TimeSpan.FromSeconds(totalTime);
        fillSlider.maxValue = totalTime;
    }


    //Setting Counter At Runtime
    private void SetCounter()
    {
        totalTime -= Time.deltaTime;
        timerrr = TimeSpan.FromSeconds(totalTime);

        if (totalTime > 0)
        {
            if (totalTime < 1)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[1]);
            else if (totalTime < 4)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[0]);
            else if (totalTime > halfTime && totalTime < halfTime + 0.9)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[4]);
            else if (totalTime > 10f && totalTime < 10.9f)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[5]);
        }
        else
            StopCounter();


           
    }

    #endregion CounterFunctions

    #region AMRAPFunctions

    public void ShowAmrap()
    {

        if (AmrapManager.instance.totalTime <= 0)
            return;



        var panelColor = AmrapProgress.GetComponent<CanvasGroup>();

        rounder = AmrapManager.instance._amrap.Count - 1;
        StartAmrapbool = false;
        countForRounds = 0;
        determiner = 0;
        canCountAgain = false;

        if (AmrapProgress.activeInHierarchy)
        {
            rounder = 0;
            determiner = 0;
            countForRounds = 0;
            canCountAgain = false;

            amrapBackBtn[0].SetActive(true);
            amrapBackBtn[1].SetActive(false);

            AmrapProgress.SetActive(false);

        }
        else
        {
            amrapBackBtn[0].SetActive(false);
            amrapBackBtn[1].SetActive(true);

            AmrapProgress.SetActive(true);

            panelColor.alpha = 0;
            panelColor.LeanAlpha(1f, 0.3f);


            if (FinishBtns != null)
                FinishBtns.SetActive(true);

            StartAmrap();


        }

    }

    private void StartAmrap()
    {
        // There IS Time To Count
        if (AmrapManager.instance.totalTime > 0)
        {
            SetAmrapForm();
            StartAmrapbool = true;
            canCountAgain = false;
        }
    }

    private void SetAmrapForm()
    {
        determiner++;
        if (determiner == 1)
        {
            if (countForRounds != 0)
                SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[2]);
            
            amrapTotalTime = countForRounds == 0 ? 10f : AmrapManager.instance._amrap[countForRounds].restTime;
            //if (amrapTotalTime == 0)
            //    if (rounder == 1)
            //        amrapTotalTime = 4;
            //    else
            //        amrapTotalTime = 1;
            timerrr = TimeSpan.FromSeconds(amrapTotalTime);
            AmrapFillSlider.maxValue = amrapTotalTime;
        }
        else if (determiner == 2)
        {
            SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[3]);
            amrapTotalTime = AmrapManager.instance._amrap[countForRounds].totalTime;
            if (amrapTotalTime == 0)
                amrapTotalTime = 1;
            timerrr = TimeSpan.FromSeconds(amrapTotalTime);
            AmrapFillSlider.maxValue = amrapTotalTime;


            countForRounds++;


            var timespan = TimeSpan.FromSeconds(AmrapManager.instance._amrap[countForRounds - 1].totalTime);
            AmrapTitle[1].text = timespan.ToString(@"mm\:ss") + " seconds";
        }
        else if (determiner == 3)
        {
            determiner = 0;
        }

        halfTime = amrapTotalTime / 2;

        AmrapTitle[0].text = "AMRAP " + countForRounds.ToString() + " of " + (rounder + 1);


    }

    //Setting Counter At Runtime
    private void SetAmrapCounter()
    {
        if (amrapTotalTime > 0)
        {
            amrapTotalTime -= Time.deltaTime;
            timerrr = TimeSpan.FromSeconds(amrapTotalTime);

            if (amrapTotalTime < 1)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[1]);
            else if (amrapTotalTime < 4)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[0]);
            else if (amrapTotalTime > halfTime && amrapTotalTime < halfTime + 0.9 && countForRounds != 0)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[4]);
            else if (amrapTotalTime > 10f && amrapTotalTime < 10.9f)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[5]);
        }
        else if (amrapTotalTime <= 0)
        {
            if (countForRounds == rounder + 1 && !canCountAgain)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[6]);

            canCountAgain = true;

        }
    }

    #endregion AMRAPFunctions

    #region ForTimeFunctions

    public void ShowForTime()
    {

        if (ForTimeManager.instance.totalTime <= 0)
            return;



        var panelColor = ForTimeProgress.GetComponent<CanvasGroup>();

        StartForTimebool = false;
        rounder = ForTimeManager.instance.sets - 1;
        countForRounds = 0;
        determiner = 0;
        canCountAgain = false;


        if (ForTimeProgress.activeInHierarchy)
        {

            ForTimeBackBtn[0].SetActive(true);
            ForTimeBackBtn[1].SetActive(false);

            ForTimeProgress.SetActive(false);

        }
        else
        {
            ForTimeBackBtn[0].SetActive(false);
            ForTimeBackBtn[1].SetActive(true);

            ForTimeProgress.SetActive(true);

            panelColor.alpha = 0;
            panelColor.LeanAlpha(1f, 0.3f);


            var timespan = TimeSpan.FromSeconds(AmrapManager.instance.totalTime);
            ForTimeTitle[1].text = timespan.ToString(@"mm\:ss") + " seconds";

            if (FinishBtns != null)
                FinishBtns.SetActive(true);

            StartForTime();


        }

    }

    private void StartForTime()
    {
        // There IS Time To Count
        if (ForTimeManager.instance.totalTime > 0)
        {
            SetForTimeForm();
            StartForTimebool = true;
            canCountAgain = false;
        }
    }

    private void SetForTimeForm()
    {
        determiner++;
        if (determiner == 1)
        {
            if (countForRounds != 0)
                SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[2]);

            ForTimeTotalTime = countForRounds == 0 ? 10f : ForTimeManager.instance.rest;
           
            //if (ForTimeTotalTime == 0 && countForRounds > 0)
            //{
            //    ForTimeTotalTime = 4;
            //}

            //if (countForRounds == 0)
            //    ForTimeTotalTime = 4;

            timerrr = TimeSpan.FromSeconds(ForTimeTotalTime);
            ForTimeFillSlider.maxValue = ForTimeTotalTime;
        }
        else if (determiner == 2)
        {
            SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[3]);
            ForTimeTotalTime = ForTimeManager.instance.totalTime;


            timerrr = TimeSpan.FromSeconds(ForTimeTotalTime);
            ForTimeFillSlider.maxValue = ForTimeTotalTime;


            countForRounds++;
        }
        else if (determiner == 3)
        {
            determiner = 0;
        }

        halfTime = ForTimeTotalTime / 2;

        ForTimeTitle[0].text = "For Time " + countForRounds.ToString() + " of " + (rounder + 1);


    }

    //Setting Counter At Runtime
    private void SetForTimeCounter()
    {
        if (ForTimeTotalTime > 0)
        {
            ForTimeTotalTime -= Time.deltaTime;
            timerrr = TimeSpan.FromSeconds(ForTimeTotalTime);

            if (ForTimeTotalTime < 1)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[1]);
            else if (ForTimeTotalTime < 4)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[0]);
            else if (ForTimeTotalTime > halfTime && ForTimeTotalTime < halfTime + 0.9 && countForRounds != 0)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[4]);
            else if (ForTimeTotalTime > 10f && ForTimeTotalTime < 10.9f)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[5]);
        }
        else if (ForTimeTotalTime <= 0)
        {

            canCountAgain = true;
        }
    }

    #endregion ForTimeFunctions

    #region EMOM
    public void ShowEMOM()
    {

        if (EMOMManager.instance.totalTime <= 0)
            return;



        var panelColor = EMOMProgress.GetComponent<CanvasGroup>();

        StartEMOMbool = false;
        rounder = EMOMManager.instance.sets - 1;
        countForRounds = 0;
        determiner = 0;
        canCountAgain = false;


        if (EMOMProgress.activeInHierarchy)
        {

            EMOMBackBtn[0].SetActive(true);
            EMOMBackBtn[1].SetActive(false);

            EMOMProgress.SetActive(false);

        }
        else
        {
            EMOMBackBtn[0].SetActive(false);
            EMOMBackBtn[1].SetActive(true);

            EMOMProgress.SetActive(true);

            panelColor.alpha = 0;
            panelColor.LeanAlpha(1f, 0.3f);


            var timespan = TimeSpan.FromSeconds(EMOMManager.instance.totalTime);
            EMOMTitle[1].text = timespan.ToString(@"mm\:ss") + " seconds";

            if (FinishBtns != null)
                FinishBtns.SetActive(true);

            StartEMOM();


        }

    }

    private void StartEMOM()
    {
        // There IS Time To Count
        if (EMOMManager.instance.totalTime > 0)
        {
            SetEMOMForm();
            StartEMOMbool = true;
            canCountAgain = false;
        }
    }

    private void SetEMOMForm()
    {
       
        
            EMOMTotalTime = EMOMManager.instance.totalTime;


            timerrr = TimeSpan.FromSeconds(EMOMTotalTime);
            EMOMFillSlider.maxValue = EMOMTotalTime;


            countForRounds++;

        if (EMOMManager.instance.sets < 999)
            EMOMTitle[0].text = "EMOM " + countForRounds.ToString() + " of " + (rounder + 1);
        else
            EMOMTitle[0].text = "EMOM " + countForRounds.ToString() + " of  ~";

        halfTime = EMOMTotalTime / 2;

    }

    //Setting Counter At Runtime
    private void SetEMOMCounter()
    {
        if (EMOMTotalTime > 0)
        {
            EMOMTotalTime -= Time.deltaTime;
            timerrr = TimeSpan.FromSeconds(EMOMTotalTime);

            if (EMOMTotalTime < 1)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[1]);
            else if (EMOMTotalTime < 4)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[0]);
            else if (EMOMTotalTime > halfTime && EMOMTotalTime < halfTime + 0.9)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[4]);
            else if (EMOMTotalTime > 10f && EMOMTotalTime < 10.9f)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[5]);
        }
        else if (EMOMTotalTime <= 0)
        {

            canCountAgain = true;
        }
    }

    #endregion EMOM

    #region TABATAFunctions

    public void ShowTABATA()
    {

        if (TABATAManager.instance.totalTime <= 0)
            return;



        var panelColor = TABATAProgress.GetComponent<CanvasGroup>();

        StartTABATAbool = false;
        rounder = TABATAManager.instance.sets - 1;
        countForRounds = 0;
        determiner = 0;
        canCountAgain = false;


        if (TABATAProgress.activeInHierarchy)
        {

            TABATABackBtn[0].SetActive(true);
            TABATABackBtn[1].SetActive(false);

            TABATAProgress.SetActive(false);

        }
        else
        {
            TABATABackBtn[0].SetActive(false);
            TABATABackBtn[1].SetActive(true);

            TABATAProgress.SetActive(true);

            panelColor.alpha = 0;
            panelColor.LeanAlpha(1f, 0.3f);


            var timespan = TimeSpan.FromSeconds(TABATAManager.instance.totalTime);
            TABATATitle[1].text = timespan.ToString(@"mm\:ss") + " seconds";

            if (FinishBtns != null)
                FinishBtns.SetActive(true);

            StartTABATA();


        }

    }

    private void StartTABATA()
    {
        // There IS Time To Count
        if (TABATAManager.instance.totalTime > 0)
        {
            Debug.Log("start");
            SetTABATAForm();
            StartTABATAbool = true;
            canCountAgain = false;
        }
    }

    private void SetTABATAForm()
    {
        Debug.Log("set form");
        determiner++;
        if (determiner == 1)
        {
            if (countForRounds != 0)
                SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[2]);
           
            TABATATotalTime = countForRounds == 0 ? 10f : TABATAManager.instance.rest;

            //if (TABATATotalTime == 0 && countForRounds > 0)
            //{
            //    TABATATotalTime = 4;
            //}

            //if (countForRounds == 0)
            //    TABATATotalTime = 4;

            timerrr = TimeSpan.FromSeconds(TABATATotalTime);
            TABATAFillSlider.maxValue = TABATATotalTime;
        }
        else if (determiner == 2)
        {
            SoundManager.instance.PlaySoundDeterminer(SoundManager.instance.audioClip[3]);
            TABATATotalTime = TABATAManager.instance.totalTime;


            timerrr = TimeSpan.FromSeconds(TABATATotalTime);
            TABATAFillSlider.maxValue = TABATATotalTime;


            countForRounds++;
        }
        else if (determiner == 3)
        {
            determiner = 0;
        }

        halfTime = TABATATotalTime / 2;

        TABATATitle[0].text = "TABATA " + countForRounds.ToString() + " of " + (rounder + 1);


    }

    //Setting Counter At Runtime
    private void SetTABATACounter()
    {
        if (TABATATotalTime > 0)
        {
            TABATATotalTime -= Time.deltaTime;
            timerrr = TimeSpan.FromSeconds(TABATATotalTime);

            if (TABATATotalTime < 1)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[1]);
            else if (TABATATotalTime < 4)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[0]);
            else if (TABATATotalTime > halfTime && TABATATotalTime < halfTime + 0.9 && countForRounds != 0)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[4]);
            else if (TABATATotalTime > 10f && TABATATotalTime < 10.9f)
                SoundManager.instance.PlaySound(SoundManager.instance.audioClip[5]);

        }
        else if (TABATATotalTime <= 0)
        {
            canCountAgain = true;
        }
    }

    #endregion TABATAFunctions
}
