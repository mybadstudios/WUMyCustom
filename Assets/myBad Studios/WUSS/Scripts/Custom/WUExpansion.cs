using UnityEngine;

namespace MBS
{
    public class WUExpansion : MonoBehaviour
    {
        enum WUExpActions { IsSubscribed }
        const string filepath = "wuss_expansion/unity_functions.php";
        const string ASSET = "CUSTOM";

        static public bool has_subsciption = false;
        static public System.Action OnSubscriptionTested;

        void Start() => WULogin.onLoggedIn += FetchSubscription;
        void FetchSubscription( CML ignore ) => WPServer.ContactServer( WUExpActions.IsSubscribed, filepath, ASSET, null, TestResponse, ( CMLData result ) => Debug.LogWarning( result.String( "message" ) ) ); //in 2018.1 change CMLData to CMLData

        void TestResponse( CML response )
        {
            has_subsciption = response [0].Bool( "subscribed" );
            OnSubscriptionTested?.Invoke();
        }
    }
}