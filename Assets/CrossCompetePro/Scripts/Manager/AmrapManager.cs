using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmrapManager : Singleton<AmrapManager>
{

    [SerializeField]
    private Transform[] children;

    public List<AMRAPScript> _amrap = new List<AMRAPScript>();




    [SerializeField]
    private Text totalTimeText;

    [HideInInspector]
    public float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ScanChildren()
    {


        _amrap.Clear();
        Array.Clear(children,0,children.Length);
   

        children = gameObject.GetComponentsInChildren<Transform>();

        //Getting All Amrap Scripts
        foreach(var child in children)
        {
            if (child.GetComponent<AMRAPScript>())
            {
              _amrap.Add(child.GetComponent<AMRAPScript>());
            }
        }

        for (int i = 0; i < _amrap.Count; i++)
        {
            _amrap[i].SetTitle(i);
            _amrap[i].SetRemoveBtn(false);

            if (i == _amrap.Count - 1)
                _amrap[i].SetRemoveBtn(true);
        }


    }

    public void SetTotalTimeText()
    {
        totalTime = 0;

      //  totalTime = (int)amrapScript.totalTime + (int)amrapScript.restTime;

        foreach (var child in _amrap)
        {
            totalTime += (int)child.totalTime + (int)child.restTime;
        }

        TimeSpan timerrr = TimeSpan.FromSeconds(totalTime);

        totalTimeText.text = "Total Time: " + timerrr.ToString(@"mm\:ss") + " min";
    }


}
