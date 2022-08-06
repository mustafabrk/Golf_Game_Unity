using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour // Surekli ayni levelden baslamamak icin bu class asagidakine benzer komutlarla gelistirilebilir. 
{
    public GameObject LevelIndex;  // En son hangi levelin indeksinde kalindiysa o indeks bilgisine ulasmak icin olusturulur.
    int level; // Index bilgisinin orijinalligi bozulmamasi icin bu degisken olusturulur.

    public void LevelInfo()
    {
        level = LevelIndex.GetComponent<LevelManager>().levelIndex; // Gerekli atamalar yapilir.

        PlayerPrefs.SetInt("currLevel", level); // Son kalinan indeks bilgisi kaydedilir. BURAYI OYUN ICINDEKI MAIN MENU BUTONUNA AKTARABILIRSIN

        PlayerPrefs.GetInt("currLevel"); // En son kaydedilen indeks bilgileri buradan yuklenir. BURAYI DA OYUN MENUSUNDEKI PLAY GAME BUTONUNA AKTARABÝLÝRSÝN
    }
}
