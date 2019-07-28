using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPanel : MonoBehaviour
{
    [SerializeField]
    private string objectName;
    public GameObject panel;
    public GameObject fullyUpgradedPanel;
    public Text costValueText;
    private OxygenLogic oxygenLogic;

    private void Start()
    {
        oxygenLogic = GetComponent<OxygenLogic>();
    }
    private void Update()
    {
        costValueText.text = oxygenLogic.upgradeCost.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == objectName)
        {
            if(GetComponent<OxygenLogic>().tankLevel != OxygenLogic.OxygenTankLevel.Max)
            {
                panel.SetActive(true);
            }
            else
            {
                fullyUpgradedPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(fullyUpgradedPanel.activeSelf == true)
        {
            fullyUpgradedPanel.SetActive(false);
        }

        if(panel.activeSelf == true)
        {
            panel.SetActive(false);
        }


    }


}
