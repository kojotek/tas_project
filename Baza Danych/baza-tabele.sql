drop table ZDJECIE
drop table OFERTA
drop table AUKCJA
drop table KATEGORIA
drop table SPRZEDAWCA
drop table KLIENT
drop table DANE
drop table POWIADOMIENIE

CREATE TABLE DANE
(
	id_dane int not null IDENTITY(1,1) PRIMARY KEY,
	telefon varchar(25) not null CHECK(telefon like '%[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]%'),
	email varchar(50) not null CHECK(email like '%@%.%'),
	nr_konta varchar(26) ,CHECK(nr_konta like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	kraj varchar(50) not null CHECK(kraj like '[A-Z]%'),
	miasto varchar(50) not null CHECK(miasto like '[A-Z]%'),
	kod varchar(6) not null CHECK(kod like '[0-9][0-9]-[0-9][0-9][0-9]'),
	ulica varchar(50) not null,
	budynek varchar(10) not null CHECK(budynek like '[0-9]%'),
	mieszkanie varchar(10) not null CHECK(mieszkanie like '[0-9]%'),
	imie varchar(50) not null CHECK(imie like '[A-Z]%' and imie not like '%[0-9]%'),
	nazwisko varchar(50) not null CHECK(nazwisko like '[A-Z]%' and nazwisko not like '%[0-9]%'),
)

CREATE TABLE SPRZEDAWCA
(
	login varchar(20) not null CHECK(LEN(login) >= 3) PRIMARY KEY,
	id_dane int not null references DANE(id_dane),
	haslo varchar(20) not null CHECK(LEN(haslo) >= 6 and haslo like '%[0-9]%'),
	data_od datetime not null default GETDATE(), 
	data_do datetime,
)

CREATE TABLE KLIENT
(
	login varchar(20) not null CHECK(LEN(login) >= 3) PRIMARY KEY,
	id_dane int not null references DANE(id_dane),
	haslo varchar(20) not null CHECK(LEN(haslo) >= 6 and haslo like '%[0-9]%'),
	data_od datetime not null default GETDATE(), 
	data_do datetime,
)

CREATE TABLE KATEGORIA
(
	id_kategoria int not null IDENTITY(1,1) PRIMARY KEY,
	id_rodzica int references KATEGORIA(id_kategoria),
	Nazwa varchar(20) not null,
	czy_lisc bit, --1 - true, 0 - false
)

insert into KATEGORIA VALUES(NULL, 'wszystkie', 0)
insert into KATEGORIA VALUES(1, 'RTV', 0)
insert into KATEGORIA VALUES(1, 'AGD', 0)
insert into KATEGORIA VALUES(1, 'sport', 0)
insert into KATEGORIA VALUES(1, 'komputery', 0)

CREATE TABLE AUKCJA 
(
	id_aukcji int not null IDENTITY(1,1) PRIMARY KEY,
	id_kategoria int not null references KATEGORIA(id_kategoria),
	login varchar(20) not null references SPRZEDAWCA(login),
	data_zakonczenia datetime not null,
	opis text not null,
	nazwa_produktu varchar(100) not null,
	cena_startowa money not null,
	cena_wysylki money not null,
	ocena_sprzedawcy int CHECK(ocena_sprzedawcy <= 10),
	komentarz_dla_sprzedawcy text,
)

CREATE TABLE TAGI
(
	id_aukcji int not null references AUKCJA(id_aukcji),
	tag varchar(20) not null,
)

CREATE TABLE ZDJECIE
(
  id_zdjecia int not null IDENTITY(1,1) PRIMARY KEY,
  id_aukcji int not null references AUKCJA(id_aukcji),
  zdjecie image not null,
  podpis varchar(50),
)

CREATE TABLE OFERTA 
(
  id_oferta int not null IDENTITY(1,1) PRIMARY KEY,
  id_aukcji int not null references AUKCJA(id_aukcji),
  login varchar(20) not null references KLIENT(login),
  kwota money not null,
  data_zlozenia datetime not null default GETDATE(), 
)

create table POWIADOMIENIE 
(
	id int not null primary key identity(1,1),
	login varchar(20) FOREIGN KEY REFERENCES KLIENT(login),
	tresc text not null, 
	data date not null default getdate()
)