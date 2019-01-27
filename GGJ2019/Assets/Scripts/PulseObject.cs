using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseObject : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    public void Pulse()
    {
        StopAllCoroutines();
        StartCoroutine(Pulsing());
    }

    private IEnumerator Pulsing()
    {
        while (true)
        {
            while (transform.transform.localScale.x < 1.5f)
            {
                transform.transform.localScale += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed);
                yield return null;
            }

            while (transform.localScale.x > 0.5f)
            {
                transform.transform.localScale -= new Vector3(Time.deltaTime * speed, Time.deltaTime * speed);
                yield return null;
            }
        }
    }

    public void StopPulse()
    {
        StopAllCoroutines();
    }
}
