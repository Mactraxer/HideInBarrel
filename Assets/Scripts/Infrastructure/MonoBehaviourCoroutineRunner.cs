using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class MonoBehaviourCoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine Run(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}