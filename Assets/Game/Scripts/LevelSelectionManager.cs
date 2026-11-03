using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    [Header("Configuração de Dados")]
    [SerializeField] private List<LevelData> allLevels; // Lista com todos os ScriptableObjects

    [Header("Referências de UI")]
    [SerializeField] private Transform contentParent;   // O objeto "Content" do ScrollView
    [SerializeField] private GameObject levelCardPrefab; // Prefab contendo o LevelCardUI

    private void Start()
    {
        GenerateLevelCards();
    }

    private void GenerateLevelCards()
    {
        // Limpa cards antigos que possam existir no container
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Instancia um cartão para cada ScriptableObject cadastrado
        foreach (LevelData levelData in allLevels)
        {
            GameObject cardObj = Instantiate(levelCardPrefab, contentParent);
            LevelCardUI cardUI = cardObj.GetComponent<LevelCardUI>();

            if (cardUI != null)
            {
                cardUI.SetupCard(levelData);
            }
        }
    }
}