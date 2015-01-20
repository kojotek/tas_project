--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////DODAJ KLIENTA////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure DODAJ_KLIENTA

CREATE PROCEDURE DODAJ_KLIENTA
(@telefon varchar(50), @email varchar(50), @kraj varchar(50), @miasto varchar(50), 
@kod varchar(50), @ulica varchar(50), @nr_budynku varchar(50), @nr_mieszkania varchar(50), 
@imie varchar(50), @nazwisko varchar(50), @login_uzytkownika varchar(50), @haslo varchar(50))
as
BEGIN

BEGIN TRANSACTION a

BEGIN TRY

insert into DANE VALUES(@telefon, @email, NULL, @kraj, @miasto, @kod, @ulica, @nr_budynku, @nr_mieszkania, @imie, @nazwisko)

declare @id INT;
set @id = (select MAX(id_dane) from DANE );

insert into KLIENT(login, id_dane, haslo) VALUES(@login_uzytkownika, @id, @haslo)

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION a

END CATCH

COMMIT TRANSACTION a

END

--przyklad uzycia

EXEC DODAJ_KLIENTA
'123456123', 'klient@gmail.com', 'Polska', 'Poznañ',
'12-345', 'umultowska', '24A', '5',
'Jan', 'Kowalski', 'Janek123', '12niktnieodgadnie'
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////DODAJ SPRZEDAWCE/////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure DODAJ_SPRZEDAWCE

CREATE PROCEDURE DODAJ_SPRZEDAWCE
(@login_uzytkownika varchar(50), @nr_konta varchar(26))
as
BEGIN

BEGIN TRANSACTION a

BEGIN TRY

declare @id int;
set @id = (select id_dane from KLIENT where login = @login_uzytkownika);

UPDATE DANE
set nr_konta = @nr_konta WHERE id_dane = @id

insert into SPRZEDAWCA(login, id_dane, haslo) VALUES(@login_uzytkownika, @id, (select haslo from KLIENT where login = @login_uzytkownika))

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION a

END CATCH

COMMIT TRANSACTION a

END

--przyklad uzycia
EXEC DODAJ_SPRZEDAWCE
'Janek123', '12123412341234123412341234'
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////EDYTUJ_DANE//////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure EDYTUJ_DANE

CREATE PROCEDURE EDYTUJ_DANE
(@telefon varchar(50), @email varchar(50), @kraj varchar(50), @miasto varchar(50), 
@kod varchar(50), @ulica varchar(50), @nr_budynku varchar(50), @nr_mieszkania varchar(50), 
@imie varchar(50), @nazwisko varchar(50), @login_uzytkownika varchar(50))
as
BEGIN

	BEGIN TRANSACTION a

		BEGIN TRY

			declare @id int
			set @id = (select id_dane from KLIENT where login = @login_uzytkownika)

			UPDATE DANE set telefon = @telefon WHERE id_dane = @id
			UPDATE DANE set email = @email WHERE id_dane = @id
			UPDATE DANE set kraj = @kraj WHERE id_dane = @id
			UPDATE DANE set miasto= @miasto WHERE id_dane = @id
			UPDATE DANE set kod = @kod WHERE id_dane = @id
			UPDATE DANE set ulica = @ulica WHERE id_dane = @id
			UPDATE DANE set budynek = @nr_budynku WHERE id_dane = @id
			UPDATE DANE set mieszkanie = @nr_mieszkania WHERE id_dane = @id
			UPDATE DANE set imie = @imie WHERE id_dane = @id
			UPDATE DANE set nazwisko = @nazwisko WHERE id_dane = @id

		END TRY

		BEGIN CATCH

			ROLLBACK TRANSACTION a

		END CATCH

	COMMIT TRANSACTION a

END

--przyklad uzycia

EXEC EDYTUJ_DANE
'123456126', 'klient@gmail.com', 'Polska', 'Poznañ',
'12-345', 'umultowska', '24A', '5',
'Jan', 'Kowalski', 'Janek123'
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////EDYTUJ_NR_KONTA//////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure EDYTUJ_NR_KONTA

CREATE PROCEDURE EDYTUJ_NR_KONTA
(@login varchar(50), @nr_konta varchar(26))
as
BEGIN

	BEGIN TRANSACTION a

		BEGIN TRY

			declare @id int
			set @id = (select id_dane from KLIENT where login = @login)

			UPDATE DANE set nr_konta = @nr_konta WHERE id_dane = @id

		END TRY

		BEGIN CATCH

			ROLLBACK TRANSACTION a

		END CATCH

	COMMIT TRANSACTION a

