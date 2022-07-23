using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikleyici : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()//Awake metodu Start metodundan önce gelen ve Initialize gibi işlemlerin yapıldığı metottur.
    {
        EkranHesaplayicisi.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
