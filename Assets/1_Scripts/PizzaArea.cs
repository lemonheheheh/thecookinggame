using UnityEngine;
using System.Collections.Generic;

public class PizzaArea : MonoBehaviour
{
    [Header("Ingredient Names")]
    public List<string> requiredIngredients; // e.g. "Olive", "Mushroom", "Cheese"

    [Header("Ingredient Layers")]
    public List<GameObject> ingredientLayers; // assign objects like OliveLayer, MushroomLayer
    private HashSet<string> placedIngredients = new HashSet<string>();
    private Dictionary<string, GameObject> layerMap = new Dictionary<string, GameObject>();

    void Start()
    {
        // Map ingredient names to layers
        for (int i = 0; i < requiredIngredients.Count; i++)
        {
            string ingName = requiredIngredients[i];
            if (i < ingredientLayers.Count && ingredientLayers[i] != null)
            {
                GameObject layer = ingredientLayers[i];
                layer.SetActive(false); // hide at start
                layerMap[ingName] = layer;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ingredient")) return;

        string ingName = other.gameObject.name;

        if (!requiredIngredients.Contains(ingName) || placedIngredients.Contains(ingName)) return;
        placedIngredients.Add(ingName);

        // Activate corresponding pizza layer
        if (layerMap.ContainsKey(ingName))
            layerMap[ingName].SetActive(true);
        else
            Debug.LogWarning("No layer found for ingredient: " + ingName);

        Destroy(other.gameObject); // remove ingredient
        CheckIfComplete();
    }

    private void CheckIfComplete()
    {
        if (placedIngredients.Count == requiredIngredients.Count) Debug.Log("🍕 Pizza is ready! WELL DONE!");
    }
}
