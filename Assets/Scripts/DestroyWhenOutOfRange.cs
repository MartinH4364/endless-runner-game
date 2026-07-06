using UnityEngine;

public class DestroyWhenOutOfRange : MonoBehaviour
{
    GameObject deathEmpty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathEmpty = GameObject.Find("DeathEmpty");
    }

    // Update is called once per frame
    void Update()
    {
        if(deathEmpty.transform.position.z >= transform.position.z)
        {
            Destroy(gameObject);
        }        
    }
}
