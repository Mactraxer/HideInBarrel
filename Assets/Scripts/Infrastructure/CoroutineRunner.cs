using System.Collections;
using UnityEngine;

public interface ICoroutineRunner
{
    public Coroutine Run(IEnumerator enumerator);
    public void Stop(Coroutine coroutine);
}