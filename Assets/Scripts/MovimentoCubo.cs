using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoCubo : MonoBehaviour
{
    private Vector2 direcao;

    private Rigidbody rbObj;

    [SerializeField] private float velocidade;

    private Transform cameraPosition;

    private void Start()
    {
        cameraPosition = Camera.main.transform;
    }
    public void setObjeto(GameObject obj)
    {
        if (obj == null)
        {
            rbObj = null;
        }
        else
        {
            rbObj = obj.GetComponent<Rigidbody>();
        }
    }

    public void Mover(InputAction.CallbackContext context)
    {
        direcao = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (rbObj == null) return;

        Vector3 movimento = new Vector3(direcao.x, 0f, direcao.y);

        Vector3 direcaoCamera = cameraPosition.TransformDirection(movimento);

        direcaoCamera.y = 0;

        rbObj.MovePosition(rbObj.position + direcaoCamera.normalized * velocidade * Time.deltaTime);
    }

}
