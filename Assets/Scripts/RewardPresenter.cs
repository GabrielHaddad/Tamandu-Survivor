using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPresenter : MonoBehaviour
{
    [SerializeField] RewardManager rewardManager;
    [SerializeField] List<Button> rewardButtons;
    Canvas rewardCanvas;

    List<IAbility> abilites = new List<IAbility>();
    PlayerLevel player;

    void Awake() 
    {
        player = FindObjectOfType<PlayerLevel>();
        rewardCanvas = GetComponent<Canvas>();
    }

    void OnEnable() 
    {
        player.onLevelUpAction += UpdateUI;
    }

    void OnDisable() 
    {
        player.onLevelUpAction -= UpdateUI;
    }

    void Start()
    {
        AddButtonListeners();
        ActivateUI(false);
    }

    void AddButtonListeners()
    {
        rewardButtons[0].onClick.AddListener(() => ActivateButton(0));
        rewardButtons[1].onClick.AddListener(() => ActivateButton(1));
        rewardButtons[2].onClick.AddListener(() => ActivateButton(2));
    }

    void ActivateButton(int index)
    {
        rewardManager.ActivateAbility(abilites[index]);
        ActivateUI(false);
    }

    void ActivateUI(bool isActive)
    {
        rewardCanvas.enabled = isActive;
    }

    void UpdateUI()
    {
        abilites = rewardManager.Return3RandomRewards();
        ActivateUI(true);
    }
}
