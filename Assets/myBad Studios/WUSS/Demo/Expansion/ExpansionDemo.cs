using UnityEngine;
using MBS;

public class ExpansionDemo : MonoBehaviour {
    void Start() => WUExpansion.OnSubscriptionTested += DisplayVerdict;

    void DisplayVerdict() => Debug.Log($"User {WULogin.username} does{ (WUExpansion.has_subsciption ? "" : " NOT") } have a subsciption" );
}
