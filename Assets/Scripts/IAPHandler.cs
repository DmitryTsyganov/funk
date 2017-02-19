using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPHandler : IStoreListener {

    private static readonly string[] _consumableProductIds = {"million_stars"};

    private IStoreController controller;
    private IExtensionProvider storeExtensionProvider;

    private static IAPHandler _instance;

    private IAPHandler()
    {
        Init();
    }

    public static IAPHandler GetInstance()
    {
        return _instance ?? (_instance = new IAPHandler());
    }

    public void BuyProduct(string ProductId)
    {
        if (controller == null || storeExtensionProvider == null)
        {
            Debug.Log("IAP OnInitialized has not been called yet");
            return;
        }

        var product = controller.products.WithID(ProductId);

        if (product != null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
        }
        else
        {
            Debug.Log("Can't purchase product " + ProductId);
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {

    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs eventArgs)
    {
        if (eventArgs.purchasedProduct.definition.id == _consumableProductIds[0])
        {
            Shop.AddStar(Shop.StarsUltimate);
            var starsCountText = GameObject.Find("StarCountText");
            if (starsCountText != null)
            {
                starsCountText.GetComponent<Text>().text = Shop.StarScore.ToString();
            }
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {

    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.storeExtensionProvider = extensions;
    }

    private void Init()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        foreach (var id in _consumableProductIds)
        {
            builder.AddProduct(id, ProductType.Consumable);
        }

        UnityPurchasing.Initialize(this, builder);
    }
}
