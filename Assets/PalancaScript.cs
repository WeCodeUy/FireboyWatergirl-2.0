using UnityEngine;

public class PalancaScript : MonoBehaviour
{
    private bool encendido = false;
    private bool durmiendo = false;
    private float temporizadorDormido = 0f;
    private float duracionDormido = 2f;
    public GameObject plataforma;
    public Vector3 posicionArriba;
    public Vector3 posicionAbajo;

    private void Update()
    {
        if (durmiendo)
        {
            temporizadorDormido += Time.deltaTime;
            if (temporizadorDormido >= duracionDormido)
            {
                durmiendo = false;
                temporizadorDormido = 0f;
            }
        }

        if (encendido == true)
        {
            SubirPlataforma();
        }
        else
        {
            BajarPlataforma();
        }
    }

    private void SubirPlataforma()
    {
        if (Vector3.Distance(plataforma.transform.position, posicionArriba) > 0.1f) // Si no está en la posición de arriba
        {
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, posicionArriba, 5 * Time.deltaTime);
        }
    }

    private void BajarPlataforma()
    {
        if (Vector3.Distance(plataforma.transform.position, posicionAbajo) > 0.1f) // Si no está en la posición de abajo
        {
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, posicionAbajo, 5 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (durmiendo == false)
        {
            if (encendido == false)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            encendido = !encendido;
            durmiendo = true;
        }
    }
}
