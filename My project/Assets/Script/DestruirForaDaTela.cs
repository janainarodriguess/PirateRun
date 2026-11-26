using UnityEngine;

public class DestruirForaDaTela : MonoBehaviour
{
    void Update()
    {
        Camera cam = Camera.main;
        float esquerda = cam.transform.position.x - cam.orthographicSize * cam.aspect - 2f;

        if (transform.position.x < esquerda)
            Destroy(gameObject);
    }
}