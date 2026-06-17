using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GeradorCubos : MonoBehaviour
{
    [SerializeField] private GameObject[] cuboPrefab;
    private GameObject ultimoCuboGerado;

    [SerializeField] private GameObject objetoMovimentoCubo;

    private MovimentoCubo movimentoCubo;

    private AlturaDaConstrucao alturaDaConstrucao;

    [SerializeField] private UnityEvent onSoltarCubo;

    void Start()
    {
        movimentoCubo = objetoMovimentoCubo.GetComponent<MovimentoCubo>();
        alturaDaConstrucao = GetComponent<AlturaDaConstrucao>();
        gerarCubo();
    }

    void Update()
    {
        
    }

    public void soltarCubo(InputAction.CallbackContext context)
    {
        if(ultimoCuboGerado == null) return;

        movimentoCubo.setObjeto(null);

        ultimoCuboGerado.GetComponent<Rigidbody>().useGravity = true;

        ultimoCuboGerado.transform.GetChild(0).gameObject.SetActive(false);
        ultimoCuboGerado = null;
        
        onSoltarCubo.Invoke();

        Invoke(nameof(gerarCubo), 3f);
    }

    private void gerarCubo()
    {
        GameObject blocoEscolhido = cuboPrefab[Random.Range(0, cuboPrefab.Length)];
        ultimoCuboGerado = Instantiate(blocoEscolhido, new Vector3(
                                                                Random.Range(-3,4),
                                                                alturaDaConstrucao.AlturaAtual() + 2,
                                                                Random.Range(-3, 4)), 
                                                                Quaternion.identity);

        int tamanhoX = 1; //Random.Range(1, 6);
        int tamanhoY = 1; //Random.Range(1, 5);
        int tamanhoZ = 1; //Random.Range(1, 7);

        ultimoCuboGerado.transform.localScale = new Vector3(tamanhoX, tamanhoY, tamanhoZ);

        movimentoCubo.setObjeto(ultimoCuboGerado);
    }
}
