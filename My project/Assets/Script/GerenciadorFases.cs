using UnityEngine;
using TMPro;
using System.Collections;

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

    [Header("Visual do texto da fase")]
    public Color corTexto = new Color(1f, 0.85f, 0.3f, 1f);
    public Color corContorno = new Color(0.25f, 0.1f, 0.02f, 1f);
    [Range(0f, 1f)] public float larguraContorno = 0.25f;
    public float tempoEntrada = 0.45f;
    public float tempoParado = 1.3f;
    public float tempoSaida = 0.5f;

    float timer;
    int faseAtual = -1;
    Coroutine animacaoTexto;

    void Start()
    {
        ConfigurarTexto();
        AplicarFase(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (faseAtual + 1 < fases.Length && timer >= fases[faseAtual + 1].aPartirDeSegundos)
            AplicarFase(faseAtual + 1);
    }

    void ConfigurarTexto()
    {
        if (textoFase == null) return;

        textoFase.color = corTexto;
        textoFase.fontStyle = FontStyles.Bold;
        textoFase.alignment = TextAlignmentOptions.Center;
        textoFase.outlineColor = corContorno;
        textoFase.outlineWidth = larguraContorno;
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
                extra.minGap = f.gapMin + 2f;   
                extra.maxGap = f.gapMax + 2f;
            }
        }

        if (textoFase != null)
        {
            if (animacaoTexto != null) StopCoroutine(animacaoTexto);
            animacaoTexto = StartCoroutine(AnimarTexto("FASE " + (i + 1)));
        }
    }

    IEnumerator AnimarTexto(string mensagem)
    {
        textoFase.text = mensagem;
        textoFase.gameObject.SetActive(true);
        RectTransform rt = textoFase.rectTransform;

        
        float t = 0f;
        while (t < tempoEntrada)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / tempoEntrada);
            rt.localScale = Vector3.one * Mathf.LerpUnclamped(0.5f, 1f, EaseOutBack(p));
            textoFase.alpha = p;
            yield return null;
        }
        rt.localScale = Vector3.one;
        textoFase.alpha = 1f;

      
        yield return new WaitForSeconds(tempoParado);

        
        t = 0f;
        while (t < tempoSaida)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / tempoSaida);
            rt.localScale = Vector3.one * Mathf.Lerp(1f, 1.15f, p);
            textoFase.alpha = 1f - p;
            yield return null;
        }

        textoFase.gameObject.SetActive(false);
        rt.localScale = Vector3.one;
    }

    float EaseOutBack(float x)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;
        return 1f + c3 * Mathf.Pow(x - 1f, 3) + c1 * Mathf.Pow(x - 1f, 2);
    }
}