using UnityEngine;

public class SetorEntrega : MonoBehaviour
{
    public CorSetor corDesteSetor = CorSetor.Azul;

    void OnTriggerEnter(Collider other)
    {
        CicloEntregaManager entregas = other.GetComponent<CicloEntregaManager>();
        if (entregas != null && entregas.estaCarregandoPacote)
        {
            entregas.TentarEntregarNoSetor(corDesteSetor);
        }
    }
}