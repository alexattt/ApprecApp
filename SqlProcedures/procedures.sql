USE [AppRecDB]
GO
/****** Object:  StoredProcedure [dbo].[GetFailedApprecPeriodsGlobal]    Script Date: 2/25/2024 3:09:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetFailedApprecPeriodsGlobal]
AS   
    SET NOCOUNT ON;  
	select min(GenDate) as PeriodStart, max(GenDate) as PeriodEnd, Status, count(*) as ApprecsFailed
	from (select *,
					row_number() over (partition by MsgType order by GenDate) as seqnum,
					row_number() over (partition by MsgType, Status order by GenDate) as seqnum_uc
			from 
			(
				SELECT GenDate, MessageTypes.V as MsgType,
						case Statuses.Status_V
							when 1 then 'Success'
							when 2 then 'Failed'
							when 3 then 'Failed'
						end as Status
					FROM dbo.AppRecs
						JOIN dbo.MessageTypes ON dbo.AppRecs.MsgTypeId = dbo.MessageTypes.Id
						JOIN dbo.Statuses ON dbo.AppRecs.StatusId = dbo.Statuses.Id
						ORDER BY GenDate OFFSET 0 ROWS
			) b
			) t
	WHERE Status='Failed'
	group by MsgType, Status, (seqnum - seqnum_uc)
	HAVING COUNT(*) > 1


USE [AppRecDB]
GO
/****** Object:  StoredProcedure [dbo].[GetFailedApprecPeriodsReceiver]    Script Date: 2/25/2024 3:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetFailedApprecPeriodsReceiver]
	@ReceiverIdentifier varchar(MAX)  
AS   
    SET NOCOUNT ON;  
	select min(GenDate) as PeriodStart, max(GenDate) as PeriodEnd, Status, count(*) as ApprecsFailed
	from (select *,
					row_number() over (partition by MsgType order by GenDate) as seqnum,
					row_number() over (partition by MsgType, Status order by GenDate) as seqnum_uc
			from 
			(
				SELECT GenDate, MessageTypes.V as MsgType, dbo.Receivers.ReceiverId, dbo.Receivers.ReceiverName, 
						case Statuses.Status_V
							when 1 then 'Success'
							when 2 then 'Failed'
							when 3 then 'Failed'
						end as Status
					FROM dbo.AppRecs
						JOIN dbo.Receivers ON dbo.AppRecs.ReceiverID = dbo.Receivers.Id
						JOIN dbo.MessageTypes ON dbo.AppRecs.MsgTypeId = dbo.MessageTypes.Id
						JOIN dbo.Statuses ON dbo.AppRecs.StatusId = dbo.Statuses.Id
						WHERE (dbo.Receivers.ReceiverId = @ReceiverIdentifier OR dbo.Receivers.ReceiverName = @ReceiverIdentifier)
						ORDER BY GenDate OFFSET 0 ROWS
			) b
			) t
	WHERE Status='Failed'
	group by MsgType, Status, (seqnum - seqnum_uc)
	HAVING COUNT(*) > 1


USE [AppRecDB]
GO
/****** Object:  StoredProcedure [dbo].[GetFailedApprecPeriodsSender]    Script Date: 2/25/2024 3:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetFailedApprecPeriodsSender]
	@SenderIdentifier varchar(MAX)  
AS   

    SET NOCOUNT ON;  
	select min(GenDate) as PeriodStart, max(GenDate) as PeriodEnd, Status, count(*) as ApprecsFailed
	from (select *,
					row_number() over (partition by MsgType order by GenDate) as seqnum,
					row_number() over (partition by MsgType, Status order by GenDate) as seqnum_uc
			from 
			(
				SELECT GenDate, MessageTypes.V as MsgType, dbo.Senders.SenderId, dbo.Senders.SenderName, 
						case Statuses.Status_V
							when 1 then 'Success'
							when 2 then 'Failed'
							when 3 then 'Failed'
						end as Status
					FROM dbo.AppRecs
						JOIN dbo.Senders ON dbo.AppRecs.SenderID = dbo.Senders.Id
						JOIN dbo.MessageTypes ON dbo.AppRecs.MsgTypeId = dbo.MessageTypes.Id
						JOIN dbo.Statuses ON dbo.AppRecs.StatusId = dbo.Statuses.Id
						WHERE (dbo.Senders.SenderId = @SenderIdentifier OR dbo.Senders.SenderName = @SenderIdentifier)
						ORDER BY GenDate OFFSET 0 ROWS
			) b
			) t
	WHERE Status='Failed'
	group by MsgType, Status, (seqnum - seqnum_uc)
	HAVING COUNT(*) > 1

