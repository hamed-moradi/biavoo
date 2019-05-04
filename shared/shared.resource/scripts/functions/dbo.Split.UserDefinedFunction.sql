USE [biavoo]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 5/2/2019 7:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Split](@String varchar(8000), @Delimiter char(1),@RowCounter int)       
returns @temptable TABLE (RowCounter int,items varchar(8000))       
as       
begin       
    declare @idx int       
    declare @slice varchar(8000)       

    select @idx = 1       
        if len(@String)<1 or @String is null  return       

    while @idx!= 0       
    begin       
        set @idx = charindex(@Delimiter,@String)       
        if @idx!=0       
            set @slice = left(@String,@idx - 1)       
        else       
            set @slice = @String       

        if(len(@slice)>0)
        begin  
            insert into @temptable(RowCounter,Items) values(@RowCounter,@slice)       
            set @RowCounter=@RowCounter+1
        end

        set @String = right(@String,len(@String) - @idx)       
        if len(@String) = 0 break       
    end   
return       
end
GO
