using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayimSayaci : MonoBehaviour
{
    float toplamSure = 0;
    float gecenSure = 0;

    bool calisiyor = false;
    bool basladi = false;

    public float ToplamSure
    {
        set
        {
            if(!calisiyor)
            {
                toplamSure = value;
            }
        }
    }

    public void Calistir()
    {
        if(toplamSure > 0)
        {
            calisiyor = true;
            basladi = true;
            gecenSure = 0;
        }
    }

    public bool Bitti
    {
        get
        {
            return basladi && !calisiyor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(calisiyor)
        {
            gecenSure += Time.deltaTime;//deltaTime propertysi sistem çalıştıktan sonraki geçen süreyi hesaplar. Birimi sn değildir, oyunun çalıştığı cihazın fps değeridir.
            if(gecenSure >= toplamSure)
            {
                calisiyor = false;
            }
        }
    }
}
