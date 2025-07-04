1. **Wstęp**

  Aplikacja do Zarządzania Hotelem to proste narzędzie desktopowe, stworzone w technologii Windows Forms, które umożliwia podstawowe zarządzanie kluczowymi aspektami funkcjonowania hotelu. Na obecnym etapie aplikacja pozwala na:
  
•	Zarządzanie Użytkownikami: Dodawanie, edytowanie i usuwanie kont użytkowników z różnymi rolami (Admin, Receptionist, User), z uwzględnieniem mechanizmu logowania i hashowania haseł (BCrypt). Zapewnia to bezpieczny dostęp do systemu.

•	Zarządzanie Klientami: Prowadzenie bazy danych klientów hotelu, z możliwością dodawania, edycji i usuwania ich danych.

•	Zarządzanie Pokojami: Ewidencja pokoi hotelowych wraz z ich numerami, typami, cenami za noc oraz statusem dostępności. Możliwe jest dodawanie, edycja i usuwanie pokoi.

•	Zarządzanie Rezerwacjami: Tworzenie, modyfikowanie i usuwanie rezerwacji dla klientów w konkretnych pokojach na określone daty. System wstępnie filtruje dostępne pokoje na podstawie wybranych dat, aby unikać nakładających się rezerwacji.

2. **Architektura**

   System rezerwacji pokoi składa się z kilku głównych elementów, które razem umożliwiają wygodne zarządzanie pokojami, klientami i rezerwacjami w hotelu       lub pensjonacie. Każdy element ma swoją          konkretną rolę:

   “Klienci” - to dane o osobach, które korzystają z hotelu.
    System przechowuje ich imię, nazwisko i telefon, aby później łatwo było sprawdzać, kto zarezerwował dany pokój.

   “Pokoje” - to lista pokoi dostępnych w hotelu.
     Każdy pokój ma:
    -swój numer,
   
    -liczbę miejsc do spania,
   
    -informację, ile jest w nim łóżek pojedynczych i podwójnych.

   “Widoki” - System posiada cztery główne ekrany, które pozwalają użytkownikowi (np. recepcjoniście) sprawnie obsługiwać hotel:
    -Lista Rezerwacji — wyświetla wszystkie rezerwacje razem z informacjami o kliencie i terminie pobytu.
   
    -Rezerwuj Pokój — pozwala wybrać pokój i klienta, a następnie zapisać nową rezerwację.
   
    -Wolne Pokoje — prezentuje listę pokoi, które w danym momencie są dostępne.
   
    -Lista Pokoi — wyświetla wszystkie pokoje dostępne w hotelu.

   “Pliki danych” - System przechowuje dane w prostych plikach tekstowych:
    -klienci.txt — dane klientów,
   
    -pokoje.txt — dane pokoi,
   
    -rezerwacje.txt — dane rezerwacji.
   
    Te pliki pozwalają systemowi pamiętać i pokazywać wcześniej wprowadzone dane.

