using UnityEngine;

public class FireboyScript : MonoBehaviour
{
    public Rigidbody2D personaje;
    private bool tocaSuperficie;
    public GameManagerScript gameManager;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            personaje.linearVelocity = new Vector2(-5, personaje.linearVelocity.y); // Mover izq
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            personaje.linearVelocity = new Vector2(5, personaje.linearVelocity.y); // Mover der
        }
        else if (tocaSuperficie == true && Input.GetKey(KeyCode.UpArrow))
        {
            personaje.linearVelocity = new Vector2(personaje.linearVelocity.x, 10); // saltar
        }
        else
        {
            personaje.linearVelocity = new Vector2(0, personaje.linearVelocity.y); // Detener movimiento horizontal
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Superficie") || collision.gameObject.CompareTag("aguaRoja"))
        {
            tocaSuperficie = true;
        }
        else if (collision.gameObject.CompareTag("aguaCeleste"))
        {
            gameManager.YouLose();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Superficie") || collision.gameObject.CompareTag("aguaRoja"))
        {
            tocaSuperficie = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("puertaRoja"))
        {
            gameManager.estaFireboy = true;
            gameManager.YouWin();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("puertaRoja"))
        {
            gameManager.estaFireboy = false;
        }
    }
}
