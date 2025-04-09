Program obsługujący rezerwacje hotelowe.

Krótki opis działania:
Przy starcie programu MenedzerPlikow.WczytajDane() wczytuje dane z pliku i tworzy obiekty Pokoj oraz
Rezerwacja.
Użytkownik wybiera numer pokoju → program przez RezerwacjaManager sprawdza dostępność.
Jeśli pokój zajęty → pokazuje dane klienta i szczegóły rezerwacji.
Jeśli wolny → użytkownik może dodać nowego klienta i rezerwację, a dane zostaną zapisane do pliku.

-------------------
| Pokój |
+-------------------+
| - numer: int |
| - iloscMiejsc: int|
| - rezerwacje: List<Rezerwacja> |
+-------------------+
| +SprawdzDostepnosc(termin: DateTime): bool |
| +DodajRezerwacje(rez: Rezerwacja): void |
| +PobierzRezerwacje(termin: DateTime): Rezerwacja |
-------------------
----------------------
| Klient |
+----------------------+
| - imie: string |
| - nazwisko: string |
| - kontakt: string |
+----------------------+
| +ToString(): string |
----------------------
------------------------
| Rezerwacja |
+------------------------+
| - klient: Klient |
| - termin: DateTime |
| - iloscOsob: int |
| - pokoj: Pokoj |
+------------------------+
| +ToString(): string |
------------------------
----------------------------
| MenedzerPlikow |
+----------------------------+
| - sciezkaPliku: string |
+----------------------------+
| +WczytajDane(): List<Pokoj>|
| +ZapiszDane(pokoje: List<Pokoj>): void |
----------------------------
---------------------------
| RezerwacjaManager |
+---------------------------+
| - listaPokoi: List<Pokoj> |
+---------------------------+
| +ZnajdzPokoj(nr: int): Pokoj |
| +DodajNowaRezerwacja(...) |
| +SprawdzDostepnosc(...) |
---------------------------

Relacje między klasami:
Pokój zawiera listę obiektów Rezerwacja.
Rezerwacja zawiera referencję do obiektu Klient oraz do Pokój.
Menedżer plików (klasa MenedzerPlikow) odpowiada za wczytywanie i zapisywanie danych do pliku
tekstowego.
RezerwacjaManager zarządza logiką biznesową, np. dodawaniem rezerwacji, sprawdzaniem dostępności
itd.
