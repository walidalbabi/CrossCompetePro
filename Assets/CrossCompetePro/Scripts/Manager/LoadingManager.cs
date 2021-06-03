using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{

    public static LoadingManager instance;

    [SerializeField]
    private GameObject LoadingPanel;

    [SerializeField]
    private Transform Logo;

    private CanvasGroup panelsColor;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {

        panelsColor = LoadingPanel.GetComponent<CanvasGroup>();
        Logo.LeanMoveLocal(new Vector2(0f, 25f), 0.8f).setEaseOutQuart().setLoopPingPong();
        StartLoading();
       // StopLoading();
    }


    public void StartLoading()
    {
        LoadingPanel.SetActive(true);
        panelsColor.LeanAlpha(1f, 0.15f);
    }

    public void StopLoading()
    {
        StartCoroutine(StopLoad());
    }

    IEnumerator StopLoad()
    {
        yield return new WaitForSeconds(5f);
        Logo.LeanScale(new Vector2(7.966805f, 7.966805f), 0.2f);
        Logo.LeanMoveLocal(new Vector2(-0.009765625f, 448.0002f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        panelsColor.LeanAlpha(0f, 0.15f);
        yield return new WaitForSeconds(0.2f);
        LoadingPanel.SetActive(false);
        UIAppManager.instance.OnLoadingEnd();
    }
}
