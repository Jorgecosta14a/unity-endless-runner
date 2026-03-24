using UnityEngine;
using System.Collections.Generic; // Precisamos disto para criar uma Lista

public class GroundSpawner : MonoBehaviour
{
    [Header("Referências")]
    public Transform player; // O jogo precisa de saber onde está o jogador
    public GameObject[] groundTiles; // Os teus prefabs
    
    [Header("Configurações")]
    private float spawnZ = 0f;       // Onde vai nascer o próximo chão
    private float tileLength = 20f;  // O tamanho do teu chão em Z (ajusta se for 30 ou outro valor)
    private int tilesOnScreen = 5;   // Quantos chãos existem ao mesmo tempo
    
    // Lista para guardar os chãos que estão no ecrã e podermos apagar os velhos
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        // Cria as pistas iniciais
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i == 0) 
                SpawnTile(0); // Garante que a primeira é o Ground_vazio
            else 
                SpawnTile(Random.Range(0, groundTiles.Length));
        }
    }

    void Update()
    {
        // A MATEMÁTICA MÁGICA:
        // Se a posição do jogador for maior que o ponto onde os chãos velhos começam a ficar para trás...
        if (player.position.z - tileLength > spawnZ - (tilesOnScreen * tileLength))
        {
            // Cria um chão novo lá à frente
            SpawnTile(Random.Range(0, groundTiles.Length));
            
            // Apaga o chão mais velho lá atrás
            DeleteOldTile();
        }
    }

    private void SpawnTile(int prefabIndex)
    {
        // Cria o chão
        GameObject go = Instantiate(groundTiles[prefabIndex], new Vector3(0, 0, spawnZ), Quaternion.identity);
        
        // Adiciona à nossa lista de "chãos ativos"
        activeTiles.Add(go);
        
        // Empurra o marcador para a frente para o próximo nascer a seguir a este
        spawnZ += tileLength;
    }

    private void DeleteOldTile()
    {
        // Destrói o chão mais antigo (o primeiro da lista)
        Destroy(activeTiles[0]);
        
        // Remove-o da lista para os outros andarem para a frente
        activeTiles.RemoveAt(0);
    }
}