using TMPro;
using UnityEngine;

public class GerenciadorPontuacao : MonoBehaviour
{
    [SerializeField] private TMP_Text pontuacaoText;
    private int pontuacao;

    public void adicionarPontuacao()
    {
        pontuacao++;
        pontuacaoText.text = pontuacao.ToString();
    }
}
