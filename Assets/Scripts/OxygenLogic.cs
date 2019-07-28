using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenLogic : MonoBehaviour
{
    [SerializeField]
    private float maxAmount = 100f;
    [SerializeField]
    private float drainRate = 10f;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    public OxygenTankLevel tankLevel = OxygenTankLevel.One;
    private bool drain = true;
    private bool refill = false;
    public int upgradeCost = 30;

    public enum OxygenTankLevel
    {
        One,
        Two,
        Three,
        Max
    };


    public Image oxygenBar;
    public GameObject gameOver;
    public GameObject bar;
    public GameObject cannister;
    float cannister1 = 1f;
    float barScale = 1f;
    public GameObject resourceText;
    

    private void Awake()
    {
        //sets cannister to current x size
        cannister1 = cannister.transform.localScale.x;

    }


    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        currentAmount = maxAmount;

    }

    // Update is called once per frame
    void Update()
    {
        if (drain)
        {
            if (currentAmount >= 0)
            {
                currentAmount -= drainRate * Time.deltaTime;
                oxygenBar.fillAmount = currentAmount / maxAmount;
            }
            else
            {
                death();
                
            }
        }
        else if (refill)
        {
            if (currentAmount < maxAmount)
            {
                currentAmount += (drainRate + 50) * Time.deltaTime;
                oxygenBar.fillAmount = currentAmount / maxAmount;
            }
            else
            {
                refill = false;
            }
        }

        switch (tankLevel)
        {
            case OxygenTankLevel.One:
                upgradeCost = 30;
                break;
            case OxygenTankLevel.Two:
                upgradeCost = 30;
                break;
            case OxygenTankLevel.Three:
                upgradeCost = 30;
                break;
        }
    }

    public void UpgradeTank(float tankCapacity)
    {
        maxAmount += tankCapacity;
        currentAmount = maxAmount;
        tankLevel++;
        //Modifies the bar size on upgrade
        barScale = barScale + 0.25f;
        bar.transform.localScale = new Vector2(barScale, 1f);
        cannister1 = cannister1 + 0.75f;
        cannister.transform.localScale = new Vector2(cannister1, 3.012838f);
        cannister.transform.Translate(new Vector3(1.5f, 0, 0));
        
     }

    public void PauseDrain()
    {
        drain = false;
        if(currentAmount < maxAmount)
        {
            refill = true;
        }
    }

    public void ResumeDrain()
    {
        drain = true;
    }

    public void RestartLevel()
    {
        gameOver.SetActive(false);
        maxAmount = 100f;
        currentAmount = maxAmount;
        tankLevel = OxygenTankLevel.One;
        this.gameObject.GetComponent<ResourceManager>().currentResource = 0;
        this.gameObject.GetComponent<ResourceManager>().SpawnResource();
    }

    private void death()
    {
        GetComponent<Animator>().SetTrigger("death");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        resourceText.SetActive(false);
        StartCoroutine("waitToTurnOn", 2f);
               
    }

    public void decreaseOxygen(float amount)
    {
        currentAmount -= amount;
    }

    IEnumerator waitToTurnOn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameOver.SetActive(true);
        
    }
}
