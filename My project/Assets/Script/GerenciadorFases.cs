using UnityEngine;
using TMPro;

public class GerenciadorFases : MonoBehaviour
{
    [System.Serializable]
    public class Fase
    {
        public float aPartirDeSegundos;
        public float velocidade = 1f;
        public float gapMin = 6f;
        public float gapMax = 14f;
        public bool obstaculoExtra;
    }

    public Fase[] fases = new Fase[]
    {
        new Fase { aPartirDeSegundos = 0,  velocidade = 1.0f, gapMin = 8, gapMax = 16, obstaculoExtra = false },
        new Fase { aPartirDeSegundos = 25, velocidade = 1.4f, gapMin = 6, gapMax = 12, obstaculoExtra = false },
        new Fase { aPartirDeSegundos = 50, velocidade = 1.8f, gapMin = 5, gapMax = 10, obstaculoExtra = true  },
    };

    public MoveLeft obstaculo;
    public GameObject obstaculoExtra;
    public TMP_Text textoFase;

    float timer;
    float tempoTexto;
    int faseAtual = -1;

    void Start()
    {
        AplicarFase(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (faseAtual + 1 < fases.Length && timer >= fases[faseAtual + 1].aPartirDeSegundos)
            AplicarFase(faseAtual + 1);

        if (tempoTexto > 0f)
        {
            tempoTexto -= Time.deltaTime;
            if (tempoTexto <= 0f && textoFase != null)
                textoFase.gameObject.SetActive(false);
        }
    }

    void AplicarFase(int i)
    {
        faseAtual = i;
        Fase f = fases[i];

        GameSpeed.Multiplier = f.velocidade;

        if (obstaculo != null)
        {
            obstaculo.minGap = f.gapMin;
            obstaculo.maxGap = f.gapMax;
        }

        if (obstaculoExtra != null)
        {
            obstaculoExtra.SetActive(f.obstaculoExtra);
            MoveLeft extra = obstaculoExtra.GetComponent<MoveLeft>();
            if (extra != null)
            {
                extra.minGap = f.gapMin + 2f;   // afasta do obstáculo principal
                extra.maxGap = f.gapMax + 2f;
            }
        }

        if (textoFase != null)
        {
            textoFase.text = "FASE " + (i + 1);
            textoFase.gameObject.SetActive(true);
            tempoTexto = 2f;
        }
    }
}