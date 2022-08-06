using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start blogu ilk frame ile birlikte cagirilacaktir.
    void Start()
    {
        SpawnLevel(); // Olusturdugumuz SpawnLevel metodunu cagirir.
    }

    public int LevelCount = 0; // Ekrana hangi levelde oldugumuzu yazmak icin bu degisken olusturuluyor.

    public GameObject StrokeCount; // Level atlandiginda vurus sayacinin sifirlanmasi icin StrokeCount objesi ekleniyor.

    public bool LevelCompletingInfo = false; // Level gecildiginde konfeti patlamasi ve ses dosyasinin oynatilmasi icin bu kontrol degiskeni olusturulup diger siniflar tarafindan kontrol ediliyor.

    public GameObject[] Levels; // Level bilgisini ilgili indisten almak icin gerekli olan dizi objesi olusturulur.
    public int levelIndex; // Olusturulan Levels degiskeninin hangi leveli alacagi bilgisi bu degiskende tutulacaktir.
    GameObject currLevel; // Mevcut level bilgisini kontrol etmek icin currLevel isimli obje uretilir.

    void DespawnLevel() // Level gecildiginde yeni level ile mevcut level ust uste binmesin diye bu metot olusturulur.
    {
        Destroy(currLevel); // Mevcut leveli siler.

        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 0.5f, 0); // Level sahneden kaldirilirken topun konumu sifirlanir.

        StrokeCount.GetComponent<StrokeManager>().StrokeCount = 0; // Yeni levele gecilecegi icin vurus sayaci sifirlanir.
    }

    void SpawnLevel() // Siradaki leveli cagirmak için bu metod olusturulur.
    {
        LevelCount++;

        LevelCompletingInfo = false; 
        currLevel = GameObject.Instantiate(Levels[levelIndex]); // Siradaki level bilgileri currLevel degiskenine atanir.
    }

    public void LevelComplete() // Level gecildiginde yani top delige ulastiginda bu metod calisir.
    {
        LevelCompletingInfo = true;
        Invoke("DespawnLevel", 4.9f); // Eski leveli sahneden silen metod cagirilir.
        levelIndex++; // Level indeksinin degeri arttirilir.
        Invoke("SpawnLevel", 5f); // Siradaki leveli sahneye ekleyen metod cagirilir.
    }
}
