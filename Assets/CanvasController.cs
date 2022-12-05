using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] RectTransform[] StartText;
    [SerializeField] float duration=1;
    [SerializeField] GameObject Player;
    [SerializeField] Image FadeImg;

    int startcounter = 0;
    void Start()
    {
        FadeImg.DOFade(0, 1);
        InvokeRepeating("StartCount", 0, duration);
    }

    public void resGame() 
    {
        SceneManager.LoadScene(0);
    }


    void StartCount() 
    {

        if (startcounter > 0)
            StartText[startcounter-1].gameObject.SetActive(false);


        StartText[startcounter].gameObject.SetActive(true);
        

        StartText[startcounter].DOScale(Vector3.zero, duration).From();
        startcounter++;
        if (startcounter > 3) 
        {
            Player.GetComponent<PlayerController>().enabled = true;
            Invoke("closeGo", duration);
            CancelInvoke("StartCount");
        }

    }
    void closeGo() 
    {
        StartText[3].gameObject.SetActive(false);
    }

}