3. **Klasy**

    “DodajKlienta” to formularz w aplikacji, który służy do dodawania nowego klienta. Pozwala użytkownikowi wpisać dane klienta i zapisać je do pliku tekstowego.

    Odpowiada za:
   
    -Wyświetlanie formularza z polami: Imię, Nazwisko, Telefon, Email.
   
    -Umożliwianie zapisu danych klienta po kliknięciu przycisku „Zapisz”.
   
    -Sprawdzenie, czy klient z takim telefonem lub e-mailem już istnieje, zanim doda go do pliku.
   
    -Zapis dane do pliku tekstowego “klienci.txt”, oddzielając dane średnikami (;).
   
    Zmienne w klasie:
   
    -“TextBox txtImie, txtNazwisko, txtTelefon, txtEmail” – pola tekstowe, gdzie użytkownik wpisuje dane.
   
    -“Button btnZapisz” – przycisk, który zapisuje dane klienta po kliknięciu.
   
    -“string plikKlientow” = "klienci.txt" – ścieżka do pliku, gdzie zapisywane są dane klientów.
   
    Metody:
   
    “InitializeComponents()”
    -Tworzy i ustawia wygląd elementów graficznych (etykiety, pola, przycisk).
   
    -Ustawia tytuł okna, rozmiar, kolor tła itp.
   
    -Podłącza przycisk do akcji: btnZapisz.Click += BtnZapisz_Click.
   
    “BtnZapisz_Click(...)”
   
    -Sprawdza, czy wszystkie pola są wypełnione.
   
    -Jeśli nie → pokazuje komunikat o błędzie.
   
    -Sprawdza, czy telefon lub email już istnieje w pliku.
   
    -Jeśli istnieje → pokazuje błąd i nie dodaje klienta.
   
    -Jeśli wszystko jest OK → dane zostaną dodane do pliku (ten fragment kodu zapewne będzie dalej, ale jeszcze go nie wysłałeś).
    
    “DodajPokoj” to formularz w aplikacji, który służy do dodawania nowego pokoju hotelowego. Użytkownik wypełnia pola dotyczące pokoju i zapisuje te informacje do pliku tekstowego pokoje.txt.

   Odpowiada za:
   
    -Wyświetlnie formularza z polami do wypełnienia: numer pokoju, liczba miejsc, łóżka pojedyncze, łóżka podwójne.
   
    -Sprawdzenie, czy wszystkie dane zostały wpisane.
   
    -Zapisywanie danych do pliku pokoje.txt.
   
    Zmienne w klasie:
   
    -“txtNumer” – pole tekstowe do wpisania numeru pokoju.
   
    -“txtMiejsca” – liczba wszystkich miejsc (np. 3 osoby).
   
    -“txtLozkaPojedyncze” – ile jest łóżek pojedynczych.
   
    -“txtLozkaPodwojne” – ile jest łóżek podwójnych.
   
    -“btnZapisz” – przycisk, który po kliknięciu zapisuje dane.
   
    -“plikPokoi” – nazwa pliku, do którego zapisywane są pokoje (pokoje.txt).
   
    Metody:
   
    “DodajPokojForm()” – konstruktor:
   
    -Tworzy nowe okno i ustawia jego wygląd przez wywołanie InitializeComponents().
   
    “InitializeComponents()” – inicjalizacja formularza:
   
    -Tworzy wszystkie pola, etykiety i przycisk.
   
    -Ustawia ich pozycje, rozmiary i wygląd.
   
    -Dodaje je do formularza (czyli do okna aplikacji).
   
    -Podłącza przycisk btnZapisz do metody, która zapisuje dane (BtnZapisz_Click).
   
    “BtnZapisz_Click(...)” – co się dzieje po kliknięciu „Zapisz”:
   
    -Sprawdza, czy użytkownik wypełnił wszystkie pola.
   
    -Jeśli czegoś brakuje → pokazuje komunikat o błędzie.
   
    -Jeśli wszystko jest OK: tworzy jeden tekstowy wiersz z danymi, oddzielonymi średnikami, dopisuje ten wiersz do pliku pokoje.txt, pokazuje komunikat         „Pokój został dodany!”, zamyka formularz.
    
    “DodajRezerwacje” to okno w aplikacji graficznej, które służy do tworzenia nowej rezerwacji pokoju przez klienta na konkretny termin.
   
    Odpowiada za:
   
    -Wyświetlenie formularza, w którym można wybrać:
   
     klienta (z listy wczytanej z pliku klienci.txt),
   
     pokój (z listy wczytanej z pliku pokoje.txt),
   
     datę rozpoczęcia i zakończenia rezerwacji.
   
    -Sprawdzenie, czy dane są poprawnie wypełnione.
   
    -Zapisanie nowej rezerwacji do pliku rezerwacje.txt.
   
    Zmienne w klasie:
   
    -“plikKlientow, plikPokoi, plikRezerwacji” – ścieżki do plików z danymi.
   
    -“klienci, pokoje” – listy przechowujące dane o klientach i pokojach.
   
    -“cmbKlient, cmbPokoj” – listy rozwijane do wyboru klienta i pokoju.
   
    -“dtpDataOd, dtpDataDo” – pola do wyboru dat (kiedy rezerwacja się zaczyna i kończy).
   
    -“btnZapisz” – przycisk do zapisania rezerwacji.
   
    Metody:
   
    “DodajRezerwacjeForm()” – konstruktor:
   
    -Uruchamia okno, ustawia wygląd i wczytuje dane klientów i pokoi.
   
     “InitializeComponents()” – ustawianie wyglądu formularza:
   
    -Tworzy wszystkie elementy graficzne (etykiety, listy rozwijane, daty, przycisk).
   
    -Ustawia ich rozmieszczenie i styl.
   
    -Dodaje je do formularza.
   
    -Przycisk Zapisz jest podpięty do metody BtnZapisz_Click.
   
    “WczytajDane()” – wczytuje dane z plików:
   
    -Z klienci.txt – ładuje dane klientów do listy i do rozwijanej listy (ComboBox):
   
    -Wyświetla ich jako: Imię Nazwisko (Telefon).
   
    -Z pokoje.txt – ładuje numery pokoi do drugiej listy rozwijanej.
   
     “BtnZapisz_Click()” – zapisanie nowej rezerwacji:
   
    -Sprawdza, czy coś zostało wybrane:
   
    - Jeśli nie wybrano klienta lub pokoju → pokazuje błąd.
      
    -Sprawdza daty:
   
    - Data „od” nie może być późniejsza niż „do”.
      
    -Tworzy zapis rezerwacji
   
    -Zapisuje rezerwację do pliku rezerwacje.txt.
   
    -Pokazuje komunikat „Rezerwacja została zapisana” i zamyka formularz.

