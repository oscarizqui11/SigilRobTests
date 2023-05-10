using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SimonDice : MonoBehaviour
{
    public GameObject panel;
    public Button[] botones;
    public int[] secuencia;
    public int largoSecuencia;
    public float tiempoEntreColores = 1.0f;

    private int index = 0;
    private bool esperandoJugador = false;

    void Start()
    {
        // Generar una secuencia aleatoria
        secuencia = new int[largoSecuencia];
        for (int i = 0; i < secuencia.Length; i++)
        {
            secuencia[i] = Random.Range(0, botones.Length);
        }

        // Inicializar los botones
        for (int i = 0; i < botones.Length; i++)
        {
            int index = i;
            botones[i].onClick.AddListener(() => BotonPresionado(index));
        }

        // Iniciar la secuencia
        MostrarSecuencia();
    }

    public void BotonPresionado(int index)
    {
        // Verificar si el jugador presion� el bot�n correcto
        if (index == secuencia[this.index])
        {
            this.index++;

            if (this.index >= secuencia.Length)
            {
                // El jugador gan� el juego
                Debug.Log("�Ganaste!");
            }
            else
            {
                // Mostrar el siguiente color en la secuencia
                esperandoJugador = false;
                MostrarSecuencia();
            }
        }
        else
        {
            // El jugador perdi� el juego
            Debug.Log("�Perdiste!");
        }
    }

    void MostrarSecuencia()
    {
        esperandoJugador = false;

        // Mostrar cada color en la secuencia
        for (int i = 0; i <= index; i++)
        {
            Button boton = botones[secuencia[i]];
            boton.image.color = Color.white;

            // Agregar el material del bot�n al panel
            Material material = Instantiate(boton.GetComponent<Renderer>().material, panel.transform);
            material.name = boton.name + " (Material)"; // Renombrar el material para que sea f�cil de identificar

            // Utilizar una acci�n para esperar antes de volver a oscurecer el bot�n
            StartCoroutine(Esperar(tiempoEntreColores, () =>
            {
                boton.image.color = Color.grey;

                if (i == index)
                {
                    // Si este es el �ltimo bot�n en la secuencia, esperar a que el jugador presione un bot�n
                    esperandoJugador = true;
                }
            }));
        }
    }


    IEnumerator Esperar(float tiempo, System.Action callback)
    {
        yield return new WaitForSeconds(tiempo);
        callback.Invoke();
    }

    void Update()
    {
        // Verificar si el jugador presion� un bot�n
        if (esperandoJugador)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                BotonPresionado(0); // Presion� el bot�n 0
            }
            else if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                BotonPresionado(1); // Presion� el bot�n 1
            }
            // Agregar m�s else if para cada bot�n
        }
    }
}
