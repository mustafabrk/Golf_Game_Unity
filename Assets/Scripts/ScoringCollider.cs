using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    public GameObject Confetti; // Olusturulan confetti prefabini top delige ulastiginda patlatabilmek icin bu class uzerinde cagiriyoruz.

    private void OnTriggerEnter(Collider other) // Eger deligin dibine yerlestirdigimiz gorunmez ScoringCollider isimli bolgeden gecerse yani kisaca top delige girerse bu blok calisir. 
    {
        Debug.Log("LEVEL COMPLETE!");

        SetConfettiBlowSettings(false); // Confetti'nin gorunurlugu aktif hale getiriliyor yani kisaca konfeti patlatiliyor.
        GameObject.FindObjectOfType<LevelManager>().LevelComplete(); // LevelManager sinifindaki LevelComplete metodu cagirilir.
        SetConfettiBlowSettings(true);  // Confetti'nin gorunurlugu eski haline getiriliyor.
    }

    void SetConfettiBlowSettings(bool a) // Confetti oyun basindan beri HolePrefab icinde duruyor. Ancak default olarak gorunmez durumda. Bunu degistirmek icin bu fonksiyon kullanilir.
    {
        Confetti.SetActive(a);
    }
}
