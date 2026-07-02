using UnityEngine;

public class CastRay : MonoBehaviour
{
    public float range = 15;

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

        if(Physics.Raycast(ray, out RaycastHit raycastHit, range)){
            GameObject hitObject = raycastHit.collider.gameObject;
            if(hitObject.tag == "UpgradeRoomButton")
            {
                hitObject.GetComponent<OnUpgradeRoomButtonClicked>().onClick();
            }else if(hitObject.tag == "Upgrade")
            {
                hitObject.GetComponent<UpgradeManager>().onClick();
            }
        }
    }
}
