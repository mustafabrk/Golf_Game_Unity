using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    AudioSource aSource; // Ses dosyasini oynatabilmek icin gerekli olan cagirma islemi

    public GameObject StrokeCount; // Topa her vuruldugunda ses cikmasi icin StrokeManager sinifindan StrokeCount degiskenini cagirilir. Vurus sayaci her arttiginda ses calacaktir.

    int startValue = 0; // StrokeCount degeriyle kiyaslama yapabilmek icin startValue degiskeni olusturup baslangic degerini 0 veriyoruz. StrokeCount ile eszamanli artmasini istiyoruz.

    void Start()
    {
        aSource = GetComponent<AudioSource>(); // Cagirdigimiz degiskene gerekli bilesen ataniyor.
    }

    void Update()
    {
        if (StrokeCount.GetComponent<StrokeManager>().StrokeCount == 0) // Eger StrokeManager sinifindaki StrokeCount sayaci 0 ise startValue de 0 olsun. Bunu yapmazsak level atlandiginda StrokeCount sifirlanir ancak startValue sifirlanmaz. Bu yuzden de ses dosyasi cagirilamaz.
        {
            startValue = 0;
        }
        if (startValue + 1 == StrokeCount.GetComponent<StrokeManager>().StrokeCount) // Eger StrokeCount ve startValue degeri ayni ise ses dosyasi oynatilir.
        {
            aSource.Play();
            startValue++;
        }
    }
}
