1. **Wstęp**

  Aplikacja do Zarządzania Hotelem to proste narzędzie desktopowe, stworzone w technologii Windows Forms, które umożliwia podstawowe zarządzanie kluczowymi aspektami funkcjonowania hotelu. Na obecnym etapie aplikacja pozwala na:
  
•	Zarządzanie Użytkownikami: Dodawanie, edytowanie i usuwanie kont użytkowników z różnymi rolami (Admin, Receptionist, User), z uwzględnieniem mechanizmu logowania i hashowania haseł (BCrypt). Zapewnia to bezpieczny dostęp do systemu.

•	Zarządzanie Klientami: Prowadzenie bazy danych klientów hotelu, z możliwością dodawania, edycji i usuwania ich danych.

•	Zarządzanie Pokojami: Ewidencja pokoi hotelowych wraz z ich numerami, typami, cenami za noc oraz statusem dostępności. Możliwe jest dodawanie, edycja i usuwanie pokoi.

•	Zarządzanie Rezerwacjami: Tworzenie, modyfikowanie i usuwanie rezerwacji dla klientów w konkretnych pokojach na określone daty. System wstępnie filtruje dostępne pokoje na podstawie wybranych dat, aby unikać nakładających się rezerwacji.

2. **Architektura**

    Program został zaprojektowany w architekturze warstwowej, która dzieli całość systemu na moduły odpowiedzialne za różne funkcje. To ułatwia rozwój,           utrzymanie i testowanie aplikacji.
    
    Główne warstwy:
    
    1. Warstwa danych (Data Layer)
    
    Zawiera klasy reprezentujące dane oraz repozytoria do zarządzania nimi.
    
    Reprezentacja danych to klasy: User, Client, Room, Reservation.
    
    Dostęp do danych realizowany jest przez klasy Repository, które umożliwiają m.in. pobieranie, dodawanie i usuwanie danych.
    
    2. Warstwa logiki biznesowej (Business Logic Layer)
       
    Zawiera klasy obsługujące reguły działania programu.
    
    Np. klasa AuthService odpowiada za logowanie użytkowników, weryfikację hasła, rejestrację itd.
    
    Weryfikacja dostępności pokoi przy rezerwacji również należy do logiki biznesowej.
    
    3. Warstwa prezentacji (UI Layer)
       
    To formularze Windows Forms (Form), takie jak LoginForm, MainForm, ClientEditForm, ReservationEditForm itd.
    
    Te klasy umożliwiają użytkownikowi interakcję z systemem.
    
    Obsługują zdarzenia takie jak kliknięcia przycisków, wprowadzanie danych, wybieranie opcji itp.
   
