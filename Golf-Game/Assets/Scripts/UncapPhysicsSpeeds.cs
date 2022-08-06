using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncapPhysicsSpeeds : MonoBehaviour
{
    // Start blogu ilk frame ile birlikte cagirilacaktir.
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); // Rigidbody sinifindan olusturulan rb nesnesine gerekli atama yapilir.

        if(rb == null) // Eger Rigidbody bulunamadiysa...
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
            return;
        } // Ancak Rigidbody bulunduysa...

        rb.maxAngularVelocity = Mathf.Infinity; // Objenin saniyede kac tur doneceginin degeri default olarak 7'dir. Bunun daha gercekci gozukmesi icin bu siniri ortadan kaldiriyoruz.

        Destroy(this); // Class'da update blogu olmadigindan bu class'in varliginin olasi bir ek islem yuku ortadan kaldilir.
    }
}

