USE [CRISKAshutoshTest]
GO

/****** Object:  StoredProcedure [dbo].[SP_ExposureForecast]    Script Date: 23-05-2023 02:19:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SP_ExposureForecast] 
(
	@startDate Datetime ='2023-01-01 00:00:00', 
	@endDate Datetime
)
As
Begin

select 
	ID,
	Counterparty,
	Businessdate,
	Exposure 
from ExposureForecast where Businessdate >= @startDate and Businessdate <= @endDate


end
GO


