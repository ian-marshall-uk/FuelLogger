SELECT VehicleId,
       Date,
       OdometerReading,
	   Litres,
	   PricePerLitre,
	   CASE WHEN Mileage IS NULL THEN (OdometerReading - (SELECT InitialOdometerReading FROM Vehicle WHERE Id = VehicleId)) ELSE Mileage END AS MileageDelta,
	   (CASE WHEN Mileage IS NULL THEN (OdometerReading - (SELECT InitialOdometerReading FROM Vehicle WHERE Id = VehicleId)) ELSE Mileage END / (Litres / 4.54)) AS MPG
FROM (
	SELECT VehicleId,
	       Date,
		   OdometerReading,
		   Litres,
		   PricePerLitre,
		   OdometerReading - (SELECT TOP 1 OdometerReading FROM FillUp F3 WHERE F3.Date < F1.Date ORDER BY F3.Date DESC) AS Mileage
	FROM FillUp F1
	WHERE VehicleId = 1) A
ORDER BY A.Date 