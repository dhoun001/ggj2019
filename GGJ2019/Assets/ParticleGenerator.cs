using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleGenerator : MonoBehaviour
{
    public List<GameObject> randomParticles = new List<GameObject>();

    public List<Transform> randomPosition = new List<Transform>();

    private void Start()
    {
        StartCoroutine(Do());
    }
    private void Update()
    {
  
    }
    private IEnumerator Do()
    {
        while (true)
        {
            GameObject random = randomParticles[Random.Range(0, randomParticles.Count)];
            GameObject instantiated = Instantiate(random);
            instantiated.transform.SetParent(transform);
            instantiated.AddComponent<MoveParticle>();
            Transform randomTransform = randomPosition[Random.Range(0, randomPosition.Count)];
            instantiated.transform.position = randomTransform.position;

            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }

    }
}

public class MoveParticle: MonoBehaviour
{
    private float lifetime = 20f;

    private void Start()
    {
        Invoke("DestroyPlease", lifetime);
    }

    private void Update()
    {
        transform.position = transform.position + Vector3.down * Random.Range(1f, 3f) * Time.deltaTime;
        transform.Rotate(new Vector3(0f, Random.Range(Time.deltaTime * 1f, Time.deltaTime * 5f), 0f));
    }

    private void DestroyPlease()
    {
        Destroy(gameObject);
    }
}
