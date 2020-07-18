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
    public string allowedPlayerTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == allowedPlayerTag){
            nextSceneMethod.Invoke(nextSceneName);
            collision.gameObject.SetActive(false);
        }
        
    }
}
