using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //public GameObject LevelIndex;
    //int level; // Ileride basit bir level sistemi gelistirmesi istersen yoruma aldigim satirlardaki kodlari kullanabilirsin.

    public void PlayGame() // Eger Play Game butonuna basilirsa...
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Proje ayarlarinda belirli bir hiyerarsiye oturtulmus sahneler vardir.
                                                                              // Main Menu sahnesini bu hiyerarsinin zirvesinde yer alir ve indeks degeri 0'dir.
                                                                              // Eger Play Game butonuna tiklanirsa bu indeks degeri bir arttirilip hiyerarside bir altta bulunan oyun ici sahnesi getirilir.
        //PlayerPrefs.GetInt("currLevel"); // Kullanici play game butonuna bastiginda oyun kalinan levelden baslatilsin.
    }

    public void ContinueGame() 
    {
        // Belki ileride buraya tipki Load Game gibi önceden tamamlanmis farklý levellere erismeyi ekleyebilirim?? Ya da kalinan bolumden devam edilmesini saglayabilirim.
    }

    public void QuitGame() // Eger Quit butonuna basilirsa...
    {
        Debug.Log("Exited the game."); // Oyundan cikildigi unity uzerinden farkedilmiyor. Bu islemin gerceklesip gerceklesmedigini kontrol etmek icin bir debug olusturalim.
        Application.Quit(); // Acik olan
    }

    public void ReturnToMainMenu() // Eger oyun icindeki Main Menu butonuna basilirsa...
    {
        //PlayerPrefs.SetInt("currLevel", level); // Kullanici oyun icinde main menu tusuna bastiginda kalinan level kaydedilsin.

        SceneManager.LoadScene(0); // Hiyerarsinin en tepesindeki sahne yani Main Menu sahnesi cagirilir.
    }
}
