using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            current = this;
        }
    }

    public UnityEvent abrircontador = new UnityEvent();
    public UnityEvent PararPaletas = new UnityEvent();
    public UnityEvent SumarDerecha = new UnityEvent();
    public UnityEvent SumarIzquierda = new UnityEvent();
    public UnityEvent GanaDerecha = new UnityEvent();
    public UnityEvent GanaIzquierda = new UnityEvent();
}
