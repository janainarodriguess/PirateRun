using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float velocidade = 3f;             // mesma velocidade das pedras
    public float espacamento = 1.2f;          // distância entre moedas do grupo
    public float distanciaEntreGrupos = 8f;   // espaço vazio entre grupos

    [Header("Grupo no chão")]
    public int moedasNoChao = 3;
    public float yBaixo = -2f;

    [Header("Grupo em arco (pulo)")]
    public int moedasNoArco = 5;
    public float yAlto = 0.5f;
    [Range(0f, 1f)] public float chanceArco = 0.4f;

    float percorrido = 0f;
    float proximaDistancia = 0f;
    void Start()
    {
        // apaga as moedas antigas colocadas à mão na cena
        foreach (GameObject obj in gameObject.scene.GetRootGameObjects())
        {
            string n = obj.name;
            if (n.StartsWith("Coin") && n != "CoinSpawner" && n != "CoinManager" && !n.Contains("Clone"))
                Destroy(obj);
        }
    }

    void Update()
    {
        percorrido += velocidade * GameSpeed.Multiplier * Time.deltaTime;
        if (percorrido < proximaDistancia) return;

        bool arco = Random.value < chanceArco;
        int quantidade = arco ? moedasNoArco : moedasNoChao;

        Camera cam = Camera.main;
        float xInicio = cam.transform.position.x + cam.orthographicSize * cam.aspect + 1.5f;

        for (int i = 0; i < quantidade; i++)
        {
            float y = yBaixo;
            if (arco && quantidade > 1)
            {
                float t = (float)i / (quantidade - 1);
                y = Mathf.Lerp(yBaixo, yAlto, Mathf.Sin(t * Mathf.PI));
            }

            GameObject c = Instantiate(coinPrefab, new Vector3(xInicio + i * espacamento, y, 0f), Quaternion.identity);

            // tira o movimento antigo (que reciclava a moeda) e põe o novo
            Destroy(c.GetComponent<MoveLeft>());
            c.AddComponent<MoedaMover>().velocidade = velocidade;
        }

        percorrido = 0f;
        proximaDistancia = quantidade * espacamento + distanciaEntreGrupos;
    }
}

public class MoedaMover : MonoBehaviour
{
    public float velocidade = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * GameSpeed.Multiplier * Time.deltaTime);

        Camera cam = Camera.main;
        float esquerda = cam.transform.position.x - cam.orthographicSize * cam.aspect - 2f;
        if (transform.position.x < esquerda) Destroy(gameObject);
    }
}