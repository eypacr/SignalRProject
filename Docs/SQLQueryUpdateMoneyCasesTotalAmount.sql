CREATE TRIGGER UpdateMoneyCaseTotalAmountV2
ON OrderDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Toplam fiyatý güncelle
    UPDATE MoneyCases
    SET TotalAmount = (
        SELECT SUM(od.TotalPrice)
        FROM OrderDetails od
        JOIN [Orders] o ON od.OrderId = o.OrderId
    )
    WHERE MoneyCaseId = MoneyCaseId;  -- Burada uygun MoneyCaseId deðerini girin (veya baþka bir þekilde baðlayýn)
END;
