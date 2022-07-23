using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab;
    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();
    GameObject uzayGemisi;
    List<GameObject> asteroidList = new List<GameObject>();
    [SerializeField]
    int zorluk = 1;
    [SerializeField]
    int carpan = 5;

    UIKontrol uiKontrol;
    // Start is called before the first frame update
    void Start()
    {
        uiKontrol = GetComponent<UIKontrol>();
    }

    public void OyunuBaslat()
    {
        uiKontrol.OyunBasladi();
        uzayGemisi = Instantiate(uzayGemisiPrefab);//Uzay gemisi nesnesini oluşturuyoruz.
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1, 0);//Uzay gemisinin x'i sıfır, y'si ekranın alt çizgisin 1.5 birim üstü ve z'sinin 0 olduğu yerde bulunmasını ayarlıyoruz. y değerine 1.5 birim eklenmesinin sebebi eğer EkranHesaplayıcısına göre ayarlanırsa uzay gemisinin ağırlık merkezini oraya koyacak ve colliderların çakışmasından kaynaklı uzay gemisinin üst colliderını ekranın alt colliderının hemen altına koyacak ve oyun başında uzay gemisi ekranda gözükmeyecek.
        AsteroidUret(5);
    }
    // Update is called once per frame
    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();//Oluşturulacak olan asteroidlerin pozisyonlarını tutuyoruz.
        for(int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);//x kordinatındaki pozisyonları ekranın solunda ya da sağında rastgele oluşacak şekilde ayarlıyoruz.
            position.y = EkranHesaplayicisi.Ust - 1;//y kordinatındaki pozisyonlarını ekranın üstünden bir birim aşağıda olacak şekilde ayarlıyoruz.
            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0,3)], position, Quaternion.identity);//3 farklı asteroid çeşidimiz olduğu için 0 ile 3'e kadar olan aralıktaki asteroid çeşidimizi rastgele bir şekilde oluşturuyoruz.
            asteroidList.Add(asteroid);//Ekran oluşturulan asteroidlerin sayısını oluşturmuş olduğumuz listede tutuyoruz.
        }
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
        uiKontrol.AsteroidYokOldu(asteroid);
        asteroidList.Remove(asteroid);
        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void OyunuBitir()
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt();
        }

        asteroidList.Clear();
        zorluk = 1;
        uiKontrol.OyunBitti();
    }
}
