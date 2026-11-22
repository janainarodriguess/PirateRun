using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static float Multiplier = 1f;
    public float increasePerSecond = 0.02f;
    public float maxMultiplier = 3f;

    void Start()
    {
        Multiplier = 1f;
    }

    void Update()
    {
        Multiplier = Mathf.Min(Multiplier + increasePerSecond * Time.deltaTime, maxMultiplier);
    }
}