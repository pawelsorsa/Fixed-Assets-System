   M S B A M L   `   `   `  ����I  EFixedAssetsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FixedAssetsApp.ConvertersFixedAssetsApp.Converters  5      )    #FixedAssetsApp.Views.FixedAssetView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >
converters'clr-namespace:FixedAssetsApp.Converters     5        � 	Resources  5	      +   %FixedAssetsApp.Converters.FlopBoolean   BooleanConverter7   1FixedAssetsApp.Converters.PersonIDToNameConverter  PersonIdToName9   3FixedAssetsApp.Converters.SubgroupIdToNameConverter  SubgroupIdToName5   /FixedAssetsApp.Converters.KindIdToNameConverter  KindIdToName �� 
TargetType �� Property �� Value��%�   &	        &	      &	 &     &	 9     '�� L       5
   
   6!     5   
   6-     5   
   6/     5   
   6+   �� 5   
   " ��6   .�5      ��  � ��
 �  ��6+   5      5      .��5      �� .+�5   
   � .+�5      � .+�5      �� -   5        $��btn_GetAllFixedAssets��5      $	��200��6V   .��6b   %#Wyświetl wszystkie środki trwałe6�   �� 5      -   5        $��btnGetByCassation��5      .��6M   &$Wyświetl środki trwałe do kasacji6p   �� 5      -   5        $��btn_AddFixedAsset��5      $	��200��6N   .��6Z   Dodaj nowy środek trwały6t   5      9� 5      $��Wyszukiwanie zaawansowane��6   .��5      �� -   5        $��expanderSearchSection��5      $��10,4,0,0q�6:   .+�5      �� .��6   ID:6!   � 5      .+�5      �� -   5        $
��tbId��5   "   $	��120��6.   $��0 0 15 0q�6:   6N   �� 5      -   5        $��
btnGetById��5   !   .��6R   
Wyszukaj6\   5      �� 5       .��6   Numer inwentarzowy:61   � 5!      .+�5"      �� -   5        $��tbInventoryNumber��5"   "   $	��120��6;   $��0 0 15 0q�6G   6[   �� 5#      -   5        $��btnGetByInventoryNumber��5#   !   .��6_   
Wyszukaj6i   5$      �� 5%      .��6   Numer seryjny:6,   � 5&      .+�5'      �� -	   5        $��tbSerialNumber��5'   "   $	��120��68   $��0 0 15 0q�6D   6X   �� 5(      -
   5        $��btnGetBySerialNumber��5(   !   .��6\   
Wyszukaj6f   5)      �� 5*      .��6   Kontrahent:6)   � 5+      .+�5,      �� -   5        $��tbContractor��5,   "   $	��120��66   $��0 0 15 0q�6B   6V   �� 5-      -   5        $��btnGetByContractor��5-   !   .��6Z   
Wyszukaj6d   5.      �� 5/      .��6   	Rodzaj:6%   � 50      .+�51      �� -   5        $��tbKind��51   "   $	��120��60   $��0 0 15 0q�6<   6P   �� 52      -   5        $��btnGetByKind��52   !   .��6T   
Wyszukaj6^   53      �� 54      .��6   Lokalizacja:6*   � 55      .+�56      �� -   5        $��tbLocalization��56   "   $	��120��68   $��0 0 15 0q�6D   6X   �� 57      -   5        $��btnGetByLocalization��57   !   .��6\   
Wyszukaj6f   58      �� 59      .��6   Pozycja kosztów:6.   � 5:      .+�5;      �� -   5        $��tbMPK��5;   "   $	��120��6/   $��0 0 15 0q�6;   6O   �� 5<      -   5        $��btnGetByMPK��5<   !   .��6S   
Wyszukaj6]   5=      �� 5>      .��6   !Właściciel środka trwałego:69   � 5?      .+�5@      �� -   5        $��tbOwner��5@   "   $	��120��61   $��0 0 15 0q�6=   6Q   �� 5A      -   5        $��btnGetByOwner��5A   !   .��6U   
Wyszukaj6_   5B      �� 5C      .��6   	Podgrupa:6'   � 5D      .+�5E      �� -   5        $��
tbSubgroup��5E   "   $	��120��64   $��0 0 15 0q�6@   6T   �� 5F      -   5        $��btnGetBySubgroup��5F   !   .��6X   
Wyszukaj6b   5G      �� 5H      .��6   1/Data ostatniej modyikacji (format: rrrr-mm-dd):6M   � 5I      .+�5J      �� -   5        $��tbLastModifyDate��5J   "   $	��120��6:   $��0 0 15 0q�6F   6Z   �� 5K      -   5        $��tbLastModifyDate2��5K   "   $	��120��6;   $��0 0 15 0q�6G   6[   �� 5L      -   5        $��btnGetByLastModifyDate��5L   !   .��6^   
Wyszukaj6h   5M      �� 5N      .��6   &$Data aktywacji (format: rrrr-mm-dd):6B   � 5O      .+�5P      �� -   5        $��tbActivationDate��5P   "   $	��120��6:   $��0 0 15 0q�6F   6Z   �� 5Q      -   5        $��tbActivationDate2��5Q   "   $	��120��6;   $��0 0 15 0q�6G   6[   �� 5R      -   5        $��btnGetByActivationDate��5R   !   .��6^   
Wyszukaj6h   5S      �� 5T      $����6    �� 5U      $����6    5V      5W      5X      &   System.Windows.Controls.DataGrid  5Y   
   -   5        $��dataGridFixedAssets��5Y         AutoGenerateColumns .     AlternatingRowBackground
 �����$	��Top=�5Z       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .  	   Columns	 5\      0  *System.Windows.Controls.DataGridTextColumn  5]      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6%      
IsReadOnly .    Header$ ID��6D   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6P   �� *id+ �� Mode$ TwoWay=�6v     5^      $

 Auto 6%    . $ Numer inwentarzowy��6D    6`   �� *inventory_number+$ TwoWay=�6�     5_      $

 Auto 6%    . $ Przypisana osoba��6D    6^   �� *	id_person+$ TwoWay=� �� 	Converter# [ 6�     5`      $

 Auto 6%    . $ Data aktywacji��6D    6\   �� *date_of_activation+ �� StringFormat$ {0:dd-MM-yyyy}��$ TwoWay=�6�     5a      $

 Auto 6%    . $ Data dezaktywacji��6D    6_   �� *date_of_desactivation+$ {0:dd-MM-yyyy}��$ TwoWay=�6�     5b      $

 Auto 6%    . $ Numer seryjny��6D    6[   �� *serial_number+$ TwoWay=�6�     5c      $

 Auto 6%    . $ Pozycja kosztów��6D    6]   �� *MPK+$ TwoWay=�6�     5d      $

 Auto 6%    . $ Ilość��6D    6S   �� *
