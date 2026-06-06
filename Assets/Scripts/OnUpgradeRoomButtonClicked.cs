using UnityEngine;

public class OnUpgradeRoomButtonClicked : MonoBehaviour
{
    public GameObject blockerWall;
    public Material dullMaterial;
    bool clicked = false;

    public void onClick()
    {
        if(!clicked){
            GenerateRooms.inUpgradeRoom = false;
            blockerWall.GetComponent<LiftWall>().publicLiftWall();
            gameObject.GetComponent<Renderer>().material = dullMaterial;
            clicked = true;
        }
    }
}
