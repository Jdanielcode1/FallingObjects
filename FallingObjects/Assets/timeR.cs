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
    private float tiempoTrans;
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
        tiempoTrans = 0;

    }

    public void IniciarTiempo()
    {
        timerBool = true;
        tiempoTrans = 0F;

        StartCoroutine(ActUpdate());
    }

    public void FinTiempo()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Tiempo:" + tiempoCrono.ToString());
            FloorCollider.instanciar.LogCount();
       

        }
    }



    private IEnumerator ActUpdate()
    {
        while (timerBool)
        {
            tiempoTrans += Time.deltaTime;
            tiempoCrono = TimeSpan.FromSeconds(tiempoTrans);
            string tiempoCronoStr = "Tiempo: " + tiempoCrono.ToString("mm':'ss':'ff");
            Crono.text = tiempoCronoStr;


            yield return null;
        }
    }


}
