using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCountUI : MonoBehaviour // Ekranda hangi levelde oldugumuzu gostermesi icin bu sinifi olusturuyoruz.
{
    void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>(); // LevelManager bilesenini alýp LevelManager nesnesine aktariyoruz. 
    }

    LevelManager LevelManager; // LevelManager sinifindan LevelManager isimli nesne turetiyoruz.

    void Update()
    {
        GetComponent<Text>().text = "Level: " + LevelManager.LevelCount;  // Level sayisini LevelManager sinifindaki LevelCount degiskeninden cekiyoruz.
    }
}
