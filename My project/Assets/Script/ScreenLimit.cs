using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    public float margin = 0.5f;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        float halfH = cam.orthographicSize;
        float halfW = halfH * cam.aspect;
        Vector3 c = cam.transform.position;
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, c.x - halfW + margin, c.x + halfW - margin);
        pos.y = Mathf.Clamp(pos.y, c.y - halfH + margin, c.y + halfH - margin);

        transform.position = pos;
    }
}