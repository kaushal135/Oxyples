using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int currentResource = 0;
    public Transform[] spawnloations;
    public GameObject[] resourcePrefabs;
    public Text resourceText;
    private OxygenLogic oxygenLogic;
    public Button upgradeButton;
    private AudioSource audioSource;
    public AudioClip upgradeSound;

    private void Awake()
    {
        SpawnResource();
        upgradeButton.interactable = false;
        oxygenLogic = GetComponent<OxygenLogic>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        resourceText.text = currentResource.ToString();
        if (currentResource >= oxygenLogic.upgradeCost)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }
    }

    public void AddResource(int amount)
    {
        currentResource += amount;
    }
    
    public void SpendResource(float Capacity)
    {
        int amount = oxygenLogic.upgradeCost;
        if(currentResource >= amount)
        {
            currentResource -= amount;
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(upgradeSound);
            oxygenLogic.UpgradeTank(Capacity);
            audioSource.volume = 1.0f;
        }
        
    }

    public void SpawnResource()
    {
        foreach (Transform t in spawnloations)
        {
            int random = Random.Range(0, resourcePrefabs.Length);
            GameObject resource = resourcePrefabs[random];
            Instantiate(resource, t);
        }
    }
}
