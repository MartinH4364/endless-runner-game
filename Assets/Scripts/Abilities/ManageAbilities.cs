using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageAbilities : MonoBehaviour
{
    public TextMeshProUGUI leftAbilityText;
    public TextMeshProUGUI rightAbilityText;

    public List<GameObject> abilities;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject leftAbility = Instantiate(abilities[Random.Range(0,abilities.Count)]);
        leftAbility.transform.parent = gameObject.transform.parent.transform;
        leftAbility.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        leftAbility.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        leftAbility.name = leftAbility.name.Replace("(Clone)","");
        leftAbilityText.text = leftAbility.name;

        GameObject rightAbility = Instantiate(abilities[Random.Range(0,abilities.Count)]);
        rightAbility.transform.parent = gameObject.transform.parent.transform;
        rightAbility.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        rightAbility.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        rightAbility.name = rightAbility.name.Replace("(Clone)","");
        rightAbility.GetComponent<UnityEngine.UI.Image>().fillClockwise = false;
        rightAbilityText.text = rightAbility.name;
    }
}
