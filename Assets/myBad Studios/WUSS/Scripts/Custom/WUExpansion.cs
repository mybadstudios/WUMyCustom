using UnityEngine;

namespace MBS
{
    public class WUExpansion : MonoBehaviour
    {
        enum WUExpActions { IsSubscribed, GetCustomerPurchaseHistory }
        const string filepath = "wub_mycustom/unity_functions.php";
        const string ASSET = "CUSTOM";

        static public bool has_subsciption = false;
        static public System.Action OnSubscriptionTested;

        void Start() => WULogin.OnLoggedIn += FetchSubscription;
        void FetchSubscription(CML ignore) => WPServer.ContactServer(WUExpActions.IsSubscribed, filepath, ASSET, null, TestResponse, (CMLData result) => Debug.LogWarning(result.String("message"))); //in 2018.1 change CMLData to CMLData

        static public void GetCustomerPurchaseHistory(System.Action<CML> OnSuccess = null, System.Action<CMLData> OnFail = null) => WPServer.ContactServer(WUExpActions.GetCustomerPurchaseHistory, filepath, ASSET, null, OnSuccess, OnFail);

        void TestResponse( CML response )
        {
            has_subsciption = response [0].Bool( "subscribed" );
            OnSubscriptionTested?.Invoke();
        }
    }
}