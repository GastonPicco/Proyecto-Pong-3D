using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Pelota : MonoBehaviour
{
    public float x, z, velocidad, acelerador, velocidadI;
    public GameObject Player;
    public GameObject Player2;
    public float Ux, Uz;
    public float tiempo;
    public bool reanudar;
    public bool FinJuego;
    int random;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameEvents.current.GanaDerecha.AddListener(TerminarGame);
        GameEvents.current.GanaIzquierda.AddListener(TerminarGame);
    }
    void Start()
    {
        reanudar = false;
        x = 0;
        z = 0;
        velocidadI = velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        if (reanudar)
        {
            tiempo += Time.deltaTime;
            if(tiempo > 3)
            {
                z = Uz;
                x = Ux;
                tiempo = 0;
                reanudar = false;
            }
        }       
        gameObject.transform.Translate(x*Time.deltaTime*velocidad,0,z*Time.deltaTime*velocidad);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            x = x * -1;
        }
        if (collision.gameObject.tag == "Puntos" && transform.position.z > 0)
        {
            z = z * -1;

            GameEvents.current.abrircontador.Invoke();
            Debug.Log("abre contador");
            GameEvents.current.PararPaletas.Invoke();
            Debug.Log("frena paletas");
            GameEvents.current.SumarIzquierda.Invoke();
            Debug.Log("sumarPuntosIzquierda");
            velocidad = velocidadI;
            Debug.Log("Toca pared izquierda");
            if (!FinJuego)
            {
                Iniciar();
            }
            
        }
        if (collision.gameObject.tag == "Puntos" && transform.position.z < 0)
        {
            z = z * -1;


            GameEvents.current.abrircontador.Invoke();
            Debug.Log("abre contador");
            GameEvents.current.PararPaletas.Invoke();
            Debug.Log("frena paletas");
            GameEvents.current.SumarDerecha.Invoke();
            Debug.Log("suma puntos derecha");
            velocidad = velocidadI;
            Debug.Log("Toca pared derecha");
            if (!FinJuego)
            {
                Iniciar();
            }
        }
        if (collision.gameObject.tag == "Player" && transform.position.z < -15.5 && transform.position.z > -16.5)
        {
            x = x * -1;
            Debug.Log("REBOTA LADO");
        }
        else if (collision.gameObject.tag == "Player" && transform.position.z >= -15.5 && transform.position.z <= -15.010 && Player.transform.position.x-transform.position.x < -1.55 && x < 0)
        {
            Debug.Log("REBOTA PUNTA Derecha");
            x = x * -1;
            z = z * -1;
        }
        else if (collision.gameObject.tag == "Player" && transform.position.z >= -15.5 && transform.position.z <= -15.010 && Player.transform.position.x - transform.position.x > 1.55 && x > 0)
        {
            Debug.Log("REBOTA PUNTA Izquierda");
            x = x * -1;
            z = z * -1;
        }
        else if (collision.gameObject.tag == "Player" && transform.position.z > -15.4 )
        {
            Debug.Log("REBOTA PALETA");
            z = z * -1;
            velocidad = velocidad * acelerador;
        }


        if (collision.gameObject.tag == "Player2" && transform.position.z > 15.5 && transform.position.z < 16.5)
        {
            x = x * -1;
            Debug.Log("REBOTA LADO");
        }
        else if (collision.gameObject.tag == "Player2" && transform.position.z <= 15.5 && transform.position.z >= 15.010 && Player2.transform.position.x - transform.position.x < -1.55 && x < 0)
        {
            Debug.Log("REBOTA PUNTA Derecha");
            x = x * -1;
            z = z * -1;
        }
        else if (collision.gameObject.tag == "Player2" && transform.position.z <= 15.5 && transform.position.z >= 15.010 && Player2.transform.position.x - transform.position.x > 1.55 && x > 0)
        {
            Debug.Log("REBOTA PUNTA Izquierda");
            x = x * -1;
            z = z * -1;
        }
        else if (collision.gameObject.tag == "Player2" && transform.position.z < 15.4 )
        {
            Debug.Log("REBOTA PALETA");
            Debug.Log(gameObject.transform.position.z);
            z = z * -1;
            velocidad = velocidad * acelerador;

                
        }
        
        
    }
    public void Pausa()
    {
        
        if (!reanudar)
        {
            Ux = x;
            Uz = z;
        }
        reanudar = false;
        tiempo = 0;
        x = 0;
        z = 0;
    }
    public void Reanudar()
    {
        reanudar = true;
        Debug.Log("Se pudo Reanudar");
        

    }
    public void Iniciar()
    {
        FinJuego = false;
        Debug.Log("Se pudo iniciar");
        x = 0;
        z = 0;
        transform.position = new Vector3(0, transform.position.y, 0);
        random = Random.Range(-1,1);
        if (random == 0)
        {
            Ux = 1;
        }
        else
        {
            Ux = -1;
        }
        Debug.Log("x asignado");
        random = Random.Range(-1,1);
        if (random == 0)
        {
            Uz = 1;
        }
        else
        {
            Uz = -1;
        }
        Debug.Log("z asignado");
        Debug.Log("Reanudar");
        Reanudar();
    }
    public void TerminarGame()
    {
        Pausa();
        velocidad = velocidadI;
        FinJuego = true;
        
    }



}
