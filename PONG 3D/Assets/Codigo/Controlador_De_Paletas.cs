using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_De_Paletas : MonoBehaviour
{
    public bool player, pausa;
    public bool reanudar;
    public float VelocidadD, VelocidadI, VelocidadMax, Acelerador, InerciaATimer, InerciaDTimer, VelocidadInercialD, VelocidadInercialI;
    public bool InerciaA, InerciaD;
    public float tiempo;
    private void OnEnable()
    {
        GameEvents.current.PararPaletas.AddListener(Iniciar);
        GameEvents.current.GanaDerecha.AddListener(Pausa);
        GameEvents.current.GanaIzquierda.AddListener(Pausa);
    }
    // Start is called before the first frame update
    void Start()
    {
        VelocidadInercialI = VelocidadI;
        VelocidadInercialD = VelocidadD;
        pausa = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausa)
        {
            reanudar = false;
        }
        if (!pausa)
        {
            tiempo += Time.deltaTime;
            if (tiempo > 3)
            {
                reanudar = true;
                tiempo = 0;

                if(VelocidadI != 0)
                {
                    InerciaA = true;
                    VelocidadInercialI = VelocidadI;
                    VelocidadI = 0;
                    InerciaATimer = 0;
                }

                if (VelocidadD != 0)
                {
                    InerciaD = true;
                    VelocidadInercialD = VelocidadD;
                    InerciaDTimer = 0;
                    VelocidadD = 0;
                }
                


            }
        }
        if (player && reanudar)
        {
            //Movimiento Normal Izquierda
            //???????????????????????????????????????????????????????????????????
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.x > -10f)
            {
                if (VelocidadI < VelocidadMax)
                {
                    VelocidadI = VelocidadI + Acelerador * Time.deltaTime; //0.002
                }
                gameObject.transform.Translate(VelocidadI * Time.deltaTime * -1, 0, 0);
            }

            // Se levanto la tecla "A"?
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                InerciaA = true;
                VelocidadInercialI = VelocidadI;
                VelocidadI = 0;

                InerciaATimer = 0;

            }

            // Inercia Izquierda
            if (InerciaA && transform.position.x > -10f)
            {
                InerciaATimer += Time.deltaTime;
                gameObject.transform.Translate(VelocidadInercialI * Time.deltaTime * -1, 0, 0);
                if (VelocidadInercialI > 0)
                {
                    VelocidadInercialI = VelocidadInercialI - VelocidadInercialI * 4 * Time.deltaTime;
                }
                if (InerciaATimer > 0.5)
                {
                    InerciaA = false;
                    InerciaATimer = 0;
                }
            }
            else
            {
                InerciaA = false;
                InerciaATimer = 0;
            }
            //??????????????????????????????×????????????????????????????????????


            //Movimiento Normal Derecha
            //???????????????????????????????????????????????????????????????????
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.x < 10f)
            {
                if (VelocidadD < VelocidadMax)
                {
                    VelocidadD = VelocidadD + Acelerador * Time.deltaTime;
                }
                gameObject.transform.Translate(VelocidadD * Time.deltaTime, 0, 0);
            }
            // Se levanto la tecla "D"?
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                InerciaD = true;
                VelocidadInercialD = VelocidadD;
                InerciaDTimer = 0;
                VelocidadD = 0;
            }
            // Inercia Derecha
            if (InerciaD && transform.position.x < 10f)
            {
                InerciaDTimer += Time.deltaTime;
                gameObject.transform.Translate(VelocidadInercialD * Time.deltaTime, 0, 0);
                if (VelocidadInercialD > 0)
                {
                    VelocidadInercialD = VelocidadInercialD - VelocidadInercialD * 4 * Time.deltaTime;
                }
                if (InerciaDTimer > 0.5)
                {
                    InerciaD = false;
                    InerciaDTimer = 0;
                }
            }
            else
            {
                InerciaD = false;
                InerciaDTimer = 0;
            }
            //??????????????????????????????×????????????????????????????????????
        }
        if (!player && reanudar)
        {
            //Movimiento Normal Izquierda
            //???????????????????????????????????????????????????????????????????
            if (Input.GetKey(KeyCode.S) && transform.position.x > -10f)
            {
                if (VelocidadI < VelocidadMax)
                {
                    VelocidadI = VelocidadI + Acelerador * Time.deltaTime;
                }
                gameObject.transform.Translate(VelocidadI * Time.deltaTime * -1, 0, 0);
            }

            // Se levanto la tecla "A"?
            if (Input.GetKeyUp(KeyCode.S))
            {
                InerciaA = true;
                VelocidadInercialI = VelocidadI;
                VelocidadI = 0;

                InerciaATimer = 0;
            }

            // Inercia Izquierda
            if (InerciaA && transform.position.x > -10f)
            {
                InerciaATimer += Time.deltaTime;
                gameObject.transform.Translate(VelocidadInercialI * Time.deltaTime * -1, 0, 0);
                if (VelocidadInercialI > 0)
                {
                    VelocidadInercialI = VelocidadInercialI - VelocidadInercialI * 4 * Time.deltaTime;
                }
                if (InerciaATimer > 0.5)
                {
                    InerciaA = false;
                    InerciaATimer = 0;
                }
            }
            else
            {
                InerciaA = false;
                InerciaATimer = 0;
            }
            //??????????????????????????????×????????????????????????????????????


            //Movimiento Normal Derecha
            //???????????????????????????????????????????????????????????????????
            if (Input.GetKey(KeyCode.W) && transform.position.x < 10f)
            {
                if (VelocidadD < VelocidadMax)
                {
                    VelocidadD = VelocidadD + Acelerador * Time.deltaTime;
                }
                gameObject.transform.Translate(VelocidadD * Time.deltaTime, 0, 0);
            }
            // Se levanto la tecla "W"?
            if (Input.GetKeyUp(KeyCode.W))
            {
                InerciaD = true;
                VelocidadInercialD = VelocidadD;
                InerciaDTimer = 0;
                VelocidadD = 0;
            }
            // Inercia Derecha
            if (InerciaD && transform.position.x < 10f)
            {
                InerciaDTimer += Time.deltaTime;
                gameObject.transform.Translate(VelocidadInercialD * Time.deltaTime, 0, 0);
                if (VelocidadInercialD > 0)
                {
                    VelocidadInercialD = VelocidadInercialD - VelocidadInercialD * 4 * Time.deltaTime;
                }
                if (InerciaDTimer > 0.5)
                {
                    InerciaD = false;
                    InerciaDTimer = 0;
                }
            }
            else
            {
                InerciaD = false;
                InerciaDTimer = 0;
            }
            //??????????????????????????????×????????????????????????????????????
        }
    }
    public void Pausa()
    {
        pausa = true;
        tiempo = 0;
    }
    public void Reanudar()
    {
        pausa = false;
    }
    public void Iniciar()
    {
        tiempo = 0;
        reanudar = false;
        pausa = false;
        VelocidadD = 0;
        VelocidadI = 0;
        VelocidadInercialI= 0;
        VelocidadInercialD = 0;

        PosIn();
    }
    public void PosIn()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

}
