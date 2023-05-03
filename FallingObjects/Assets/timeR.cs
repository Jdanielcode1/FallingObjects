using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class timeR : MonoBehaviour
{

    public static timeR instanciar;
    public TextMeshProUGUI Crono;
    private TimeSpan tiempoCrono;
    private bool timerBool;
    private float time_taken;
    private float startTime;
    

    private void Awake()
    {
        instanciar = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        Crono.text = "Tiempo: 00:00:00";
        timerBool = true;
        startTime = Time.time;
        
    }

    public void ResetTimer()
    {
        startTime= Time.time;
        time_taken = 0;
        

    }

    public void IniciarTiempo()
    {
        timerBool = true;
        time_taken = 0F;
        


        StartCoroutine(ActUpdate());
    }

    public void FinTiempo()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            Debug.Log("Tiempo:" + tiempoCrono.TotalSeconds.ToString());
            FloorCollider.instanciar.LogCount();
       

        }
    }



    private IEnumerator ActUpdate()
    {
        while (timerBool)
        {
            
            time_taken += (Time.deltaTime/2.5f);
            tiempoCrono = TimeSpan.FromSeconds(time_taken);
            double tiempoEnSegundos = tiempoCrono.TotalSeconds;
            string tiempoCronoStr = "Tiempo: " + tiempoEnSegundos.ToString("0.00");
            Crono.text = tiempoCronoStr;


            yield return null;
        }
    }


}
