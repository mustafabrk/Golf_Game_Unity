using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeCountUI : MonoBehaviour
{
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>(); // StrokeManager objesi bulunup StrokeManager isimli degiskene atanir.
    }

    StrokeManager StrokeManager; // StrokeManager sinifindan StrokeManager isimli nesne turetilir.

    void Update()
    {
        GetComponent<Text>().text = "Stroke: " + StrokeManager.StrokeCount; // StrokeManager objesine gomulen kod icerigine gore (Top hareket haline gectiginde sayac 1 artar) atis sayisini ekrana yazdirir.
    }
}
