using System.Collections;
using UnityEngine;

public class GeradorDeMonstros : MonoBehaviour
{
    [Tooltip("Array de prefabs de monstros, ordenados por dificuldade")]
    [SerializeField] private GameObject[] monstros;

    [SerializeField] private Transform[] pontosDeSpawn;

    [SerializeField] private int monstrosIniciaisPorOnda;

    private int ondaAtual = 1;
    private float tempoRestanteParaProximaOnda;

    private Transform jogador;

    [SerializeField] private AudioSource novaOndaAudioSource;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(GerarOndas());

        InterfaceDeUsuario.Instance.AtualizarTempoRestante(tempoRestanteParaProximaOnda);
        InterfaceDeUsuario.Instance.AtualizarOndaAtual(ondaAtual);
    }

    private void Update()
    {
        tempoRestanteParaProximaOnda -= Time.deltaTime;
        InterfaceDeUsuario.Instance.AtualizarTempoRestante(tempoRestanteParaProximaOnda);
    }


    private IEnumerator GerarOndas()
    {
        while (true)
        {
            Jogador.Instance.RastaurarVida();
            novaOndaAudioSource.Play();

            tempoRestanteParaProximaOnda = 30 + 5 * ondaAtual;
            int totalMonstros = Mathf.CeilToInt(monstrosIniciaisPorOnda * Mathf.Log(ondaAtual + 1));

            int subOndas = Mathf.CeilToInt(tempoRestanteParaProximaOnda / 20);
            float intervaloSubOnda = tempoRestanteParaProximaOnda / subOndas;

            for(int i=0; i < subOndas; i++)
            {
                GerarMonstros(Mathf.CeilToInt(totalMonstros / subOndas));
                yield return new WaitForSeconds(intervaloSubOnda);
            }

            ondaAtual++;
            InterfaceDeUsuario.Instance.AtualizarOndaAtual(ondaAtual);
        }
    }

    private void GerarMonstros(int quantidadeDeMonstros)
    {
        for(int i=0; i < quantidadeDeMonstros; i++)
        {
            int maxIndiceMonstro = Mathf.Min(ondaAtual / 2, monstros.Length);
            int indiceTipoDeMonstro = Random.Range(0, maxIndiceMonstro);


            int indiceSpawn;
            do
            {
                indiceSpawn = Random.Range(0, pontosDeSpawn.Length);
            } 
            while (Vector3.Distance(pontosDeSpawn[indiceSpawn].position, jogador.position) < 15f);

            Transform pontoDeSpawn = pontosDeSpawn[indiceSpawn];
            Instantiate(monstros[indiceTipoDeMonstro], pontoDeSpawn.position, pontoDeSpawn.rotation);
        }
    }
}
