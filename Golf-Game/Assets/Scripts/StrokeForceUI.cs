using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeForceUI : MonoBehaviour
{
    // Start blogu ilk frame ile birlikte cagirilacaktir.
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>(); // StrokeManager objesi bulunup StrokeManager isimli degiskene atanir.
        image = GetComponent<Image>();   // Image objesi bulunup image isimli degiskene atanir.
    }

    StrokeManager StrokeManager; // StrokeManager sinifindan StrokeManager isimli nesne turetiliyor.
    Image image; // Image sinifindan image isimli nesne turetiliyor.

    // Update blogu her frame yenilenmesinin ardindan bir kez cagirilacaktir.
    void Update()
    {
        image.fillAmount = StrokeManager.StrokeForcePerc; // Guc barinda arkaplan siyah, uzerine de beyaz olacak sekilde bir renklendirme kullanilmistir. Beyaz renk surekli olarak uzayip kisalacak 
                                                          // sekilde StrokeManager sinifinda kodlanmistir. StrokeManager sinifindaki koda gore bahsi gecen bar bu satirda maskelenir(Harekete gecirilir).
    }
}
