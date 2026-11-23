using UnityEngine;

public class PacoteColetavel : MonoBehaviour
{
    public CorSetor corDoPacote = CorSetor.Azul;

    void OnTriggerEnter(Collider other)
    {
        CicloEntregaManager entregas = other.GetComponent<CicloEntregaManager>();
        if (entregas != null && !entregas.estaCarregandoPacote)
        {
            entregas.ColetarPacote(this);
        }
    }
}