using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;


public class PlayFabLogin : Singleton<PlayFabLogin>
{

    [SerializeField]
    private string userName;

    [SerializeField]
    private string userEmail;

    [SerializeField]
    private string userPassword;

    [SerializeField]
    private string userConfirmPassword;

    [SerializeField]
    private GameObject ResetPassBtn;

    [SerializeField]
    private Text RegisterFailedText;
    [SerializeField]
    private Text LoginFailedText;
    [SerializeField]
    private Text RecoveryText;

    [SerializeField]
    private Button LoginBtn, RegisterBtn;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            UIAppManager.instance.ShowOnBoardPanel();
        }
    }

    private void Update()
    {


        if(userName == "" || userEmail == "" || userPassword == "" || userConfirmPassword == "")
        {
            RegisterBtn.interactable = false;
        }
        else
        {
            if (userPassword != userConfirmPassword)
            {
                RegisterBtn.interactable = false;
            }
            else
            {
                RegisterBtn.interactable = true;
            }
        }

        if (userEmail == "" || userPassword == "")
        {
            LoginBtn.interactable = false;
        }
        else
        {
            LoginBtn.interactable = true;
        }
    }
    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "801AC"; // Please change this value to your own titleId from PlayFab Game Manager
        }

        if (PlayerPrefs.HasKey("EMAIL") && PlayerPrefs.HasKey("PASSWORD"))
        {
            LoadingManager.instance.StartLoading();
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
            
        }

        PlayerPrefs.SetInt("FirstTime", 1);

    }


    #region CallBacks
    private void OnLoginSuccess(LoginResult result)
    {

        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);

        UIAppManager.instance.ShowHome();
        LoadingManager.instance.StopLoading();
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {

        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userConfirmPassword);
        UpdateContactEmail();

        UIAppManager.instance.ShowChooseWeight();
        LoadingManager.instance.StopLoading();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        LoadingManager.instance.StopLoading();
        Debug.LogError(error.GenerateErrorReport());
        LoginFailedText.text = "Email address: is not valid Password: is not valid";
        ResetPassBtn.SetActive(true);
        UIAppManager.instance.ShowLoginsPanels(true);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        LoadingManager.instance.StopLoading();
        Debug.LogError(error.GenerateErrorReport());
        RegisterFailedText.text = "Email address/username Already Exist!";
        UIAppManager.instance.ShowLoginsPanels(true);
    }

    private void FailUpdateCallBack(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnRecoveryEmailSuccess(SendAccountRecoveryEmailResult result)
    {
        RecoveryText.text = "Recovery Email Sended!!";
    }

    private void OnRecoveryEmailFailed(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        RecoveryText.text = "Invalid email Address";
    }
    #endregion CallBacks

    #region Authentication
    public void GetUserEmail(string emaiIn)
    {
        InputField input = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.
            gameObject.GetComponent<InputField>();
        emaiIn = input.text;
        userEmail = emaiIn;
    }

    public void GetUserPassword(string passwordIn)
    {
        InputField input = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.
       gameObject.GetComponent<InputField>();
        passwordIn = input.text;
        userPassword = passwordIn;
    }

    public void GetUserConfirmPassword(string passwordIn)
    {
        InputField input = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.
       gameObject.GetComponent<InputField>();
        passwordIn = input.text;
        userConfirmPassword = passwordIn;
        if (userConfirmPassword != userPassword)
            RegisterFailedText.text = "Password & Confirm Password Didn't Match";
        else
            RegisterFailedText.text = "";

    }

    public void GetUserName(string userNameIn)
    {
        InputField input = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.
       gameObject.GetComponent<InputField>();
        userNameIn = input.text;
        userName = userNameIn;
    }

    private void UpdateContactEmail()
    {
        var requestAddInfo = new AddOrUpdateContactEmailRequest { EmailAddress = userEmail };
        PlayFabClientAPI.AddOrUpdateContactEmail(requestAddInfo, result => {

            Debug.Log("Contact Email Updated");
        }, FailUpdateCallBack);
    }

    public void OnClickLogin()
    {
        LoadingManager.instance.StartLoading();
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    public void OnClickRegister()
    {
        LoadingManager.instance.StartLoading();
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userConfirmPassword, Username = userName };
        
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);

       
    }

    public void SendCustomAccountRecoveryEmail()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = userEmail,
            TitleId = PlayFabSettings.TitleId,
            EmailTemplateId = "9FAD9924AD36B9FC"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoveryEmailSuccess, OnRecoveryEmailFailed);
    }


    #endregion Authentication

}