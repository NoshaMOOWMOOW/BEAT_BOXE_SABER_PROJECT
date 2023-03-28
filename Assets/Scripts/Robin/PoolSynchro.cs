using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSynchro : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 0.5f;
    public float speed = 5f;
    public float despawnDistance = 5f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // Attendre jusqu'à ce que la musique atteigne le moment approprié pour la génération
            yield return new WaitForSeconds(spawnInterval);

            // Générer des prefabs aléatoirement
            int index = Random.Range(0, prefabs.Length);
            GameObject prefab = prefabs[index];
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPoint = spawnPoints[spawnIndex].position;
            Instantiate(prefab, spawnPoint, Quaternion.identity);

            // Jouer la musique
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void Update()
    {
        // Détruire les prefabs qui ont dépassé le joueur
        for (int i = 0; i<prefabs.Length; i++)
        {
            float distance = Mathf.Abs(prefabs[i].transform.position.x - transform.position.x);

            if (distance > despawnDistance)
            {
                Destroy(prefabs[i]);
                Debug.Log("distance > despawndistance");
            }
            else
            {
                // Déplacer les prefabs vers le joueur
                prefabs[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