END

--przyklad uzycia

EXEC EDYTUJ_NR_KONTA
'Janek123', '12123412341234123412341234'
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////ZMIEN_HASLO//////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure ZMIEN_HASLO

ALTER PROCEDURE ZMIEN_HASLO
(@login varchar(50), @newPass varchar(50))
as
BEGIN

	BEGIN TRANSACTION a

		BEGIN TRY

			UPDATE KLIENT set haslo = @newPass WHERE login = @login
			UPDATE SPRZEDAWCA set haslo = @newPass WHERE login = @login

		END TRY

		BEGIN CATCH

			ROLLBACK TRANSACTION a

		END CATCH

	COMMIT TRANSACTION a

END

--przyklad uzycia

EXEC ZMIEN_HASLO
'Janek123', '1tttputas1'
GO

select * from KLIENT

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////USUN KONTO///////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure USUN_KONTO

CREATE PROCEDURE USUN_KONTO
(@login_uzytkownika varchar(20))
as
BEGIN

BEGIN TRANSACTION a

BEGIN TRY

UPDATE KLIENT
set data_do = GETDATE() where login = @login_uzytkownika

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION a

END CATCH

COMMIT TRANSACTION a

BEGIN TRANSACTION b

BEGIN TRY

UPDATE SPRZEDAWCA
set data_do = GETDATE() where login = @login_uzytkownika

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION b

END CATCH

COMMIT TRANSACTION b

END

--przyklad uzycia
EXEC USUN_KONTO
'Janek123'
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////DODAJ_AUKCJE/////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure DODAJ_AUKCJE

CREATE PROCEDURE DODAJ_AUKCJE
(@kategoria varchar(20), @login_uzytkownika varchar(20), @dlugosc_trwania int, @opis text, 
@nazwa_produktu varchar(30), @cena_startowa money, @cena_wysy³ki money)
as
BEGIN

BEGIN TRANSACTION a

BEGIN TRY

declare @id int;
set @id = (select id_kategoria from KATEGORIA where Nazwa = @kategoria);

declare @data datetime;
set @data = (select (GETDATE() + day(@dlugosc_trwania - 1)));


INSERT INTO AUKCJA(id_kategoria, login, data_zakonczenia, opis, nazwa_produktu, cena_startowa, cena_wysylki)
VALUES(@id, @login_uzytkownika, @data, @opis, @nazwa_produktu, @cena_startowa, @cena_wysy³ki)

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION a

END CATCH

COMMIT TRANSACTION a

END

--przyklad uzycia
EXEC DODAJ_AUKCJE
'AGD', 'Janek123', 3, 'lodówka z technologi¹ turbo full', 
'beko extra lux', 300, 100 
GO

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////DODAJ_OFERTE/////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure DODAJ_OFERTE

CREATE PROCEDURE DODAJ_OFERTE
(@id_aukcji int, @login_klienta varchar(20), @kwota money)
as
BEGIN
BEGIN TRANSACTION a
	BEGIN TRY
		
		IF((select ISNULL(MAX(kwota),0) from OFERTA where id_aukcji = @id_aukcji) < @kwota and
		   (select cena_startowa from AUKCJA where id_aukcji = @id_aukcji) < @kwota)
		BEGIN
		
			IF((select COUNT(kwota) from OFERTA where id_aukcji = @id_aukcji) >= 1 )
			BEGIN
				declare @poprzedniNajlepszy varchar(100);
				set @poprzedniNajlepszy = ( select login from oferta where id_aukcji = @id_aukcji AND kwota = ( select max(kwota) from oferta where id_aukcji = @id_aukcji ) )
				
				IF( @poprzedniNajlepszy <> @login_klienta )
				BEGIN
					exec powiadomienie_o_przebiciu @poprzedniNajlepszy, @id_aukcji;
				END
			END

			INSERT INTO OFERTA(id_aukcji, login, kwota) 
			VALUES(@id_aukcji, @login_klienta, @kwota)
			PRINT 'OK'

			exec powiadomienie_o_ofercie @login_klienta, @id_aukcji, @kwota;

		END
		
		
		ELSE print 'NIEOK'

	END TRY

	BEGIN CATCH

		ROLLBACK TRANSACTION a

	END CATCH

