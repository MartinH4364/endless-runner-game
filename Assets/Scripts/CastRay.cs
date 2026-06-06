using UnityEngine;

public class CastRay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            castRay();
        }
    }

    void castRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 10)){
            GameObject hitObject = raycastHit.collider.gameObject;
            if(hitObject.tag == "UpgradeRoomButton")
            {
                hitObject.GetComponent<OnUpgradeRoomButtonClicked>().onClick();
            }        
        }
    }
}
