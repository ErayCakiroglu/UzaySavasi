using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject kursunPrefab;
    
    [SerializeField]
    GameObject patlamaPrefab;
    const float hareketGucu = 8;

    OyunKontrol oyunKontrol;
    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;//Uzay gemisinin pozisyonunu kayıt ediyoruz.
        float yatayInput = Input.GetAxis("Horizontal");//Klavyeden gelecek olan yatay bileşen değerlerini yatayInput değişkenine atıyoruz. Unity'de sola gitmek için(kordinat sisteminde -x yönü) default olarak a ya da sol ok tuşu, sağa gitmek için(kordinat sisteminde +x yönü) d ya da sağ ok tuşu bulunur.
        float dikeyInput = Input.GetAxis("Vertical");//Klavyeden gelecek olan dikey bileşen değerlerini dikeyInput değişkenine atıyoruz. Unity'de yukarı gitmek için(kordinat sisteminde +y) default olarak w ya da yukarı ok tuşu, aşağı gitmek için(kordinat sistemin -y) s ya da aşağı ok tuşu bulunur.

        if(yatayInput != 0)//Klavyeden sağa ya da sola gitmek için veri gelip gelmediğini sorgusunu yapıyoruz.
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime;//Eğer sağa ya da sola(-x ya da +x yönünde) gitmek için veri geliyorsa gelen veriyi(yatayInput) uzay gemisinin bizim tanımlamış olduğumuz hareket gücüyle ve herbir çevrimdeki fps değeri ile çarpıyoruz.
        }

        if(dikeyInput != 0)//Klavyeden yukarı ya da aşağı gitmek için veri gelip gelmediğini sorgusunu yapıyoruz.
        {
            position.y += dikeyInput * hareketGucu * Time.deltaTime;//Eğer yukarı ya da aşağı(-y ya da +y yönünde) gitmek için veri geliyorsa gelen veriyi(dikeyInput) uzay gemisinin bizim tanımlamış olduğumuz hareket gücüyle ve herbir çevrimdeki fps değeri ile çarpıyoruz.
        }
        transform.position = position;

        if(Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates();
            Vector3 kursunPozisyon = gameObject.transform.position;
            kursunPozisyon.y += 1;
            Instantiate(kursunPrefab, kursunPozisyon, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlama();
            oyunKontrol.OyunuBitir();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
