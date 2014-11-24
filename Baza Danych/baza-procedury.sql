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

		IF((select ISNULL(MAX(kwota),0) from OFERTA where id_aukcji = @id_aukcji) <= @kwota and
		   (select cena_startowa from AUKCJA where id_aukcji = @id_aukcji) <= @kwota)
		BEGIN

			INSERT INTO OFERTA(id_aukcji, login, kwota) 
			VALUES(@id_aukcji, @login_klienta, @kwota)

		END
		
		ELSE print 'podana kwota jest mniejsza od najwy¿szej oferty lub ceny startowej!'

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
'3','Janek123',800
GO