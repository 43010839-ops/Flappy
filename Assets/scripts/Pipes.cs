using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // Définit le bord gauche de l'écran en coordonnées du monde, avec une marge de -1
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Déplace le tuyau vers la gauche à chaque frame
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Détruit l'objet s'il dépasse le bord gauche calculé
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