3. **Klasy**

    3.1 User

   Reprezentuje użytkownika systemu (np. administratora lub pracownika).

    Właściwości:
    
    Id, Name, Surname, Username, PasswordHash, Role
    
    Funkcja:
    
    Umożliwia logowanie, zarządzanie kontami, autoryzację.

   3.2 Client

   Reprezentuje klienta hotelu (osobę rezerwującą pokój).

    Właściwości:
    
    Id, Name, Surname
    
    Funkcja:
    
    Przechowuje podstawowe dane klientów.

    3.3 Room

   Reprezentuje pokój hotelowy.

    Właściwości:
    
    Id, Number, Type (enum), PricePerNight, IsAvailable
    
    Funkcja:
    
    Definiuje numer pokoju, jego typ, cenę i dostępność.

   3.4 Reservation

   Reprezentuje rezerwację pokoju przez klienta.

    Właściwości:
    
    Id, ClientId, RoomId, StartDate, EndDate
    
    Funkcja:
    
    Przechowuje informacje o rezerwacjach w danym terminie.

   3.5 GenericRespository<T>

     Klasa ogólna (generyczna) do obsługi operacji CRUD (Create, Read, Update, Delete).
    
    Właściwości:
    
    _tableName – nazwa tabeli
    
    Metody:
    
    GetAll(), Get(id), Add(item), Update(item), Delete(id)
    
    Funkcja:
    
    Wspólna baza dla wszystkich repozytoriów (User, Room itd.)

    3.6 Repozytoria

   (UserRepository, ClientRepository, RoomRepository, ReservationRepository)
   
    Każde z nich dziedziczy po GenericRepository<T> i zarządza odpowiednim typem danych.

   3.7 AuthService

   Zajmuje się logiką uwierzytelniania i rejestracji użytkowników.

    Metody:
    
    Login(username, password)
    
    RegisterUser(...)

   3.8 Database

   Statyczna klasa odpowiedzialna za inicjalizację bazy danych i udostępnianie połączenia SQLite.

   **Formularze**

   3.9 LoginForm

   Ekran logowania.

    Używa AuthService do logowania.

   3.10 MainForm

   Główne okno aplikacji po zalogowaniu.

    Zawiera panele (kontrolki) zarządzania: klientami, pokojami, rezerwacjami, użytkownikami.

   3.11 ClientEditForm, RoomEditForm, ReservationEditForm, UserEditForm

   Formularze do edycji danych poszczególnych encji.

    Obsługują przyciski zapisu, walidację, wypełnianie pól.

   3.12 ClientsControl, RoomsControl, ReservationsControl, UserManagementControl

   Kontrolki odpowiedzialne za zarządzanie listami danych.

    Obsługują operacje dodawania, edytowania, usuwania.

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
     
    5.1 Uruchomienie aplikacji:
    
    Program startuje od formularza logowania LoginForm.
    
    Tworzony jest obiekt AuthService, który służy do logowania.
    
    Jeśli użytkownik wpisze dane, AuthService tworzy połączenie z bazą i szuka użytkownika (User) za pomocą UserRepository.
    
    👉 Utworzone obiekty:
    
    LoginForm
    
    AuthService
    
    UserRepository
    
    User (jeśli logowanie zakończone sukcesem)

    5.2 Logowanie:
    
    Jeśli logowanie przebiegnie pomyślnie, tworzony jest główny formularz MainForm, który zawiera cztery sekcje:
    
    ClientsControl
    
    RoomsControl
    
    ReservationsControl
    
    UserManagementControl
    
    👉 Tworzone obiekty:
    
    MainForm
    
    ClientsControl, RoomsControl, ReservationsControl, UserManagementControl

    5.3 Zarządzanie danymi:
    
    W każdej z sekcji użytkownik może wykonać operacje:
    
    ➕ Dodawanie:
    
    Tworzony jest formularz edycyjny (ClientEditForm, RoomEditForm, itd.)
    
    Tworzony jest obiekt encji (Client, Room, Reservation, User) i przekazywany do repozytorium w celu zapisania.
    
    ✏️ Edycja:
    
    Pobierany jest obiekt z bazy (np. Room) przez odpowiednie Repository.
    
    Przekazywany do formularza edycyjnego.
    
    Po edycji aktualizowany w repozytorium.
    
    ❌ Usuwanie:
    
    Użytkownik wybiera obiekt z listy.
    
    Repozytorium usuwa go na podstawie ID.
    
    👉 Utworzone/wykorzystane obiekty:
    
    Client, Room, Reservation, User
    
    ClientRepository, RoomRepository, ReservationRepository, UserRepository
    
    Formularze edycyjne

     5.4 Repozytoria:
    
    Repozytoria mają dość długi cykl życia:
    
    Tworzone przy inicjalizacji kontrolki (np. ClientsControl tworzy ClientRepository).
    
    Pozostają aktywne przez cały czas działania tej kontrolki.
    
    Przechowują logikę dostępu do danych: odczyt, zapis, aktualizacja, usuwanie.
    
    👉 Długo żyjące obiekty:
    
    Wszystkie Repository

    5.5 Zamknięcie aplikacji:
    
    Użytkownik zamyka MainForm.
    
    Wszystkie formularze i obiekty zostają automatycznie zniszczone (usunięte z pamięci).
    
    Połączenia z bazą są zamykane (jeśli były otwarte).
    
    👉 Zakończenie życia obiektów:
    
    Wszystkie formularze (LoginForm, MainForm, formularze edycyjne)
    
    Wszystkie kontrolki (ClientsControl itd.)
    
    Repozytoria, encje (User, Client itd.)

6. **Przykładowy przepływ działania programu**

   Użytkownik uruchamia aplikację.

    Otwiera się LoginForm, gdzie użytkownik się loguje.
    
    Po poprawnym logowaniu otwierany jest MainForm.
    
    W MainForm użytkownik może:
    
    Przejść do zakładek klientów, pokoi, rezerwacji, użytkowników.
    
    Tam używa przycisków, by dodawać, edytować lub usuwać dane.
    
    Dane zapisywane są do plików lub bazy danych przez repozytoria.   

7. **Uruchomienie programu z wiersza poleceń**

   Aby uruchomić program z wiersza poleceń należy wpisać nazwę pliku wykonywalnego ObslugaHotelu.exe w linii poleceń a następnie wcisnąć ENTER. Jeśli             program nie znajduje się w domyślnym katalogu koniczne     będzie podanie pełnej ścieżki dostępu.

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
