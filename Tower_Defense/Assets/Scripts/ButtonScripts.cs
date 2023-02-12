using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField] Button button1; //For building archer tower/upgrade strenght
    [SerializeField] Button button2; //For building AOE tower/upgrade range
    [SerializeField] Button button3; //For building ice tower/sell

    [SerializeField] TMP_Text towerType;
    [SerializeField] TMP_Text towerStrengt;
    [SerializeField] TMP_Text towerAtackSpeed;

    [SerializeField] TowerStats archerTowerStats;
    [SerializeField] TowerStats AOETowerStats;
    [SerializeField] TowerStats iceTowerStats;

    bool hasBuilding = false;
    GameObject buildingCopy;
    private void OnEnable()
    {
        Observer.onEnemyDeathEvent.AddListener(DEButtons);
    }

    void DEButtons()
    {
        if(!hasBuilding)
        {
            if(Player.Instance.Coins.coinsAmmount < archerTowerStats.buildingCost)
            {
                button1.enabled = false;
            }
            else
            {
                button1.enabled = true;
            }

            if (Player.Instance.Coins.coinsAmmount < AOETowerStats.buildingCost)
            {
                button2.enabled = false;
            }
            else
            {
                button2.enabled = true;
            }

            if (Player.Instance.Coins.coinsAmmount < AOETowerStats.buildingCost)
            {
                button3.enabled = false;
            }
            else
            {
                button3.enabled = true;
            }
        }
        else
        {
            if(buildingCopy.GetComponentInChildren<Tower>().upgradeCostDamage > Player.Instance.Coins.coinsAmmount)
            {
                button1.enabled = false;
            }
            else
            {
                button1.enabled = true;
            }

            if (buildingCopy.GetComponentInChildren<Tower>().upgradeCostSpeed > Player.Instance.Coins.coinsAmmount)
            {
                button2.enabled = false;
            }
            else
            {
                button2.enabled = true;
            }
            button2.enabled = true;
        }
    }

    public void UpdateButtons(Ground ground)
    {
        if (ground.building == null)
        {
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button3.onClick.RemoveAllListeners();

            button1.onClick.AddListener(delegate { BuildArcherTower(ref ground); });
            button2.onClick.AddListener(delegate { BuildAOETower(ref ground); });
            button3.onClick.AddListener(delegate { BuildIceTower(ref ground); });

            button1.GetComponentInChildren<TMP_Text>().text = "Archer tower: " + archerTowerStats.buildingCost.ToString();
            button2.GetComponentInChildren<TMP_Text>().text = "AOE tower: " + AOETowerStats.buildingCost.ToString();
            button3.GetComponentInChildren<TMP_Text>().text = "Ice tower: " + iceTowerStats.buildingCost.ToString();
            towerType.text = "Tower: Null";
            towerStrengt.text = "Strenght: Null";
            towerAtackSpeed.text = "Attack speed: Null";

            hasBuilding = false;
            //building = copy;
        }
        if (ground.building != null)
        {
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button3.onClick.RemoveAllListeners();

            button1.onClick.AddListener(delegate { UpgradeStrenght(ref ground); });
            button2.onClick.AddListener(delegate { UpgradeAS(ref ground); });
            button3.onClick.AddListener(delegate { Sell(ref ground); });

            button1.GetComponentInChildren<TMP_Text>().text = "Upgrade Strenght: " + ground.building.GetComponentInChildren<Tower>().upgradeCostDamage.ToString();
            button2.GetComponentInChildren<TMP_Text>().text = "Upgrade AttackSpeed: " + ground.building.GetComponentInChildren<Tower>().upgradeCostSpeed.ToString();
            button3.GetComponentInChildren<TMP_Text>().text = "Sell Tower: " + ground.building.GetComponentInChildren<Tower>().sellValue.ToString();

            towerType.text = "Tower: " + ground.building.GetComponentInChildren<Tower>().stats.towerType;
            towerStrengt.text = "Strenght: " + ground.building.GetComponentInChildren<Tower>().damage.ToString();
            towerAtackSpeed.text = "Attack speed: " + ground.building.GetComponentInChildren<Tower>().attackSpeed.ToString();
            //Debug.Log(ground.building.GetComponentInChildren<Tower>().damage.ToString());

            hasBuilding = true;
            buildingCopy = ground.building;
        }
    }

    private UnityAction BuildArcherTower(ref Ground ground)
    {
        ground.building = Instantiate(Resources.Load("Prefabs/Archer Tower") as GameObject, ground.parentTransform.transform);
        UpdateButtons(ground);
        return null;
    }
    private UnityAction BuildAOETower(ref Ground ground)
    {
        ground.building = Instantiate(Resources.Load("Prefabs/Archer Tower") as GameObject, ground.parentTransform.transform);
        UpdateButtons(ground);
        return null;
    }

    private UnityAction BuildIceTower(ref Ground ground)
    {
        ground.building = Instantiate(Resources.Load("Prefabs/Archer Tower") as GameObject, ground.parentTransform.transform);
        UpdateButtons(ground);
        return null;
    }

    private UnityAction UpgradeStrenght(ref Ground ground)
    {
        if(ground.building.TryGetComponent(out IPlaceable placeable))
        {
            placeable.UpgradeDamage();
        }
        return null;
    }

    private UnityAction UpgradeAS(ref Ground ground)
    {
        if (ground.building.TryGetComponent(out IPlaceable placeable))
        {
            placeable.UpgradeAS();
        }
        return null;
    }
    private UnityAction Sell(ref Ground ground)
    {
        if (ground.building.TryGetComponent(out IPlaceable placeable))
        {
            placeable.Sell();
        }
        return null;
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