COMMIT TRANSACTION a

END

--przyklad uzycia

select * from AUKCJA

select * from OFERTA

EXEC DODAJ_OFERTE
'2','Janek123',8000
GO



--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////POWIADOMIENIE_O_OFERCIE//////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure powiadomienie_o_ofercie

CREATE PROCEDURE powiadomienie_o_ofercie 
(@kupujacy varchar(30), @aukcja int, @kwota money)
AS 
	BEGIN

	BEGIN TRANSACTION a

	BEGIN TRY
		declare @nazwa_aukcji varchar(100);
		set @nazwa_aukcji = (select nazwa_produktu from aukcja where id_aukcji = @aukcja);
		declare @sprzedawca varchar(100);
		set @sprzedawca = (select login from aukcja where id_aukcji = @aukcja);

		insert into POWIADOMIENIE( login, tresc )
		values ( @sprzedawca, 'Uzytkownik ' + @kupujacy + ' zlozyl oferte ' + convert(varchar(30), @kwota, 1) + ' zl w aukcji "' + @nazwa_aukcji + '"' );
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION a
	END CATCH

	COMMIT TRANSACTION a

END


--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////POWIADOMIENIE_O_WYGRANEJ//////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure powiadomienie_o_wygranej

CREATE PROCEDURE powiadomienie_o_wygranej
(@kupujacy varchar(30), @aukcja int)
AS 
	BEGIN

	BEGIN TRANSACTION a

	BEGIN TRY
		declare @nazwa_aukcji varchar(100);
		set @nazwa_aukcji = (select nazwa_produktu from aukcja where id_aukcji = @aukcja);
		declare @sprzedawca varchar(100);
		set @sprzedawca = (select login from aukcja where id_aukcji = @aukcja);

		insert into POWIADOMIENIE( login, tresc )
		values ( @kupujacy, 'Gratulacje! Twoja oferta w aukcji "' + @nazwa_aukcji + '" okazala sie najlepsza! Skontaktuj sie z uzytkownikiem ' + @sprzedawca + ', w celu ustalenia szczegó³ów zap³aty i przesy³ki.' );
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION a
	END CATCH

	COMMIT TRANSACTION a

END



--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////POWIADOMIENIE_O_PRZEGRANEJ//////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure powiadomienie_o_przegranej

CREATE PROCEDURE powiadomienie_o_przegranej
(@kupujacy varchar(30), @aukcja int)
AS 
	BEGIN

	BEGIN TRANSACTION a

	BEGIN TRY
		declare @nazwa_aukcji varchar(100);
		set @nazwa_aukcji = (select nazwa_produktu from aukcja where id_aukcji = @aukcja);

		insert into POWIADOMIENIE( login, tresc )
		values ( @kupujacy, 'Wlasnie zakonczyla sie aukcja "' +@nazwa_aukcji + '". Niestety, oferty innych uzytkowników okazaly sie bardziej atrakcyjne.' );
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION a
	END CATCH

	COMMIT TRANSACTION a

END


--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////POWIADOMIENIE_O_PRZEBICIU//////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure powiadomienie_o_przebiciu

CREATE PROCEDURE powiadomienie_o_przebiciu
(@kupujacy varchar(30), @aukcja int)
AS 
	BEGIN

	BEGIN TRANSACTION a

	BEGIN TRY
		declare @nazwa_aukcji varchar(100);
		set @nazwa_aukcji = (select nazwa_produktu from aukcja where id_aukcji = @aukcja);

		insert into POWIADOMIENIE( login, tresc )
		values ( @kupujacy, 'Ktos wlaœnie przebi³ twoj¹ ofertê w aukcji "' + @nazwa_aukcji + '". Z³ó¿ now¹ ofertê, by dalej braæ udzia³ w licytacji.' );
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION a
	END CATCH

	COMMIT TRANSACTION a

END


--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////POWIADOMIENIE_O_ZAKONCZENIU//////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

drop procedure powiadomienie_o_zakonczeniu

