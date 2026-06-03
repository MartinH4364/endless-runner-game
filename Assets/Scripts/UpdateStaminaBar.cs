using UnityEngine;

public class UpdateStaminaBar : MonoBehaviour
{
    public float maxWidth = 790;
    public float staminaPercent = 100;
    RectTransform rectTransform;
    RectTransform backgrondTransform;

    public GameObject Player;
    public GameObject backgroundBar;

    void Start()
    {
        rectTransform = GetComponentInParent<RectTransform>();
        backgrondTransform = backgroundBar.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        staminaPercent = Player.GetComponent<PlayerMovement>().stamina;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxWidth * staminaPercent / 100);
        if(backgrondTransform.rect.width > rectTransform.rect.width){
            backgrondTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, backgrondTransform.rect.width + (rectTransform.rect.width - backgrondTransform.rect.width) * 0.03f);
        }
        else
        {
            backgrondTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.rect.width);
        }
    }
}
