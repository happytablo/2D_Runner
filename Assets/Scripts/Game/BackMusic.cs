using UnityEngine;

public class BackMusic : MonoBehaviour
{
    private void Awake()
    {
        SetUpSinglton();
    }

    private void SetUpSinglton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
