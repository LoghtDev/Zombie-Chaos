using UnityEngine;

public class DestruirObjecto : MonoBehaviour
{
    [SerializeField] private float tempoDeVida;

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

}
