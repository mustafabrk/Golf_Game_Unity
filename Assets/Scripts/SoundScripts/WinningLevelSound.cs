using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningLevelSound : MonoBehaviour
{
    AudioSource aSource; // Ses dosyasini oynatabilmek icin gerekli olan cagirma islemi

    public GameObject IsLevelCompleting; // Level gecildiginde ses dosyasinin oynatilmasi icin LevelManager sinifindan LevelCompletingInfo degiskenini cagirilir.

    void Start()
    {
        aSource = GetComponent<AudioSource>(); // Cagirdigimiz degiskene gerekli bilesen ataniyor.
    }

    void Update()
    {
        if (IsLevelCompleting.GetComponent<LevelManager>().LevelCompletingInfo == false) // Eger level gecildiyse ses dosyasi oynatilir.
        {
            aSource.Play();
        }
    }
}
