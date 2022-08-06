using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bilesenini alıp rb nesnesine aktariyoruz. 
        rb.sleepThreshold = 0.05f; // Topun ne kadar sure yuvarlanacagini ayarlamaya calisiyoruz. Default deger 0.0005'tir.
    }

    Rigidbody rb; // Rigidbody sinifindan rb isimli nesne turetiyoruz.
}
