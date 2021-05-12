using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUnHidePas : MonoBehaviour
{

    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text text;

    public void HideOrUnHide()
    {
        text.gameObject.SetActive(false);
        if (inputField.contentType == InputField.ContentType.Password)
        {
            inputField.contentType = InputField.ContentType.Standard;
        }
        else
        {
            inputField.contentType = InputField.ContentType.Password;
        }
        text.gameObject.SetActive(true);
    }
        
}
