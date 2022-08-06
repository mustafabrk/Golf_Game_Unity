using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeManager : MonoBehaviour
{
    // Start blogu ilk frame ile birlikte cagirilacaktir.
    void Start()
    {
        FindPlayerBall(); // Topun oyuna dahil edilip edilmedigini inceleyen, asagida olusturdugumuz fonksiyon cagirilir.
        StrokeCount = 0; // Baslangicta atis sayaci 0 olarak ayarlanir.
    }

    public GameObject StrokeAngleVisible; // Top hareket halindeyken yon okunun gozukmesini istemiyorum. Bunun icin bu objeyi olusturuyorum ve 3DArrow objesini unity ekranindan buraya atiyorum.

    public float StrokeAngle { get; protected set; } // Nisan alma okunu cagirmak icin olusturulur. Yalnizca deger okumak, icerigini yanlislikla degistirmemek icin de { get; protected set; } deyimi kullanilir.

    public float StrokeForce { get; protected set; } // Guc barini cagirmak icin olusturulur. Yalnizca deger okumak, icerigini yanlislikla degistirmemek icin de { get; protected set; } deyimi kullanilir.
    public float StrokeForcePerc { get { return StrokeForce / MaxStrokeForce; } } // Her saniye guc barinin yukselip alcalmasini uygulamak icin olusturulur. Yine icerigin degistirilmemesi acisindan salt okunur yapilmistir. 

    public int StrokeCount; // Oyun ekraninda topa kac kere vuruldugunu gorebilmek icin bu degisken olusturulur. Diger class'lardan erisebilmek acisindan public olarak tanimliyoruz.
                            // Ileride belki levellere yildiz sistemi getiririm. Ornegin 3 vurustan daha az vurusla level gecildiyse oyuncuya 3 yildiz verilsin gibi???

    float strokeForceFillSpeed = 5f; // strokeForceFillSpeed degiskeni olusturulup icine vurus gucu barinin hangi hýzla yükselip alcalacagi atanir.
    int fillDir = 1; // fillDir eger -1 degeri alirsa vurus gucu barinda alcalma olur. 1 degeri aldiginda ise bar dolmaya baslar. Oyun basinda bar bostur ve dolmasý icin buraya 1 degeri verilir.

    float MaxStrokeForce = 10f; // MaxStrokeForce degiskeni olusturulup icine maksimum vurus gucu sayisi atanmistir. 

    public enum StrokeModeEnum // Oyunun vurus sistemi dort asamadan olusmaktadir. Bu fonksiyondaki asamalarin gecilip gecilmedigi bilgisini if bloklari ile kontrol edip gerekli atamalarla gerceklestirecegiz. Oncelikle asamalarimizi burada tanimliyoruz.
    {
        AIMING, // Nisan alma asamasi (WASD ve ok tuslari ile). **1. ASAMA**
        FILLING, // Topa ne kadar hýzlý vurulacagini belirleyen guc barinin calisma asamasi (Space tusu ile). **2. ASAMA**
        DO_WHACK, // Topun vurulmaya hazir olup olmadigini kontrol eden asama. Eger bu asamada topun vurulmaya hazir olduguna karar verilirse (Yani ikinciye Space tusuna basilirsa) son asamaya gecilebilir. **3. ASAMA**
        BALL_IS_ROLLING // Topun hala donup donmedigini kontrol eden asama. Eger bu asamada topun donmedigine karar verilirse tekrardan birinci asamaya donulecektir. **4. ASAMA**
    };

    public StrokeModeEnum StrokeMode { get; protected set; } // Asamalari cagirmak icin olusturulur. Yalnizca deger okumak, icerigini yanlislikla degistirmemek icin de { get; protected set; } deyimi kullanilir.

    Rigidbody playerBallRB; // Rigidbody sinifindan playerBallRB isimli nesne olusturulur.

    private void FindPlayerBall() // Bu fonksiyonda topun oyuna dahil edilip edilmedigi ve Rigidbody'sinin tanimlanip tanimlanmadigi kontrol edilir.
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player"); // Player etiketine sahip obje bilgileri go isimli degiskene atanir.

        if (go == null) // Atama gerceklestirilebildi mi? Gerceklestirilemediyse...
        {
            Debug.LogError("Couldn't find the ball"); // Top bulunamadi.
        }

        playerBallRB = go.GetComponent<Rigidbody>(); // Top objesinde Rigidbody bileseni var mi diye inceler. Obje bu bilesene sahipse bileseni, sahip degilse null degerini dondurur.

        if(playerBallRB == null) // Top objesi Rigidbody bilesenine sahip mi? Sahip degilse...
        {
            Debug.LogError("Ball has no rigidbody!"); // Topun Rigidbody bileseni yani gercek fizik kurallarina benzer bir sekilde isleyen bir fizigi yok.
        }
    }

    // Update blogu her frame yenilenmesinin ardindan bir kez cagirilacaktir. -- use this for inputs 
    private void Update()
    {
        if (StrokeMode == StrokeModeEnum.AIMING) // Ilk asamada miyiz (AIMING)? Eger ilk asamadaysak...
        {
            SetStrokeAngleVisible(true); // Top hareket halinde degil demektir. Oyleyse yon oku gozukebilir.

            StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime; // Her frame'de nisan alma okunun ne hizla ve hangi eksende donecegi bilgisi aktarilir. Basili tutulursa daha hizli donmesi icin += atamasi yapilir.

            if (Input.GetButtonUp("Fire")) // Project Settings kisminda "Fire" butonu olarak space secilmistir. Eger ilk asamada space tusu birakilirsa...
            {
                StrokeMode = StrokeModeEnum.FILLING; // Ilk asama tamamlanmis demektir. O halde ikinci asama degiskenini StrokeMode degiskenine atariz.
                return;
            }
        }

        if(StrokeMode == StrokeModeEnum.FILLING) // Ikinci asamada miyiz (FILLING)? Eger ikinci asamadaysak...
        {
            StrokeForce += (strokeForceFillSpeed * fillDir) * Time.deltaTime; // Her frame'de guc barinin yukselip alcalmasi bu islemde gerceklestirilir. 
            if(StrokeForce > MaxStrokeForce) // Eger guc bari maksimum esigi gectiyse...
            {
                StrokeForce = MaxStrokeForce; // Degeri yukarida belirtilen maksimum bar degerine esitler.
                fillDir = -1; // Guc barinin alcalmasi icin 1 olan degeri -1'e cevirir.
            }
            else if(StrokeForce < 0) // Eger guc bari minimum esigin altinda kaldiysa...
            {
                StrokeForce = 0; // Degeri minimum deger olan 0'a esitler.
                fillDir = 1; // Guc barinin yukselmesi icin -1 olan degeri 1'e cevirir.
            }

            if (Input.GetButtonUp("Fire")) // Eger ikinci asamada space tusu birakilirsa...
            {
                StrokeMode = StrokeModeEnum.DO_WHACK; // Ikinci asama tamamlanmis demektir. O halde ucuncu asama degiskenini StrokeMode degiskenine atariz.
            }
        }
        StrokeAngle += Input.GetAxis("Horizontal") * 100f * Time.deltaTime; // Top hareket halindeyken de nisan almayi saglar ancak vurus yapmaya izin vermez. 
    }

    void CheckRollingStatus() // Bu fonksiyonda top hareket halindeyken tekrar topa vurmak engellenmistir.
    {
        if (playerBallRB.IsSleeping()) // Top hala donuyor mu? Cevap hayir ise...
        {
            StrokeMode = StrokeModeEnum.AIMING; // Ilk asamaya (AIMING) donulur ve tekrar vurus yapilabilir.            
        }
    }
    void SetStrokeAngleVisible(bool a) // Yon okunun gorunup gorunmeyecegini ayarlayabildigimiz fonksiyon olusturuluyor.
    {
        StrokeAngleVisible.SetActive(a);
    }

    // FixedUpdate blogu fizik motorunun her tekrarlanisinda kullanilir. Topu harekete gecirme gibi islemler icin burasi kullanilir.
    void FixedUpdate()
    {
        if(playerBallRB == null) // Rigidbody'nin null olup olmadigi kontrol edilir. Eger null ise...
        {                        
            return;
        }

        if(StrokeMode == StrokeModeEnum.BALL_IS_ROLLING) // Topun hala donup donmedigi kontrol edilir.
        {
            CheckRollingStatus(); // Yukarida olusturdugumuz ve bu kontrolu yapacak olan metod cagirilir.
            return; 
        }

        if(StrokeMode != StrokeModeEnum.DO_WHACK) // Topun vurulmaya hazir olup olmadigi kontrol edilir. Eger vurma asamasina gecilmediyse hicbir sey yapilmaz yani bu bloga girilir.
        {
            return;
        }
        else // Eger vurulma asamasindaysak cikti olarak "Whacking it!" yazdirilir.
        {
            Debug.Log("Whacking it!");

            SetStrokeAngleVisible(false); // Vurulma asamasinda oldugumuzdan yon okunu gorunmez hale getiriyoruz.
            Vector3 forceVec = new Vector3(0, 0, StrokeForce); // Vector3 sinifindan forceVec isimli bir nesne olusturuluyor. Bu nesneye de vurus bari ne kadar doluysa o kadar ileri gitmesi icin gerekli degerler giriliyor.
            playerBallRB.AddForce(Quaternion.Euler(0, StrokeAngle, 0) * forceVec, ForceMode.Impulse); // Topa, yon okunun ve guc barinin kuvvet durtusu uygulanmistir. Euler, 3 boyutlu uzayda rotasyonu tanýmlamak icin kullanýlan uc aciya verilen addir.
                                                                                                      // Topa uygulanacak kuvvetin turu ForceMode.Impulse(Itme gucu) olarak ayarlanir. 

            StrokeForce = 0; // Vurus tamamlandigindan guc bari sifira getirilir yani bar bosaltilir.
            fillDir = 1; // Bar bos oldugundan bir dahaki tiklayista dolmasi icin fillDir degeri 1'e esitlenir. Hatirlarsaniz fillDir'in 1 olmasi barin yukari yone dogru dolacagi anlamina gelmekteydi.
            StrokeCount++; // Eger bu satira kadar herhangi bir sorun yasanmadiysa vurus islemi gerceklesmis, ok yaydan cikmis demektir. O zaman vurus sayacimizi bir arttiralim.
            StrokeMode = StrokeModeEnum.BALL_IS_ROLLING; // Son olarak topun donup donmedigini kontrol eden 4. asamaya gidilir. Eger top duruyorsa 1. asamaya donulup butun bu islemler tekrardan yapilabilir hale gelecektir.
        }
    }
}
