CREATE TRIGGER UpdateMoneyCaseTotalAmountV2
ON OrderDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Toplam fiyat� g�ncelle
    UPDATE MoneyCases
    SET TotalAmount = (
        SELECT SUM(od.TotalPrice)
        FROM OrderDetails od
        JOIN [Orders] o ON od.OrderId = o.OrderId
    )
    WHERE MoneyCaseId = MoneyCaseId;  -- Burada uygun MoneyCaseId de�erini girin (veya ba�ka bir �ekilde ba�lay�n)
END;
