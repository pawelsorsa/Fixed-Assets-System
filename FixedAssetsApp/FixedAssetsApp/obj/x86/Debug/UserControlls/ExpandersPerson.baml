   M S B A M L   `   `   `  ����I  EFixedAssetsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FixedAssetsApp.FixedAssetsWebService$FixedAssetsApp.FixedAssetsWebService  5      E'clr-namespace:FixedAssetsApp.ValidationFixedAssetsApp.Validation  5      2    ,FixedAssetsApp.UserControlls.ExpandersPerson   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @c2clr-namespace:FixedAssetsApp.FixedAssetsWebService     5      >
validators'clr-namespace:FixedAssetsApp.Validation     5        � 	Resources  5	       
  Person S� 
ObjectType1   +FixedAssetsApp.FixedAssetsWebService.Person��%"   &	        S� 5
   
   "  6,   5      .��5      � .+�5      � .+�5   
   �� -   5        $��showAllPersons��5      .��6D   #!Wyświetl wszystkich pracowników6e   �� 5   
   -   5        $��showPersonsWithPhone��5      .��6J   Numery telefonów6\   �� 5   
   -   5        $��showPersonsWithEmail��5      .��6J   Adresy e-mail6Y   5      � 5      .+�5      9� $��Wyszukiwanie zaawansowane��6   .��5   
   �� -   5        $��expanderSearch��5      $��10,4,0,0q�6+   .+�5      �� .��6   ID:6   � 5      .+�5      �� -   5        $
��tbId��5      $	��120��6&   $��0 0 15 0q�62   6F   �� 5      -   5        $��
btnGetById��5      .��6J   
Wyszukaj6T   5      �� 5      .��6   Imię:6   � 5      .+�5      �� -   5        $��tbName��5      $	��120��6(   $��0 0 15 0q�64   6H   �� 5      -   5        $��btnGetByName��5      .��6L   
Wyszukaj6V   5      �� 5      .��6   	Nazwisko:6   � 5       .+�5!      �� -	   5        $��	tbSurname��5!      $	��120��6+   $��0 0 15 0q�67   6K   �� 5"      -
   5        $��btnGetBySurname��5"      .��6O   
Wyszukaj6Y   5#      �� 5$      .��6   Imię i nazwisko:6&   � 5%      .+�5&      �� -   5        $��tbName_Surname��5&      $	��120��60   $��0 0 15 0q�6<   6P   �� 5'      -   5        $��btnGetByNameAndSurname��5'      .��6V   
Wyszukaj6`   5(      �� 5)      .��6   
Telefon:6   � 5*      .+�5+      �� -   5        $��tbPhone��5+      $	��120��6)   $��0 0 15 0q�65   6I   �� 5,      -   5        $��btnGetByPhone��5,      .��6M   
Wyszukaj6W   5-      �� 5.      .��6   Email:6   � 5/      .+�50      �� -   5        $��tbEmail��50      $	��120��6)   $��0 0 15 0q�65   6I   �� 51      -   5        $��btnGetByEmail��51      .��6M   
Wyszukaj6W   52      �� 53      .��6   	Sekcja:6   � 54      .+�55      �� -   5        $��
cbSections��55   -   $��0 0 15 0q�6   $
��Left=�6?   $	��Top=�56      $	��120��61    �� Text$ Wybierz sekcje��6=   6U   �� 57      -   5        $��btnGetBySekcja��57      .��6N   
Wyszukaj6X   58      �� 59      $����6   �� 5:      $����6   5;      5<      5=      5>      5?      