4. **Zastosowanie paradygmatu obiektowego w programie**

   W projekcie zaimplementowano kluczowe elementy paradygmatu obiektowego:
   
      4.1. Hermetyzacja (Encapsulation)
       
      Hermetyzacja to zasada ukrywania wewnętrznego stanu obiektu i udostępniania go na zewnątrz tylko poprzez publiczne metody (interfejs). Pozwala to na          kontrolowanie dostępu do danych i zapewnienie spójności obiektu.
      
      Przykłady w kodzie:
      
      •	Klasy Modeli (User, Client, Room, Reservation):
      
      o	Wszystkie właściwości w tych klasach są zazwyczaj publiczne, ale ich implementacja wewnętrzna (np. sposób przechowywania danych) może być ukryta.          Co ważniejsze, logika biznesowa związana z tymi obiektami (np. walidacja danych przed zapisem) jest często zawarta w metodach, a nie bezpośrednio w          dostępie do pól.
      
      o	Przykład: W klasie User właściwości takie jak Id, Name, Surname, Username, PasswordHash, Role są dostępne, ale modyfikacja PasswordHash odbywa się          poprzez zewnętrzny serwis (AuthService), który zapewnia hashowanie, co jest formą hermetyzacji logicznej.
      
      •	Klasy Repozytoriów (UserRepository, ClientRepository, RoomRepository, ReservationRepository):
      
      o	Repozytoria hermetyzują logikę dostępu do danych. Ich wewnętrzne działanie (np. konkretne zapytania SQL, zarządzanie połączeniami z bazą danych)          jest ukryte przed klasami UI. Klasy UI jedynie wywołują publiczne metody takie jak Add(), Get(), Update(), Delete(), nie wiedząc, jak dokładnie są one       realizowane.
      
      o	Przykład: 
      
      W /Repositories/UserRepository.cs (oraz innych repozytoriach) metoda Add(User user) ukrywa całą logikę związaną z tworzeniem połączenia z bazą danych,       budowaniem zapytania SQL i wykonaniem operacji INSERT.
      
      •	Klasy Formularzy/Kontrolek UI (ClientEditForm, ReservationEditForm, RoomsControl itp.):
      
      o	Kontrolki UI hermetyzują logikę interakcji użytkownika i walidacji danych wejściowych. Nie muszą wiedzieć o tym, jak działają repozytoria czy             serwisy.
      
      o	Przykład: W /UI/RoomEditForm.cs, metoda buttonSave_Click zawiera walidację pól formularza. Ta logika jest zawarta w formularzu i jest                      odpowiedzialna za upewnienie się, że dane są poprawne, zanim zostaną przekazane do _roomRepository. Szczegóły dotyczące, jak _roomRepository zapisuje          dane, są ukryte.
      
      4.2 Dziedziczenie (Inheritance)
         
      Dziedziczenie to mechanizm, w którym jedna klasa (klasa pochodna/subklasa) dziedziczy właściwości i metody innej klasy (klasy bazowej/superklasy).             Pozwala to na ponowne wykorzystanie kodu i tworzenie hierarchii klas.
      
      Przykłady w kodzie:
      
      •	GenericRepository<T> i Specyficzne Repozytoria:
      
      o	To jest doskonały przykład dziedziczenia w projekcie. Klasa GenericRepository<T> (gdzie T to typ modelu, np. User, Client, Room, Reservation)                prawdopodobnie stanowi klasę bazową, która implementuje ogólne operacje CRUD (Create, Read, Update, Delete).
      
      o	Konkretne repozytoria, takie jak UserRepository, ClientRepository, RoomRepository, ReservationRepository, dziedziczą z GenericRepository<T>, co             oznacza, że automatycznie otrzymują podstawową funkcjonalność CRUD. Dzięki temu unika się powielania kodu dla każdej encji.
      
      o	Lokalizacja: Chociaż kod GenericRepository<T> nie został dostarczony, jego obecność jest silnie sugerowana przez użycie UserRepository,                      ClientRepository, RoomRepository, ReservationRepository, które prawdopodobnie są jego pochodnymi.
      
      	UserRepository (w kontekście /UI/UserEditForm.cs i /UI/UserManagementControl.cs)
      
      	ClientRepository (w kontekście /UI/ClientEditForm.cs i /UI/ClientsControl.cs)
      
      	RoomRepository (w kontekście /UI/RoomEditForm.cs i /UI/RoomsControl.cs)
      
      	ReservationRepository (w kontekście /UI/ReservationEditForm.cs i /UI/ReservationsControl.cs)
      
      o	Przykład (hipotetyczny, jak wyglądałoby dziedziczenie):
      
      // Klasa bazowa (zakładana)
      
      public abstract class GenericRepository<T> where T : BaseModel // Założenie, że BaseModel ma Id
      {
          protected string _tableName;
          // ... implementacja GetAll, Get, Add, Update, Delete
      }
      
      // Klasa pochodna (jak np. UserRepository)
      
      public class UserRepository : GenericRepository<User>
      {
          public UserRepository()
          {
              _tableName = "Users"; // Ustawienie nazwy tabeli dla konkretnego repozytorium
          }
          // ... dodatkowe metody specyficzne dla użytkowników (np. GetByUsername)
      }
      
      •	Klasy Formularzy i Kontrolek Użytkownika:
      
      o	LoginForm, ClientEditForm, ReservationEditForm, RoomEditForm, UserEditForm dziedziczą z System.Windows.Forms.Form.
      
      o	ClientsControl, ReservationsControl, RoomsControl, UserManagementControl dziedziczą z System.Windows.Forms.UserControl.
      
      o	Lokalizacja:
      
      	UserEditForm : Form (w /UI/UserEditForm.cs)
      
      	ReservationsControl : UserControl (w /UI/ResrvationsControl.cs)
      
      	RoomEditForm : Form (w /UI/RoomEditForm.cs)
      
      	RoomsControl : UserControl (w /UI/RoomsControl.cs)
      
      o	To dziedziczenie zapewnia, że te klasy mają wszystkie podstawowe funkcjonalności formularzy i kontrolek Windows Forms (np. zarządzanie zdarzeniami,          rysowanie na ekranie, właściwości Text, Controls itp.) bez konieczności ich ponownego implementowania.
      
      4.3. Polimorfizm (Polymorphism)
         
      Polimorfizm ("wiele form") pozwala obiektom różnych klas być traktowanymi jako obiekty wspólnego typu. Najczęściej objawia się poprzez nadpisywanie          metod (override) lub implementację interfejsów.
      
      Przykłady w kodzie:
      
      •	Nadpisywanie metody ToString():
      
      o	Wiele klas modelowych (User, Client, Room, Reservation) nadpisuje metodę ToString() (dziedziczoną z object). Dzięki temu, gdy obiekt tych klas jest       dodawany do ListBox (np. listBoxUsers.Items.Add(user)), ListBox automatycznie wywołuje ich nadpisaną metodę ToString() w celu wyświetlenia czytelnej          reprezentacji obiektu.
      
      o	Lokalizacja:
      	public override string ToString() w klasie Reservation (w /UI/ResrvationsControl.cs, zagnieżdżona klasa DisplayReservationItem).
      
      	public override string ToString() w klasie User (w kontekście /UI/UserManagmentControl.cs - listBoxUsers.Items.Add(user)).
      
      	public override string ToString() w klasie Client (w kontekście /UI/ClientsControl.cs - listBoxClients.Items.Add(client)).
      
      	public override string ToString() w klasie Room (w kontekście /UI/RoomsControl.cs - listBoxRooms.Items.Add(room)).
      
      o	Przykład z Reservation w DisplayReservationItem:
      
      // W klasie DisplayReservationItem w /UI/ResrvationsControl.cs
      
      public override string ToString()
      {
          // Tworzenie czytelnego ciągu tekstowego do wyświetlenia
          string clientName = Client != null ? $"{Client.Name} {Client.Surname}" : $"Klient ID: {Reservation.ClientId} (nieznany)";
          string roomInfo = Room != null ? $"Pokój {Room.Number} ({Room.Type})" : $"Pokój ID: {Reservation.RoomId} (nieznany)";
          return $"{clientName} - {roomInfo} od {Reservation.StartDate.ToShortDateString()} do {Reservation.EndDate.ToShortDateString()}";
      }
      
      •	
      
      o	Jest to polimorfizm, ponieważ ListBox "nie wie", jakiego dokładnie typu obiekt został do niego dodany, ale wie, że każdy obiekt posiada metodę             ToString(), którą może wywołać, aby uzyskać tekst do wyświetlenia.
      
      •	Obsługa zdarzeń (EventHandler):
      
      o	Wiele przycisków w aplikacji (buttonSave, buttonAdd, buttonEdit, buttonDelete itp.) oraz kontrolek takich jak ListBox (SelectedIndexChanged) ma             przypisane metody obsługujące zdarzenia. Te metody mają wspólny sygnaturę (object sender, EventArgs e).
      
      o	Lokalizacja: W plikach *.Designer.cs i *.cs dla każdego formularza/kontrolki, np.:
      
      	this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click); (w /UI/UserEditForm.Designer.cs)
      
      	private void buttonSave_Click(object sender, EventArgs e) (w /UI/UserEditForm.cs)
      
      o	System Windows Forms używa polimorfizmu, wywołując metodę Invoke na delegacie EventHandler, która z kolei wywołuje konkretną metodę obsługi                zdarzenia, niezależnie od jej specyficznej implementacji

 5. **Cykl życia obiektów**
     
      Klienci
    
    -Dodawanie: Klienci pojawiają się w systemie, gdy ktoś zgłasza chęć rezerwacji. Dane takiej osoby (imię, nazwisko, telefon) zostają zapisane w pliku          klienci.txt.
    
    -Odczyt: System może później odczytać te dane, aby pokazać je podczas rezerwacji.
    
    -Usuwanie: Klienci mogą być usunięci ręcznie (poza systemem) poprzez edycję pliku, gdy stracą swoją ważność.
       
      Pokoje
    
    -Dodawanie: Nowe pokoje pojawiają się w pliku pokoje.txt, gdy hotel je uruchamia.
    
    -Odczyt: System sprawdza ten plik przy wyświetlaniu listy pokoi i gdy chcemy dokonać rezerwacji.
    
    -Usuwanie: Pokój może być usunięty poprzez ręczną edycję pliku (np. gdy pokój jest zamykany).
    
      Rezerwacje
    
    -Dodawanie: Powstają, gdy użytkownik (np. recepcjonista) wybierze:
    
    Klienta,
    
    Pokój,
    
    Termin od/do,
    
    i potwierdzi rezerwację. Dane trafiają do pliku rezerwacje.txt.
    
    -Odczyt: System używa danych rezerwacji, aby:
    
    Pokazać listę aktywnych rezerwacji,
    
    Sprawdzić dostępność pokoi (czy pokój jest zajęty w wybranym terminie).
    
    -Usuwanie: Rezerwacja przestaje być aktywna, gdy:
    
    Minie data jej zakończenia (jest „zamknięta”),
    
    Albo gdy użytkownik ręcznie usunie ją poprzez modyfikację pliku.

