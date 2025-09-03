using UnityEngine;
using System.Collections.Generic;

public class PizzaArea : MonoBehaviour
{
    public List<string> requiredIngredients;   
    private HashSet<string> placedIngredients = new HashSet<string>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            string ingName = other.gameObject.name;
            if (requiredIngredients.Contains(ingName))
            {
                placedIngredients.Add(ingName);
                Debug.Log(ingName + " placed on pizza!");
                CheckIfComplete();
            }
        }
    }

    void CheckIfComplete()
    {
        if (placedIngredients.Count == requiredIngredients.Count)
        {
            Debug.Log("pizza is ready!");
        }
    }
}