CREATE PROCEDURE powiadomienie_o_zakonczeniu
(@sprzedawca varchar(30), @zwyciezca varchar(30), @aukcja int)
AS 
	BEGIN

	BEGIN TRANSACTION a

	BEGIN TRY
		declare @nazwa_aukcji varchar(100);
		set @nazwa_aukcji = (select nazwa_produktu from aukcja where id_aukcji = @aukcja);

		insert into POWIADOMIENIE( login, tresc )
		values ( @sprzedawca, 'Wlasnie zakonczyla sie twoja aukcja "' + @nazwa_aukcji + '". Najwyzsza oferte zlozyl uzytkownik ' + @zwyciezca + '. Skontaktuj sie z nim, w celu omówienia szczególów finalizacji transakcji.' );
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION a
	END CATCH

	COMMIT TRANSACTION a

END


--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - TWORZENIE TAGÓW////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

alter trigger generuj_tagi on AUKCJA
	for insert
as
BEGIN

declare @text varchar(100), 
		@a int, 
		@t varchar(20),
		@l int,
		@i int
set @text = (select nazwa_produktu from inserted)

while (SELECT LEN(@text)) > 0

begin
set @a = (select PATINDEX ('% %', @text))
if @a != 0 begin
	set @t = (SELECT LEFT(@text,@a-1))
	set @l = (SELECT LEN(@text))
	set @i = (select id_aukcji from inserted)
	set @text = (select right(@text,@l-@a))
	insert into TAGI values(@i,@t) end
if @a = 0 begin
	insert into TAGI values(@i,@text)
	set @text = null end
end

END

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - USUWANIE TAGÓW/////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

alter trigger usuwaj_tagi on AUKCJA
	instead of delete
as
BEGIN

declare @i int

set @i = (select id_aukcji from deleted)
delete from TAGI where id_aukcji = @i
delete from AUKCJA where id_aukcji = (select id_aukcji from deleted)

END

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - PO TAGACH//////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////


CREATE FUNCTION wyszukiwanie_tagi
(@has³o varchar(100)) returns @wyszukano table 
(	id_aukcji int,
	id_kategoria int,
	login varchar(20),
	data_zakonczenia datetime,
	opis text,
	nazwa_produktu varchar(100),
	cena_startowa money,
	cena_wysylki money,
	ocena_sprzedawcy int,
	komentarz_dla_sprzedawcy text
	)
AS 
	BEGIN

declare @a int, 
		@t varchar(20),
		@l int
declare	@tabela TABLE (id int not null identity, 
					   tag varchar(20))

while (SELECT LEN(@has³o)) > 0
begin
set @a = (select PATINDEX ('% %', @has³o))
if @a != 0 begin
	set @t = (SELECT LEFT(@has³o,@a-1))
	insert into @tabela values(@t)
	set @l = (SELECT LEN(@has³o))
	set @has³o = (select right(@has³o,@l-@a))
	end
if @a = 0 begin
	insert into @tabela values(@has³o)
	set @has³o = null end
end

insert into @wyszukano 
select * from AUKCJA where id_aukcji = some (select id_aukcji from TAGI t cross join @tabela w 
					 where t.tag = w.tag group by id_aukcji)

return

END

--przyk³ad u¿ycia
select * from wyszukiwanie_tagi('8000 beko')

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - PO KATEGORIACH/////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

create FUNCTION wyszukiwanie_kategorie 
(@kategoria int) returns @wyszukano table 
(	id_aukcji int,
	id_kategoria int,
	login varchar(20),
	data_zakonczenia datetime,
	opis text,
	nazwa_produktu varchar(100),
	cena_startowa money,
	cena_wysylki money,
	ocena_sprzedawcy int,
	komentarz_dla_sprzedawcy text
	)
as
	BEGIN

	insert into @wyszukano
	select * from AUKCJA where id_kategoria = @kategoria

	return

END

 --przyk³ad u¿ycia
 select * from wyszukiwanie_kategorie(3)

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - PO KATEGORIACH i TAGACH////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

CREATE FUNCTION wyszukiwanie_k_t
(@has³o varchar(100),@kategoria int) 
returns @wyszukano table
(	id_aukcji int,
	id_kategoria int,
	login varchar(20),
	data_zakonczenia datetime,
	opis text,
	nazwa_produktu varchar(100),
	cena_startowa money,
	cena_wysylki money,
	ocena_sprzedawcy int,
	komentarz_dla_sprzedawcy text
	)
AS 
	BEGIN

declare @a int, 
		@t varchar(20),
		@l int
declare	@tabela TABLE (id int not null identity, 
					   tag varchar(20))

