using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables de mouvement
    public float gravity = -9.8f;
    public float strength = 1f;
    private Vector3 direction;

    // --- NOUVEAU : Variables pour l'Animation ---
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Tableau pour stocker les images (les frames) de l'animation
    private int spriteIndex;

    private void Awake()
    {
        // On récupère le composant qui affiche l'image
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // --- NOUVEAU ---
        // Cette ligne lance l'animation. Elle appelle la fonction "AnimateSprite"
        // toutes les 0.15 secondes.
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        // Gestion des entrées (Espace ou Clic)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Gestion des touches tactiles (Mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        // Application de la gravité et du mouvement
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    // --- NOUVEAU : Fonction qui change l'image ---
    private void AnimateSprite()
    {
        spriteIndex++; // On passe à l'image suivante

        // Si on dépasse la dernière image, on revient à la première (0)
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // On change l'image affichée à l'écran
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
