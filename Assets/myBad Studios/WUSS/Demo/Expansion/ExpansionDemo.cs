using UnityEngine;
using MBS;

public class ExpansionDemo : MonoBehaviour {
    void Start()
    {
        WULogin.OnLoggedIn += GetPurchaseHistory;
        WUExpansion.OnSubscriptionTested += DisplayVerdict;
    }
    void DisplayVerdict() => Debug.Log($"User {WULogin.Username} does{ (WUExpansion.has_subsciption ? "" : " NOT") } have a subsciption" );
    void GetPurchaseHistory(CML _) => WUExpansion.GetCustomerPurchaseHistory(OnReceivedPurchaseHistory, OnNoProductsPurchased);
    void OnReceivedPurchaseHistory(CML data)
    {
        foreach (var item in data.Elements)
            Debug.LogWarning($"Product ID:{item.Int("Product")} - {item.String("Name")}");
    }

    void OnNoProductsPurchased(CMLData error) => Debug.Log($"No products have been purchaed yet.\n{error.String("message")}");    
}
