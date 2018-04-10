using System;
using UnityEngine;
using UnityEngine.Purchasing;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener {

    public static Purchaser instance = null;

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    // add _gems to get productid
    public enum Products {
        gems_100 = 100,
        gems_225 = 225,
        gems_600 = 600,
        gems_1250 = 1250,
        gems_2600 = 2600,
        gems_5400 = 5400,
        gems_15000 = 15000
    };
    public static string gem = "_gems";

    #region Start&Init
    void Start() {
        instance = this;
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null) {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing() {
        // If we have already connected to Purchasing ...
        if (IsInitialized()) {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        foreach (int product in Enum.GetValues(typeof(Products))) {
            builder.AddProduct(product + gem, ProductType.Consumable);
        }


        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized() {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    #endregion

    #region Buy
    public void BuyProductID(string productId) {
        // If Purchasing has been initialized ...
        if (IsInitialized()) {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase) {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");

                //NotificationController.instance.addNotification("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                //NotificationController.instance.setAcceptDecline(false);
                //NotificationController.instance.showNotification();
            }
        }
        // Otherwise ...
        else {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");

            //NotificationController.instance.addNotification("BuyProductID FAIL. Not initialized.");
            //NotificationController.instance.setAcceptDecline(false);
            //NotificationController.instance.showNotification();
        }
    }
    #endregion

    #region Initializelistener
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error) {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);

        //NotificationController.instance.addNotification("OnInitializeFailed InitializationFailureReason:" + error);
        //NotificationController.instance.setAcceptDecline(false);
        //NotificationController.instance.showNotification();
    }
    #endregion

    #region Purchaselistener
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
        bool purchaseSuccess = false;
        foreach (int product in Enum.GetValues(typeof(Products))) {
            if (string.Equals(args.purchasedProduct.definition.id, product + gem, StringComparison.Ordinal)) {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                purchaseSuccess = true;
                Data.Gems += product;
                NotificationController.instance.addNotification(string.Format(LANGUAGE.MISC_GEM[LANGUAGE.CUR_LANG], product));
                NotificationController.instance.addNotification(LANGUAGE.P_THANKS[LANGUAGE.CUR_LANG]);
                NotificationController.instance.setAcceptDecline(false);
                NotificationController.instance.showNotification();
                return PurchaseProcessingResult.Complete;
            }
        }

        if (!purchaseSuccess) {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            //NotificationController.instance.addNotification(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            //NotificationController.instance.setAcceptDecline(false);
            //NotificationController.instance.showNotification();
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        //NotificationController.instance.addNotification(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        //NotificationController.instance.setAcceptDecline(false);
        //NotificationController.instance.showNotification();
    }
    #endregion
}
