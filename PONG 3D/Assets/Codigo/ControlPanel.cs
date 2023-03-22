using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPanel : MonoBehaviour
{
    public int inicio, PuntajeI, PuntajeD;
    public TMP_Text iniciocont, puntosI, puntosD;
    public float tiempocorriente;
    public bool iniciarcuenta, FinJuego;
    
    
    public GameObject PanelInicial;
    public GameObject PanelJugar;
    public GameObject PanelOpciones;
    public GameObject PanelPausa;
    public GameObject PanelReanudar;
    public GameObject PanelContador;
    public GameObject PanelPuntos;
    public GameObject PanelAviso1,PanelAviso2;
    public GameObject PanelCeleste, PanelRojo;
    private void OnEnable()
    {
        GameEvents.current.abrircontador.AddListener(abrircontador);
        GameEvents.current.SumarDerecha.AddListener(_sumarDerecha);
        GameEvents.current.SumarIzquierda.AddListener(_sumarIzquierda);
    }

    private void Start()
    {
        FinJuego = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F12))
        {
            PuntajeD = 9;
            PuntajeI = 9;
        }
        if (FinJuego)
        {
            PanelContador.SetActive(false);
        }
        if (inicio >= 0 && iniciarcuenta && !FinJuego)
        {
            tiempocorriente += Time.deltaTime;
            if (tiempocorriente > 1)
            {
                tiempocorriente = 0;
                inicio -= 1;
                if (inicio != 0)
                {
                    iniciocont.text = inicio.ToString("0");
                }
                if (inicio == 0)
                {
                    iniciarcuenta = false;
                    inicio = 3;
                    PanelContador.SetActive(false);
                }
                
            }
        }
        puntosI.text = PuntajeI.ToString("0");
        puntosD.text = PuntajeD.ToString("0");

    }
    public void openPanel(GameObject panel)
    {
        if(panel == PanelInicial && PanelPausa.activeInHierarchy)
        {
            PanelReanudar.SetActive(true);
            PanelContador.SetActive(false);
            inicio = 3;
            tiempocorriente = 0;
            iniciocont.text = inicio.ToString("0");
            iniciarcuenta = false;

        }
        PanelInicial.SetActive(false);
        PanelJugar.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelPausa.SetActive(false);
        if (panel == PanelPausa)
        {
            PanelReanudar.SetActive(false);
            if (!FinJuego)
            {
                PanelContador.SetActive(true);

            }   
            iniciarcontador();
            PanelPuntos.SetActive(true);
        }
        if (panel != PanelPausa)
        {
            PanelPuntos.SetActive(false);
        }
       


        panel.SetActive(true);

        
    }
    public void iniciarcontador()
    {
        if (!FinJuego)
        {
            iniciarcuenta = true;
        }
        
    }
    public void abrircontador()
    {
        inicio = 3;
        tiempocorriente = 0;
        iniciocont.text = inicio.ToString("0");
        
        if (!FinJuego)
        {
            iniciarcuenta = true;
            PanelContador.SetActive(true);
        }

    }
    public void _sumarDerecha()
    {
        PuntajeD += 1;
        ComprobarGanador();
    }
    public void _sumarIzquierda()
    {
        PuntajeI += 1;
        ComprobarGanador();
    }
    public void reiniciarCont()
    {
        PuntajeI = 0;
        PuntajeD = 0;
        puntosD.text = PuntajeD.ToString("0");
        puntosI.text = PuntajeI.ToString("0");
        FinJuego = false;
    }
    public void MostrarAviso1()
    {
        if (PanelReanudar.activeInHierarchy)
        {
            PanelAviso1.SetActive(true);
        }
        
    }
    public void OcultarAviso1()
    {
        PanelAviso1.SetActive(false);
    }
    public void MostrarAviso2()
    {
        PanelAviso2.SetActive(true);
    }
    public void OcultarAviso2()
    {
        PanelAviso2.SetActive(false);
    }
    public void ComprobarGanador()
    {
        if(PuntajeD > 9)
        {
            PanelCeleste.SetActive(true);
            PanelPausa.SetActive(false);
            GameEvents.current.GanaDerecha.Invoke();
            FinJuego = true;
            PanelInicial.SetActive(true);
        }
        if(PuntajeI > 9)
        {
            PanelRojo.SetActive(true);
            PanelPausa.SetActive(false);
            GameEvents.current.GanaIzquierda.Invoke();
            FinJuego = true;
            PanelInicial.SetActive(true);
        }
    }
    public void OcultarWin()
    {
        PanelCeleste.SetActive(false);
        PanelRojo.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }


}