while (SELECT LEN(@has³o)) > 0
begin
set @a = (select PATINDEX ('% %', @has³o))
if @a != 0 begin
	set @t = (SELECT LEFT(@has³o,@a-1))
	insert into @tabela values(@t)
	set @l = (SELECT LEN(@has³o))
	set @has³o = (select right(@has³o,@l-@a))
	end
if @a = 0 begin
	insert into @tabela values(@has³o)
	set @has³o = null end
end

insert into @wyszukano 
select * from AUKCJA where id_aukcji = some (select id_aukcji from TAGI t cross join @tabela w where t.tag = w.tag group by id_aukcji)
	and id_kategoria = @kategoria

return

END

--przyk³ad u¿ycia

select * from wyszukiwanie_k_t('beko 8000',3)

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE/////////////////////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

alter procedure wyszukiwanie(@has³o varchar(100) = null,@kategoria int = null, @sposob_sort int = 1, @rosn¹co bit = 1)
as													        	  -- 1 cena 0 kategoria -- 1 rosn¹co 0 malej¹co

BEGIN
declare @aukcje table
(	id_aukcji int,
	id_kategoria int,
	login varchar(20),
	data_zakonczenia datetime,
	opis text,
	nazwa_produktu varchar(100),
	cena_startowa money,
	cena_wysylki money,
	ocena_sprzedawcy int,
	komentarz_dla_sprzedawcy text
	)
declare @oferty table
(	id_aukcji int, cena money
	)

if @has³o is null and @kategoria is null begin
	insert into @aukcje
	select * from AUKCJA end 
if @has³o is null and @kategoria is not null begin
	insert into @aukcje
	select * from wyszukiwanie_kategorie(@kategoria) end
if @has³o is not null and @kategoria is null begin
	insert into @aukcje
	select * from wyszukiwanie_tagi(@has³o) end
if @has³o is not null and @kategoria is not null begin
	insert into @aukcje
	select * from wyszukiwanie_k_t(@has³o,@kategoria) end

insert into @oferty
select id_aukcji,max(kwota) from OFERTA group by id_aukcji

if @sposob_sort = 1
	begin
	if @rosn¹co = 1 begin
		select * from @aukcje a left outer join @oferty o on a.id_aukcji = o.id_aukcji order by cena ASC end
	else begin
		select * from @aukcje a left outer join @oferty o on a.id_aukcji = o.id_aukcji order by cena DESC end
	end

if @sposob_sort = 0
	begin
	if @rosn¹co = 1 begin
		select * from @aukcje a left outer join @oferty o on a.id_aukcji = o.id_aukcji order by data_zakonczenia ASC end
	else begin
		select * from @aukcje a left outer join @oferty o on a.id_aukcji = o.id_aukcji order by data_zakonczenia DESC end
	end	

END

--przyk³ad u¿ycia
EXEC wyszukiwanie '8000 beko',null,0,0

--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - SORTOWANIE PO CENIE////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--
--create procedure sortowanie_cena(@rosn¹co bit)
--as
--
--BEGIN
--
--create table #oferty(id_aukcji int, cena money) 
--
--insert into #oferty
--select id_aukcji,max(kwota) from oferta group by id_aukcji
--
--if @rosn¹co = 1
--select * from AUKCJA a left outer join #oferty o on a.id_aukcji = o.id_aukcji order by cena ASC
--	else
--select * from AUKCJA a left outer join #oferty o on a.id_aukcji = o.id_aukcji order by cena DESC
--
--drop table #oferty
--
--END
--
--przyk³ad u¿ycia
--EXEC sortowanie_cena 1
--
--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////WYSZUKIWANIE_AUKCJI - SORTOWANIE PO DACIE KOÑCA//////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--
--create procedure sortowanie_data(@rosn¹co bit)
--as
--
--BEGIN
--
--if @rosn¹co = 1
--select * from AUKCJA order by data_zakonczenia ASC
--	else
--select * from AUKCJA order by data_zakonczenia DESC
--
--END
--
--przyk³ad u¿ycia
--EXEC sortowanie_data 1
--
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

insert into AUKCJA values(3, 'Janek123', 3, 'prywatno-publiczna toaleta', 'toaleta fuj fuj', 50, 100,null,null)

select * from TAGI

select * from AUKCJA



--/////////////////////////////////////////////////////////////////////////////////////////////////////////
--////////////////////////////////CZY AUKCJA JUZ SIE SKONCZYLA/////////////////////////////////////////////
--/////////////////////////////////////////////////////////////////////////////////////////////////////////

