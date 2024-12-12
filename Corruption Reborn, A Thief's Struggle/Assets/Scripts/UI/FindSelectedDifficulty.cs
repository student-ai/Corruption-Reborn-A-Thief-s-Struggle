using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSelectionChecker : MonoBehaviour
{
    // Reference to the Dropdown component
    // If using TMP, use TMP_Dropdown
    [SerializeField] 
    private TMP_Dropdown dropdown; 

    public int difficulty = 0;
    void Start()
    {
        // Ensure the dropdown is assigned
        if (dropdown == null)
        {
            Debug.LogError("Dropdown not assigned!");
            return;
        }

        // Subscribe to the dropdown's value change event
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Called whenever the dropdown value is changed
    private void OnDropdownValueChanged(int selectedIndex)
    {
        // Get the selected option's text
        string selectedText = dropdown.options[selectedIndex].text;

        // Log the selected option
        Debug.Log($"Selected Index: {selectedIndex}, Selected Text: {selectedText}");

        if (selectedIndex == 0)
        {
            difficulty = 0;
        }
        else if (selectedIndex == 1)
        {
            difficulty = 1;
        }
        else if (selectedIndex == 2)
        {
            difficulty = 2;
        }    

    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (dropdown != null)
            dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
    }
}
