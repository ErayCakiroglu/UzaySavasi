using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EkranHesaplayicisi
{
    static float sol;
    static float sag;
    static float ust;
    static float alt;

    public static float Sol
    {
        get
        {
            return sol;
        }
    }
    public static float Sag
    {
        get
        {
            return sag;
        }
    }
    public static float Ust
    {
        get
        {
            return ust;
        }
    }
    public static float Alt
    {
        get
        {
            return alt;
        }
    }

    public static void Init()
    {
        float ekranZEkseni = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0, 0, ekranZEkseni);
        Vector3 sagUstKose = new Vector3(Screen.width, Screen.height, ekranZEkseni);

        Vector3 solAltKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(solAltKose);
        Vector3 sagUstKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(sagUstKose);

        sol = solAltKoseOyunDunyasi.x;
        sag = sagUstKoseOyunDunyasi.x;
        alt = solAltKoseOyunDunyasi.y;
        ust = sagUstKoseOyunDunyasi.y;
    }
}
