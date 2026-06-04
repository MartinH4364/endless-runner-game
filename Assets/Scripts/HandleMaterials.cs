using System.Collections;
using UnityEngine;

public class HandleMaterials : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    float xTiling = 1;
    float yTiling = 1;
    public float tileSize = 4;
    Material material;
    float shrinkTime = 5;
    GameObject deathEmpty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        updateTiling();
        deathEmpty = GameObject.Find("DeathEmpty");
    }

    // Update is called once per frame
    void Update()
    {
        if(deathEmpty.transform.position.z >= transform.position.z)
        {
            StartCoroutine(destroyObject());
        }
    }

    void updateTiling()
    {
        if (x)
        {
            xTiling = transform.lossyScale.x/tileSize;
            if (y)
            {
                yTiling = transform.lossyScale.y/tileSize;
            }
            else
            {
                yTiling = transform.lossyScale.z/tileSize;
            }
        }
        else
        {
            xTiling = transform.lossyScale.y/tileSize;
            yTiling = transform.lossyScale.z/tileSize;
        }
        material.mainTextureScale = new Vector2(xTiling,yTiling);
    }

    public IEnumerator destroyObject()
    {
        float originalX = transform.localScale.x;
        float originalY = transform.localScale.y;
        float originalZ = transform.localScale.z;
        material.shader = Shader.Find("Universal Render Pipeline/Unlit");
        material.SetColor("_BaseColor", Color.red);
        material.SetTexture("_BaseMap", null);
        float timeUntilDestruction = shrinkTime;
        while(timeUntilDestruction >= 0)
        {
            transform.localScale = new Vector3(originalX/shrinkTime*timeUntilDestruction, originalY/shrinkTime*timeUntilDestruction, originalZ/shrinkTime*timeUntilDestruction);
            timeUntilDestruction -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
