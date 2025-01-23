using UnityEngine;

public class WatergirlScript : MonoBehaviour
{
    public Rigidbody2D personaje;
    private bool tocaSuperficie;
    public GameManagerScript gameManager; //nuevo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("puertaCeleste"))
        {
            gameManager.estaWatergirl = true;
            gameManager.YouWin();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("puertaCeleste"))
        {
            gameManager.estaWatergirl = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Superficie") || collision.gameObject.CompareTag("aguaCeleste"))
        {
            tocaSuperficie = true;
        }
        else if (collision.gameObject.CompareTag("aguaRoja"))
        {
            gameManager.YouLose();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            personaje.linearVelocity = new Vector2(-5, personaje.linearVelocity.y); // Mover izq
        }
        else if (Input.GetKey(KeyCode.D))
        {
            personaje.linearVelocity = new Vector2(5, personaje.linearVelocity.y); // Mover der
        }
        else if (tocaSuperficie == true && Input.GetKey(KeyCode.W))
        {
            personaje.linearVelocity = new Vector2(personaje.linearVelocity.x, 10); // saltar
        }
        else
        {
            personaje.linearVelocity = new Vector2(0, personaje.linearVelocity.y); // Detener movimiento horizontal
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Superficie") || collision.gameObject.CompareTag("aguaCeleste"))
        {
            tocaSuperficie = false;
        }
    }
}
