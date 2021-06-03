using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject ChooseParentPanel;
    [SerializeField]
    private GameObject ChooseLittleSlider;
    [SerializeField]
    private Text ChooseText;
    //ChooseYourWeight
    [SerializeField]
    private GameObject ChooseYourWeight;
    [SerializeField]
    private Slider WeightSlider;
    [SerializeField]
    private Text WeightText;

    [SerializeField]
    private Slider EditWeightSlider;
    [SerializeField]
    private Text EditWeightText;
    //ChooseYourWeight

    //ChooseYourWeight
    [SerializeField]
    private GameObject ChooseTall;
    [SerializeField]
    private Slider TallSlider;
    [SerializeField]
    private Text TallText;

    [SerializeField]
    private Slider EditTallSlider;
    [SerializeField]
    private Text EditTallText;
    //ChooseYourWeight

    //HomeFooter
    [SerializeField]
    private Image[] FooterImg;
    [SerializeField]
    private Sprite[] UnpressedImg;
    [SerializeField]
    private Sprite[] PressedImg;
    [SerializeField]
    private Text[] FooterText;
    //HomeFooter

    //SmallPanels
    [SerializeField]
    private GameObject ResetAllProgressPanel;
    [SerializeField]
    private GameObject ChangePasswordPanel;
    [SerializeField]
    private GameObject EditWeighPanel;
    [SerializeField]
    private GameObject EditTallPanel;
    [SerializeField]
    private GameObject EditAgePanel;
    //SmallPanels

    [SerializeField]
    private GameObject feedbackPanel;

    [SerializeField]
    private GameObject Panels;
    [SerializeField]
    private GameObject ChoosePanels;
    [SerializeField]
    private GameObject HomePanels;
    [SerializeField]
    private GameObject ProfilePanels;
    [SerializeField]
    private GameObject TimerPanels;
    [SerializeField]
    private GameObject SettingsPanels;

    [SerializeField]
    private GameObject LoginPanel;
    [SerializeField]
    private GameObject RegisterPanel;
    [SerializeField]
    private GameObject ResetPanel;
    [SerializeField]
    private GameObject Home;
    [SerializeField]
    private GameObject Profile;
    [SerializeField]
    private GameObject Timer;
    [SerializeField]
    private GameObject Settings;


    private void Update()
    {
        WeightText.text = WeightSlider.value + " Kg";
        TallText.text = TallSlider.value + " Cm";
        EditWeightText.text = EditWeightSlider.value + " Kg";
        EditTallText.text = EditTallSlider.value + " Cm";
    }

    public void OnBoard_1()
    {
        OnboardPanel.SetActive(true);
        //var boardColor = BoardParent.GetComponent<CanvasGroup>();
        BoardParent.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.15f).setEaseOutExpo();
        BoardLittleCircle.transform.localScale = new Vector2(0f, 0f);
        BoardLittleCircle.transform.LeanMoveLocal(new Vector2(0f, 0f), 0f);
        BoardLittleCircle.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        //boardColor.alpha = 0f;
        //boardColor.LeanAlpha(1f, 0.15f);
    }

    public void OnBoard_2()
    {
        //var boardColor = BoardParent.GetComponent<CanvasGroup>();
        BoardParent.transform.LeanMoveLocal(new Vector2(-1440f * 2, 0f), 0.15f).setEaseOutExpo();
        BoardLittleCircle.transform.localScale = new Vector2(0f, 0f);
        BoardLittleCircle.transform.LeanMoveLocal(new Vector2(100f, 0f), 0f);
        BoardLittleCircle.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
       // boardColor.alpha = 0f;
        //boardColor.LeanAlpha(1f, 0.15f);
    }

    public void OnBoard_3()
    {
        Panels.SetActive(true);
        var boardColor = BoardParent.GetComponent<CanvasGroup>();
        Invoke("DisableOnBoardPanel", 0.2f);
        boardColor.LeanAlpha(0f, 0.15f);
    
    }

    public void DisableOnBoardPanel()
    {
        OnboardPanel.SetActive(false);
        OnLoadingEnd();
    }

    public void ShowOnBoardPanel()
    {
        OnboardPanel.SetActive(true);
    }

    public void OnLoadingEnd()
    {
        var can = Login_SignUp_Btns.GetComponent<CanvasGroup>();
        can.alpha = 0f;
        can.LeanAlpha(1f, 0.2f);
        if (OnboardPanel.activeInHierarchy || Home.activeInHierarchy)
            ShowLoginsPanels(false);
    }

    public void ShowLoginsPanels(bool isOn)
    {
        Panels.SetActive(isOn);
    }

    public void ShowLogin()
    {
        if (!Panels.activeInHierarchy)
        {
            Panels.SetActive(false);
            HomePanels.SetActive(false);
        }


        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-2880f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }
    public void ShowRegister()
    {
        if (!Panels.activeInHierarchy)
        {
            Panels.SetActive(false);
            HomePanels.SetActive(false);
        }

        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void HideUnHidePass()
    {
       var hideScript = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<HideUnHidePas>();
        hideScript.HideOrUnHide();
    }

    public void ShowResetPasswordPassword()
    {
        if (!Panels.activeInHierarchy)
        {
            Panels.SetActive(false);
            HomePanels.SetActive(false);
        }

        var panelsColor = Panels.GetComponent<CanvasGroup>();
        Panels.transform.LeanMoveLocal(new Vector2(-4320f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void ShowChooseWeight()
    {
        Panels.SetActive(false);
        ChooseParentPanel.SetActive(true);
        var panelsColor = ChoosePanels.GetComponent<CanvasGroup>();
        ChoosePanels.transform.LeanMoveLocal(new Vector2(0, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
        ChooseLittleSlider.transform.localScale = new Vector2(0f, 0f);
        ChooseLittleSlider.transform.LeanMoveLocal(new Vector2(-540.0194f, 0f), 0f);
        ChooseLittleSlider.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        ChooseText.text = "1 of 4";
    }

    public void ShowChooseTall()
    {
        var panelsColor = ChoosePanels.GetComponent<CanvasGroup>();
        ChoosePanels.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
        ChooseLittleSlider.transform.localScale = new Vector2(0f, 0f);
        ChooseLittleSlider.transform.LeanMoveLocal(new Vector2(-180.0583f, 0f), 0f);
        ChooseLittleSlider.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        ChooseText.text = "2 of 4";
    }

    public void ShowChooseAge()
    {
        var panelsColor = ChoosePanels.GetComponent<CanvasGroup>();
        ChoosePanels.transform.LeanMoveLocal(new Vector2(-2880f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
        ChooseLittleSlider.transform.localScale = new Vector2(0f, 0f);
        ChooseLittleSlider.transform.LeanMoveLocal(new Vector2(179.9027f, 0f), 0f);
        ChooseLittleSlider.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        ChooseText.text = "3 of 4";
    }

    public void ShowGender()
    {
        var panelsColor = ChoosePanels.GetComponent<CanvasGroup>();
        ChoosePanels.transform.LeanMoveLocal(new Vector2(-4320f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
        ChooseLittleSlider.transform.localScale = new Vector2(0f, 0f);
        ChooseLittleSlider.transform.LeanMoveLocal(new Vector2(539.8637f, 0f), 0f);
        ChooseLittleSlider.transform.LeanScale(new Vector2(1f, 1f), 0.2f);
        ChooseText.text = "4 of 4";
    }

    public void ShowChooseYourPlan()
    {
        var panelsColor = ChoosePanels.GetComponent<CanvasGroup>();
        ChoosePanels.transform.LeanMoveLocal(new Vector2(-5760f, 0f), 0.1f);
        panelsColor.alpha = 0f;
        panelsColor.LeanAlpha(1f, 0.15f);
        ChooseLittleSlider.transform.parent.gameObject.SetActive(false);
        ChooseText.gameObject.SetActive(false);
    }

    public void ShowHome()
    {
        Panels.SetActive(false);
        ChooseParentPanel.SetActive(false);
        Home.SetActive(true);

       // var panelsColor = HomePanels.GetComponent<CanvasGroup>();
        HomePanels.transform.LeanMoveLocal(new Vector2(0f, 0f), 0.15f);
        //panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);


        //SetBtnColor
        for (int i = 0; i < FooterImg.Length; i++)
        {
            FooterImg[i].sprite = UnpressedImg[i];
            FooterText[i].color = new Color(159f / 255f, 159f / 255f, 164f / 255f);
        }
        //Color lerpColor = new Color(196f, 148f, 48f);
        FooterImg[0].sprite = PressedImg[0];
        FooterText[0].color = new Color(196f / 255f, 148f / 255f, 48f / 255f); ;
    }

    public void ShowProfile()
    {
        if (!Home.activeInHierarchy)
        {
            Home.SetActive(true);
            Profile.SetActive(false);
        }

       // var panelsColor = HomePanels.GetComponent<CanvasGroup>();
        HomePanels.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.15f);
       // panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);

        //SetBtnColor
        for (int i = 0; i < FooterImg.Length; i++)
        {
            FooterImg[i].sprite = UnpressedImg[i];
            FooterText[i].color = new Color(159f / 255f, 159f / 255f, 164f / 255f);
        }
       // Color lerpColor = new Color(196f, 148f, 48f);
        FooterImg[1].sprite = PressedImg[1];
        FooterText[1].color = new Color(196f / 255f, 148f / 255f, 48f / 255f); 
    }

    public void ShowTimer()
    {

        Timer.SetActive(false);
        Home.SetActive(true);
        


       // var panelsColor = HomePanels.GetComponent<CanvasGroup>();
        HomePanels.transform.LeanMoveLocal(new Vector2(-2880f, 0f), 0.15f);
     //   panelsColor.alpha = 0f;
      //  panelsColor.LeanAlpha(1f, 0.15f);


        //SetBtnColor
        for (int i = 0; i < FooterImg.Length; i++)
        {
            FooterImg[i].sprite = UnpressedImg[i];
            FooterText[i].color = new Color(159f / 255f, 159f / 255f, 164f / 255f);
        }
      //  Color lerpColor = new Color(196f, 148f, 48f);
        FooterImg[2].sprite = PressedImg[2];
        FooterText[2].color = new Color(196f / 255f, 148f / 255f, 48f / 255f); 
    }
    public void ShowSettings()
    {


        Settings.SetActive(false);
        Home.SetActive(true);
        


       // var panelsColor = HomePanels.GetComponent<CanvasGroup>();
        HomePanels.transform.LeanMoveLocal(new Vector2(-4320f, 0f), 0.15f);
      //  panelsColor.alpha = 0f;
      //  panelsColor.LeanAlpha(1f, 0.15f);

        //SetBtnColor
        for (int i = 0; i < FooterImg.Length; i++)
        {
            FooterImg[i].sprite = UnpressedImg[i];
            FooterText[i].color = new Color(159f / 255f, 159f / 255f, 164f / 255f);
        }
       // Color lerpColor = new Color(196f, 148f, 48f);
        FooterImg[3].sprite = PressedImg[3];
        FooterText[3].color = new Color(196f / 255f, 148f / 255f, 48f / 255f); 
    }

    public void ShowProfileInformation()
    {

        Profile.SetActive(true);
        Home.SetActive(false);
        

      //  var panelsColor = ProfilePanels.GetComponent<CanvasGroup>();
        ProfilePanels.transform.LeanMoveLocal(new Vector2(0f, 0f), 0.15f);
       // panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void ShowStatistics()
    {

        Profile.SetActive(true);
        Home.SetActive(false);
 

       // var panelsColor = ProfilePanels.GetComponent<CanvasGroup>();
        ProfilePanels.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.15f);
       // panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void ShowResetAllProgress(bool on)
    {

        var panelsColor = ResetAllProgressPanel.GetComponent<CanvasGroup>();
        if (on)
        {
            ResetAllProgressPanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            ResetAllProgressPanel.SetActive(false);
        }

    }

    public void ShowChangePassword(bool on)
    {

        var panelsColor = ChangePasswordPanel.GetComponent<CanvasGroup>();
        if (on)
        {
            ChangePasswordPanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            ChangePasswordPanel.SetActive(false);
        }

    }

    public void ShowEditWeigh(bool on)
    {

        var panelsColor = EditWeighPanel.GetComponent<CanvasGroup>();
        if (on)
        {
            EditWeighPanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            EditWeighPanel.SetActive(false);
        }

    }

    public void ShowEditTall(bool on)
    {

        var panelsColor = EditTallPanel.GetComponent<CanvasGroup>();
        if (on)
        {
            EditTallPanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            EditTallPanel.SetActive(false);
        }

    }


    public void ShowEditAge(bool on)
    {

        var panelsColor = EditAgePanel.GetComponent<CanvasGroup>();
        if (on)
        {
            EditAgePanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            EditAgePanel.SetActive(false);
        }

    }


    public void ShowCounter()
    {
        Timer.SetActive(true);
        Home.SetActive(false);
      

        //var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        TimerPanels.transform.LeanMoveLocal(new Vector2(0f, 0f), 0.15f);
        //panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowAMRAP()
    {
        Timer.SetActive(true);
        Home.SetActive(false);


        //var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        TimerPanels.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.15f);
      //  panelsColor.alpha = 0f;
       // panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowForTime()
    {
        Timer.SetActive(true);
        Home.SetActive(false);


       // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        TimerPanels.transform.LeanMoveLocal(new Vector2(-2880f, 0f), 0.15f);
       // panelsColor.alpha = 0f;
      //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowEMOM()
    {
        Timer.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        TimerPanels.transform.LeanMoveLocal(new Vector2(-4320f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowTABATA()
    {
        Timer.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        TimerPanels.transform.LeanMoveLocal(new Vector2(-5760f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowPremium()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(0f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowChangeYourPlane()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(-1440f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowFeedback(bool on)
    {

        var panelsColor = feedbackPanel.GetComponent<CanvasGroup>();
        if (on)
        {
            feedbackPanel.SetActive(true);
            panelsColor.alpha = 0f;
            panelsColor.LeanAlpha(1f, 0.4f);
        }
        else
        {
            panelsColor.alpha = 1f;
            panelsColor.LeanAlpha(0f, 0.4f);
            feedbackPanel.SetActive(false);
        }

    }

    public void ShowContactUs()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(-2880f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowAboutUs()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(-4320f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowFQA()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(-5760f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void ShowPrivacyPolicy()
    {
        Settings.SetActive(true);
        Home.SetActive(false);


        // var panelsColor = TimerPanels.GetComponent<CanvasGroup>();
        Settings.transform.LeanMoveLocal(new Vector2(-7200f, 0f), 0.15f);
        // panelsColor.alpha = 0f;
        //  panelsColor.LeanAlpha(1f, 0.15f);

    }

    public void DisableCanvas()
    {
        if (Canvas.activeInHierarchy)
            Canvas.SetActive(false);
        else
            Canvas.SetActive(true);
    }

    public void OnFundamental()
    {
        ShowHome();
    }

    public void OnIntermediate()
    {
        ShowHome();
    }

    public void OnAdvanced()
    {
        ShowHome();
    }

    public void OnPro()
    {
        ShowHome();
    }
}
