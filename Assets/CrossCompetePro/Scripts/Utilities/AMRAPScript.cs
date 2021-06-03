using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AMRAPScript : MonoBehaviour
{

    [SerializeField]
    private InputField MinutesInput;
    [SerializeField]
    private InputField SecondsInput;
    [SerializeField]
    private InputField RestInput;

    private RectTransform tr;


    [SerializeField]
    private Text[] txt; 

    [SerializeField]
    private GameObject ExitBtn;

    private int  minutes, seconds;

    public float restTime, totalTime;

    private ContentScript contentScript;


    TimeSpan timerrr;

    // Start is called before the first frame update
    void Start()
    {
        contentScript = AddRoundsInTimer.instance.contentScript;
        tr = GetComponent<RectTransform>();
        tr.localScale = new Vector3(1f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

        if(RestInput != null)
        {
            if (RestInput.text != "")
            {
                restTime = int.Parse(RestInput.text);
            }
            else
            {
                restTime = 0;
            }
        }
       

        totalTime = seconds + (minutes * 60f);

        if (txt.Length > 0)
        {
            timerrr = TimeSpan.FromSeconds(totalTime);
            txt[1].text = "(" + timerrr.ToString(@"mm\:ss") + " min)";
        }


        AmrapManager.instance.SetTotalTimeText();
    }

    public void Remove()
    {

        transform.LeanMoveLocalY(transform.position.y + 300f, 0.3f);

        Invoke("AfterRemove", 0.3f);
      
    }

    private void AfterRemove()
    {
        transform.parent = null;

        AmrapManager.instance.ScanChildren();
        contentScript.OnExerciseLoad();

        Destroy(gameObject);
    }

    public void SetRemoveBtn(bool on)
    {
        ExitBtn.SetActive(on);
    }

    public void SetTitle(int round)
    {
        txt[0].text = round + 1 + " AMRAP ";
    }
}
