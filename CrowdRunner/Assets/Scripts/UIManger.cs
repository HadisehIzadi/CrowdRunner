using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManger : MonoBehaviour
{
	[Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text levelText;
    
    
    // Start is called before the first frame update
    void Start()
    {
    	progressBar.value = 0f;
    	gamePanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);
        
    }

    // Update is called once per frame
    void Update()
    {
    	UpdateProgressBar();
    }
    
    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    
    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
            return;

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }
}