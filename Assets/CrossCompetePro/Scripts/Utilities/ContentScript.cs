using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScript : MonoBehaviour
{


    private RectTransform tr;

    Transform[] children;
    [SerializeField]
    private bool HorizontalScale;
    [SerializeField]
    private float HeigthOrWidth;
    [SerializeField]
    private float ScaleValue;
    [SerializeField]
    private float UnwantedChildren;

    // Start is called before the first frame update

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
    }
    void Start()
    {
        //233.329  575f
        OnExerciseLoad();
        Debug.Log(children.Length);
    }

    public void OnExerciseLoad()
    {


        children = gameObject.GetComponentsInChildren<Transform>();
        if (!HorizontalScale)
            tr.sizeDelta = new Vector2(HeigthOrWidth, (ScaleValue * children.Length / UnwantedChildren));
        else if (HorizontalScale)
            tr.sizeDelta = new Vector2((ScaleValue * children.Length / UnwantedChildren), HeigthOrWidth);
    }

}
