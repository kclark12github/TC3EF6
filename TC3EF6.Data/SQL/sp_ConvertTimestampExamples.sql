Create Procedure sp_ConvertTimestampExamples As 
Begin
	Declare @iFormat int,@fmtDate varchar(24); Set @iFormat=0;
	While (@iFormat<150)
	Begin
		Begin Try
			Select @fmtDate=CONVERT(varchar(24),CURRENT_TIMESTAMP, @iFormat);
			Print CONVERT(varchar(3),@iFormat)+') '+@fmtDate;
		End Try
		Begin Catch
		End Catch
		Set @iFormat = @iFormat+1;
	End
End