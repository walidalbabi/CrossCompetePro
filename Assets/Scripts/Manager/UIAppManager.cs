using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppManager : Singleton<UIAppManager>
{
    [SerializeField]
    private GameObject Canvas;

    //Board Panel
    [SerializeField]
    private GameObject OnboardPanel;
    [SerializeField]
    private GameObject BoardParent;
    [SerializeField]
    private GameObject BoardLittleCircle;
    //Board Panel

    //SignIn/SignUp Panel
    [SerializeField]
    private GameObject Login_SignUp;
    [SerializeField]
    private GameObject Login_SignUp_Btns;
    //SignIn/SignUp Panel

    [SerializeField]
    private GameObject Panels;

    [SerializeField]
    private GameObject LoginPanel;
    [SerializeField]
    private GameObject RegisterPanel;
    [SerializeField]
    private GameObject ResetPanel;
    [SerializeField]
    private GameObject Home;


    public void OnBoard_1()
    {
        Panels.SetActive(false);
        var boardColor = BoardParent.GetComponent<CanvasGroup>();
        BoardParent.transform.LeanMoveLocal(new Vector2(-1920f, 0f), 0.15f).setEaseOutExpo();
        BoardLittleCircle.transform.localScale = new Vector2(0f, 0f);
        BoardLittleCircle.transform.LeanMoveLocal(new Vector2(0f, -564.7999f), 0f);
        BoardLittleCircle.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        boardColor.alpha = 0f;
        boardColor.LeanAlpha(1f, 0.15f);
    }

    public void OnBoard_2()
    {
        var boardColor = BoardParent.GetComponent<CanvasGroup>();
        BoardParent.transform.LeanMoveLocal(new Vector2(-1920f*2, 0f), 0.15f).setEaseOutExpo();
        BoardLittleCircle.transform.localScale = new Vector2(0f, 0f);
        BoardLittleCircle.transform.LeanMoveLocal(new Vector2(100f, -564.7999f), 0f);
        BoardLittleCircle.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        boardColor.alpha = 0f;
        boardColor.LeanAlpha(1f, 0.15f);
    }

    public void OnBoard_3()
    {
        Panels.SetActive(true);
        var boardColor = BoardParent.GetComponent<CanvasGroup>();
        Invoke("DisableOnBoardPanel", 0.2f);
        boardColor.LeanAlpha(0f, 0.2f);
        Login_SignUp.SetActive(true);
    }
    public void DisableOnBoardPanel()
    {
        OnboardPanel.SetActive(false);
    }

    public void OnLoadingEnd()
    {
        var can = Login_SignUp_Btns.GetComponent<CanvasGroup>();
        can.alpha = 0f;
        can.LeanAlpha(1f, 0.2f);
    }

    public void ShowLogin()
    {
        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-3840f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }
    public void ShowRegister()
    {
        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-1920f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void ShowResetPasswordPassword()
    {
        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-5760f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void ShowHome()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        Home.SetActive(true);
    }

    public void DisableCanvas()
    {
        if (Canvas.activeInHierarchy)
            Canvas.SetActive(false);
        else
            Canvas.SetActive(true);
    }
}