6. **Przykładowy przepływ działania programu**

      Uruchomienie systemu
   
    – Otwiera się główny ekran i wczytuje listę rezerwacji z pliku rezerwacje.txt.
   
    – Klienci i pokoje są odczytywani z plików klienci.txt i pokoje.txt.
   
      Dodanie nowej rezerwacji
   
    – Użytkownik wybiera Klienta i Pokój.
   
    – Podaje daty rezerwacji.
   
    – System sprawdza, czy pokój jest dostępny (analizując plik rezerwacje.txt).
   
    – Jeśli pokój jest wolny, nowa rezerwacja jest zapisywana.
   
      Wyświetlenie listy rezerwacji
   
    – System odczytuje plik rezerwacje.txt i łączy dane Klienta (z pliku klienci.txt) z numerami pokoi.
   
    – Wynik prezentowany jest użytkownikowi w przejrzystej tabeli.
   
      Wyświetlenie wolnych pokoi
   
    – System sprawdza plik rezerwacje.txt i filtruje listę pokoi (pokoje.txt) tak, aby pokazać te, które:
   
    - Nie mają aktywnej rezerwacji.
      
    - Są dostępne do wynajęcia.

7. **Uruchomienie programu z wiersza poleceń**

   Aby uruchomić program z wiersza poleceń należy wpisać nazwę pliku wykonywalnego ObslugaHotelu.exe w linii poleceń a następnie wcisnąć ENTER. Jeśli program nie znajduje się w domyślnym katalogu koniczne     będzie podanie pełnej ścieżki dostępu.

   Przykład:
   
   C:\Users\user> ObslugaHotelu.exe
   
   lub
   
   C:\Users\user> C:\Program Files\ObslugaHotelu.exe

