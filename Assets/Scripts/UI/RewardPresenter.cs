using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        Time.timeScale = 1;
    }

    void SetButtonText(int buttonIndex, IAbility ability)
    {
        TextMeshProUGUI[] texts = rewardButtons[buttonIndex].GetComponentsInChildren<TextMeshProUGUI>();

        texts[0].text = ability.GetAbilityName();
        
        texts[1].text = ability.GetAbilityDescription();
    }

    void ActivateUI(bool isActive)
    {
        rewardCanvas.enabled = isActive;
    }

    void UpdateUI()
    {
        abilites = rewardManager.Return3RandomRewards();
        
        for(int i = 0; i < abilites.Count; i++)
        {
            SetButtonText(i, abilites[i]);
        }

        ActivateUI(true);
        Time.timeScale = 0;
    }
}
