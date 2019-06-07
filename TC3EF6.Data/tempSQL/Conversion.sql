INSERT INTO [dbo].[Music](
	[Artist],[AlphaSort],[MediaFormat],[Title],[Type],[Year],[Cataloged],[DateInventoried],[DatePurchased],[DateVerified],
	[LocationID],[Notes],[Price],[Value],[WishList],[DateCreated],[DateModified],[OID])
Select 
	[Artist],[AlphaSort],[Media] As [MediaFormat],[Title],[Type],[Year],1,[DateInventoried],[DatePurchased],[DateVerified],
	[Locations].[ID],[Notes],[Price],[Value],[WishList],[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
	Inner Join [Locations] On [Locations].[OName]=[tcMusic].[Location]
Order By [AlphaSort];


INSERT INTO [dbo].[Images](
	[Name],[Image],[FileName],[URL],[Height],[Width],[Category],[AlphaSort],[TableName],[RecordID],
	[Thumbnail],[ThumbnailImage],[Caption],[Notes],[DateCreated],[DateModified],[OID])
Select
	SUBSTRING([tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Cover',1,80) As [Name],
	[Image],null,null,0,0,null,[tcMusic].[AlphaSort],'Music',[Music].[ID],
	0,null,[tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Cover' As [Caption],
	null,[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
	Inner Join [Music] On [Music].[OID]=[tcMusic].[ID]
Where [Image] is not null
--Union
--Select
--	[tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Back' As [Name],
--	[OtherImage],null,null,0,0,null,[AlphaSort],'Music',[Music].[ID],
--	0,null,[tcMusic].[Artist]+' - '+[tcMusic].[Title]+' Back' As [Caption],
--	null,[tcMusic].[DateCreated],[tcMusic].[DateModified],[tcMusic].[ID]
--From [GGGSCP1].[TreasureChest].[dbo].[Music] [tcMusic]
--	Inner Join [Music] On [Music].[OID]=[tcMusic].[ID]
Order By [tcMusic].[AlphaSort];



Select * From Music;
Delete From Music;
Select * From Images;
Delete From Images;