8. **Co można udoskonalić w tym programie**

      Istnieje wiele obszarów, w których aplikacja może zostać rozszerzona i ulepszona, aby zapewnić lepszą funkcjonalność i doświadczenie użytkownika:
   
      8.1.	Automatyczne oznaczanie dostępności pokoi:
   
      o	Problem: Obecnie status IsAvailable dla pokoju jest statyczny. Po utworzeniu rezerwacji, pokój technicznie jest nadal oznaczony jako "Dostępny".
   
      o	Ulepszenie: Zaimplementuj logikę, która automatycznie zmienia status IsAvailable pokoju na false, gdy jest on zarezerwowany w danym okresie. Po             zakończeniu rezerwacji, status powinien automatycznie wrócić na true. Wymagałoby to rozbudowania logiki w ReservationRepository lub w serwisie                obsługującym rezerwacje.
   
      8.2.	Podgląd historii zmian/audyt:
   
      o	Problem: Obecnie nie ma śledzenia, kto i kiedy wprowadził zmiany w danych (np. kto dodał klienta, edytował pokój, czy usunął rezerwację).
   
      o	Ulepszenie: Dodaj mechanizm logowania operacji (np. tabelę AuditLog w bazie danych), która rejestrowałaby:
   
      	Datę i godzinę zmiany
   
      	Użytkownika, który dokonał zmiany
   
      	Rodzaj operacji (dodanie, edycja, usunięcie)
   
      	Typ obiektu (Klient, Pokój, Rezerwacja, Użytkownik)
   
      	(Opcjonalnie) Stare i nowe wartości dla edytowanych pól.
   
      o	Wymagałoby to modyfikacji wszystkich metod Add, Update, Delete w repozytoriach, aby logowały te informacje.
   
      8.3.	Wizualne ulepszenia interfejsu użytkownika (UI/UX):
   
      o	Problem: Obecny wygląd jest standardowy dla Windows Forms i może być mało atrakcyjny lub nieintuicyjny.
   
      o	Ulepszenia:
   
      	Walidacja wizualna: Zamiast MessageBox.Show dla błędów walidacji, użyj ErrorProvider lub wizualnie podświetl pola z błędami, co jest mniej                inwazyjne dla użytkownika.
   
      	Lepsze formatowanie dat/czasów: Rozważ użycie niestandardowego formatowania w DateTimePicker lub w widoku rezerwacji, aby były bardziej czytelne.
   
      	Szersze kolumny/elastyczne układy: Dostosuj szerokości ListBox i kolumn, aby zawartość była w pełni widoczna, niezależnie od długości tekstu.
   
      	Ikony: Dodaj odpowiednie ikony do przycisków akcji (Dodaj, Edytuj, Usuń), aby poprawić intuicyjność.
   
      	Responsywny design: Jeśli aplikacja miałaby działać na różnych rozmiarach ekranu, rozważ użycie kontrolek kontenerowych (TableLayoutPanel,                   FlowLayoutPanel) do bardziej elastycznego układu.
   
      	Stylizacja: Zastosowanie niestandardowych stylów lub bibliotek UI (jeśli projekt na to pozwala), aby nadać aplikacji bardziej nowoczesny wygląd.
   
      8.4.	Raporty i statystyki:
   
      o	Problem: Brak możliwości generowania raportów dotyczących obłożenia, dochodów czy popularności pokoi.
   
      o	Ulepszenie: Dodaj sekcję raportów, która pozwalałaby generować:
   
      	Raporty obłożenia pokoi w danym okresie.
   
      	Zestawienia dochodów z rezerwacji.
   
      	Listy dostępnych pokoi na przyszłe daty.
   
      	Raporty klientów (np. najczęściej rezerwujący).
   
      8.5.	Filtrowanie i wyszukiwanie:
   
      o	Problem: Listy klientów, pokoi i rezerwacji mogą stać się bardzo długie.
   
      o	Ulepszenie: Dodaj pola wyszukiwania i filtry, które pozwolą użytkownikom szybko znaleźć konkretne dane (np. wyszukiwanie klienta po nazwisku,             filtrowanie pokoi po typie, filtrowanie rezerwacji po dacie).
   
      8.6.	Ulepszone zarządzanie dostępnością pokoi w rezerwacji:
   
      o	Problem: Formularz rezerwacji filtruje pokoje, ale nie wyświetla informacji o nakładających się rezerwacjach w jasny sposób
   .
      o	Ulepszenie: Rozbuduj logikę, aby użytkownik widział, które pokoje są niedostępne i dlaczego (np. poprzez wyświetlenie nakładających się dat                rezerwacji).
   
      8.7.	Zarządzanie cenami sezonowymi / promocjami:
   
      o	Problem: Cena za noc jest stała dla pokoju.
   
      o	Ulepszenie: Dodaj możliwość definiowania specjalnych cen dla pokoi w określonych datach (np. wyższe ceny w sezonie, niższe w promocji).
   
      Te propozycje mogą znacznie zwiększyć użyteczność i profesjonalizm aplikacji.


**Schemat UML, "Działanie programu" oraz "Struktura plików" znajdują się w osobnym pliku .pdf.**

9. **Autorzy**
   
    Michał Krawczyk,
    Michał Szymiczek
