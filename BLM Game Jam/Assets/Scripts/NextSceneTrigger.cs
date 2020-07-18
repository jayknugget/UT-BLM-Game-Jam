using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextSceneTrigger : MonoBehaviour
{
    
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    [SerializeField]
    public StringEvent nextSceneMethod;
    public string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        nextSceneMethod.Invoke(nextSceneName);

    }
}
