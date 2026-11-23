using UnityEngine;

public class ControladorPlacas : MonoBehaviour
{
    public enum Direcao
    {
        Norte,
        Sul,
        Leste,
        Oeste
    }

    [Header("Objetos das Placas")]
    [SerializeField] private GameObject placaNorte;
    [SerializeField] private GameObject placaSul;
    [SerializeField] private GameObject placaLeste;
    [SerializeField] private GameObject placaOeste;

    [Header("Placas Ativas")]
    [SerializeField] private bool norteAtiva = true;
    [SerializeField] private bool sulAtiva = true;
    [SerializeField] private bool lesteAtiva = true;
    [SerializeField] private bool oesteAtiva = true;

    private void Start()
    {
        AtualizarTodas();
    }

    private void OnValidate()
    {
        AtualizarTodas();
    }

    public void AtualizarTodas()
    {
        if (placaNorte != null) placaNorte.SetActive(norteAtiva);
        if (placaSul != null) placaSul.SetActive(sulAtiva);
        if (placaLeste != null) placaLeste.SetActive(lesteAtiva);
        if (placaOeste != null) placaOeste.SetActive(oesteAtiva);
    }

    public void DefinirPlaca(Direcao direcao, bool ativa)
    {
        switch (direcao)
        {
            case Direcao.Norte:
                norteAtiva = ativa;
                if (placaNorte != null) placaNorte.SetActive(ativa);
                break;
            case Direcao.Sul:
                sulAtiva = ativa;
                if (placaSul != null) placaSul.SetActive(ativa);
                break;
            case Direcao.Leste:
                lesteAtiva = ativa;
                if (placaLeste != null) placaLeste.SetActive(ativa);
                break;
            case Direcao.Oeste:
                oesteAtiva = ativa;
                if (placaOeste != null) placaOeste.SetActive(ativa);
                break;
        }
    }

    public void ConfigurarPlacas(bool norte, bool sul, bool leste, bool oeste)
    {
        norteAtiva = norte;
        sulAtiva = sul;
        lesteAtiva = leste;
        oesteAtiva = oeste;
        AtualizarTodas();
    }

    public void DesativarTodas()
    {
        ConfigurarPlacas(false, false, false, false);
    }
}