using System;
using System.Data;
using TP;
using TP.Entitiy;

public class SaleController
{
    private ProductInfoEntity productInfoEntity;

    public SaleController()
    {
        // Initialize the ProductInfoEntity
        productInfoEntity = new ProductInfoEntity();
    }
    private bool productCordSucces = false; //제품 코드 성공여부
    public bool checkProductCord(string cord)
    {
        if (productInfoEntity.IsProductCordExists(cord))
        {
            productCordSucces = true;
        }
        else
        {
            productCordSucces = false;
        }
        return productCordSucces;
    }

}
