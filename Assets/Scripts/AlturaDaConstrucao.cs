using UnityEngine;

public class AlturaDaConstrucao : MonoBehaviour
{
    public float AlturaAtual()
    {
        Vector3 posTeste = transform.position;
        bool alturaEncontrada = false;

        while (!alturaEncontrada)
        {
            if (Physics.CheckBox(transform.position, new Vector3(15,1,15)))
            {
                Debug.Log("Encontrou algo na altura: " + posTeste);
                transform.position += Vector3.up;
            }
            else
            {
                alturaEncontrada = true;
            }
        }
        return transform.position.y;
    }
}
