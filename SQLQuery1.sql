-- Opret månedsplanen, hvis den ikke allerede findes
IF NOT EXISTS (
    SELECT 1 FROM dbo.Maanedsplan
    WHERE Aar = 2026 AND Maaned = 10
)
BEGIN
    INSERT INTO dbo.Maanedsplan (Aar, Maaned)
    VALUES (2026, 10);
END;

DECLARE @PlanId INT;

SELECT @PlanId = Id
FROM dbo.Maanedsplan
WHERE Aar = 2026 AND Maaned = 10;

DECLARE @Dato DATE = '20261001';

WHILE @Dato < '20261101'
BEGIN
    -- Opret dagens manglende vagter
    INSERT INTO dbo.Vagt
        (MaanedsplanId, Dato, StartTid, SlutTid)
    SELECT @PlanId, @Dato, t.StartTid, t.SlutTid
    FROM (
        VALUES
            (CAST('09:00' AS TIME(0)), CAST('14:00' AS TIME(0))),
            (CAST('14:00' AS TIME(0)), CAST('19:00' AS TIME(0)))
    ) AS t(StartTid, SlutTid)
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.Vagt AS v
        WHERE v.Dato = @Dato
          AND v.StartTid = t.StartTid
    );

    SET @Dato = DATEADD(DAY, 1, @Dato);
END;