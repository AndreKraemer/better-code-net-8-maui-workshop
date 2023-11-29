# Übung 6: Navigation

- Legen Sie in Ihrem Projekt `ElVegetarianoFurio` eine neue Seite `CategoryPage.xaml` im Ordner Menu an.
- Legen Sie ein ViewModel `CategoryViewModel` mit den Eigenschaften  `Category` und `Dishes` an. Dishes ist eine ObservableCollection!
- Legen Sie eine Methode zum Laden der Liste der Dishes über den DataService anhand der vorgegebenen Category an
- Verbinden Sie View und ViewModel. 
- Registrieren Sie View und ViewModel in der DependencyInjection und registrieren Sie eine Route für die CategoryPage
- Erstellen Sie das Layout für die Seite `CategoryPage.xaml` analog zum Screenshot
- Navigieren Sie beim Klick auf eine Kategorie der Startseite zur entsprechenden Kategorie auf der Kategorieseite
- Bonus: Abstrahieren Sie die Navigationslogik der Shell in einen eigenen Service

![Übung](lab.png)