quantity+$ TwoWay=�6�     5e      $

 Auto 6%    . $ Lokalizacja��6D    6Y   �� *localization+$ TwoWay=�6�     5f      $

 Auto 6%    . $ Rodzaj��6D    6T   �� *	id_kind+$ TwoWay=�# [ 6�     5g      $

 Auto 6%    . $ Podgrupa��6D    6V   �� *id_subgroup+$ TwoWay=�# [ 6�     5h      $

 Auto 6%    . $ Data ost. modyfikcji��6D    6b   �� *last_modified_date+$ {0:dd-MM-yyyy}��$ TwoWay=�6�     5i      $

 Auto 6%    . $! Ostatnio modyfikowany przez��6D    6i   �� *last_modifed_login+$ TwoWay=�6�     5j      $

 Auto 6%    . $ 
Do kasacji��6D    6X   �� *	cassation+$ TwoWay=�# [  6�     5k      $

 Auto 6%    . $ Stworzony prze��6D    6\   �� *
created_by+$ TwoWay=�6�     5l      $
 50 6%    . $ 	Komentarz��6B    6U   �� *	comment+$ TwoWay=�6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5m      $

 Auto 6)   $ Usuń��66    
  CellTemplate 5n      �� 5o      .R�5p      �� $��	btnDelete��5q   4   $��Delete��5p   %   $��Usuń��5q   %   6G   5r      5t      
  5u      $

 Auto 6)   $ Edytuj��66    5v      �� 5w      .R�5x      �� $��	btnUpdate��66   -   5        $��Edytuj��5x   %   6a   5y      5{      5}      5~      5      