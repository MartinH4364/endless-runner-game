using UnityEngine;
using UnityEngine.VFX;

public class RemoveObstacleManager : MonoBehaviour
{
    public float chargeTime = 8;
    float charge = 0;

    UnityEngine.UI.Image chargeMeter;
    
    public bool onRight = true;

    public GameObject removeObstacleEffect;
    VisualEffect removeObstacleGraph;

    public float radius = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargeMeter = GetComponent<UnityEngine.UI.Image>();

        charge = chargeTime;
        if (onRight)
        {
            chargeMeter.fillClockwise = false;
        }

        removeObstacleGraph = removeObstacleEffect.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charge < chargeTime)
        {
            charge += Time.deltaTime;
        }
        else
        {
            charge = chargeTime;
        }

        if ((Input.GetKey(KeyCode.Q) && !onRight || Input.GetKey(KeyCode.E) && onRight)&& charge == chargeTime)
        {
            removeObstacleGraph.SetFloat("Radius", radius);
            removeObstacleGraph.Play();

            foreach(Collider collider in Physics.OverlapSphere(removeObstacleEffect.transform.position, radius))
            {
                if(collider.gameObject.name == "Collider" && collider.gameObject.GetComponentInParent<MakeTransparent>() != null)
                {
                    MakeTransparent script = collider.gameObject.GetComponentInParent<MakeTransparent>();
                    script.StartCoroutine(script.makeTransparent());
                }
            }
            charge = 0;
        }

        chargeMeter.fillAmount = charge/chargeTime/2;
    }
}
