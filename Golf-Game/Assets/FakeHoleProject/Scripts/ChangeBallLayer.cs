using UnityEngine;
using System.Collections;

public class ChangeBallLayer : MonoBehaviour {

    public int LayerOnEnter; // Eger top delikteyse
    public int LayerOnExit;  // Eger top disaridaysa
	
    void OnTriggerEnter(Collider other) // Eger top ilgili alanin diger tarafina gectiyse(Delige girdiyse) bu metod kullanilacaktir.
    {
        if(other.gameObject.tag == "Player") // Player etiketli objenin varligi diger alanda kontrol edilir. Eger varsa...
        {
            other.gameObject.layer = LayerOnEnter; // LayerOnEnter degeri bu objeye atanir.
        }
    }

    void OnTriggerExit(Collider other) // Eger top ilgili alanin diger tarafindaysa(Disarida dolaniyorsa) bu metod kullanilacaktir.
    {
        if (other.gameObject.tag == "Player") // Player etiketli objenin varligi diger alanda kontrol edilir. Eger varsa...
        {
            other.gameObject.layer = LayerOnExit; // LayerOnEnter degeri bu objeye atanir.
        }
    }
}