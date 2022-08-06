using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeAngleIndicator : MonoBehaviour
{
    // Start blogu ilk frame ile birlikte cagirilacaktir.
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>(); // StrokeManager objesi bulunup StrokeManager isimli degiskene atanir.
        playerBallTransform = GameObject.FindGameObjectWithTag("Player").transform; // Player etiketine sahip nesnenin konum bilgileri playerBallTransform isimli degiskene atanir.
    }

    StrokeManager StrokeManager; // StrokeManager sinifindan StrokeManager isimli nesne turetiyoruz.
    Transform playerBallTransform; // Transform sinifindan playerBallTransform isimli nesne turetiyoruz.

    // Update blogu her frame yenilenmesinin ardindan bir kez cagirilacaktir.
    void Update()
    {
        this.transform.position = playerBallTransform.position; // Bu siniftaki nesnenin (nisan alma cubugu veya oku blabla) konum bilgisi topun konum bilgisine esitlenir. Onu kendine merkez edinir.
        this.transform.rotation = Quaternion.Euler(0, StrokeManager.StrokeAngle, 0); // Nisan alma cubugunun yalnizca tek bir eksende hareket edebilmesi icin diger eksen degerleri 0 olarak girilir.
    }
}
