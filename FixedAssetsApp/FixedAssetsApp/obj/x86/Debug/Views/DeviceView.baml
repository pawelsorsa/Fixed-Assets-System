   M S B A M L   `   `   `  ����  FixedAssetsApp%    FixedAssetsApp.Views.DeviceView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �� .+�5   
   � .+�5	      � .+�5
      �� -   5        $��btn_GetAllDevices��5
      $	��200��6N   .��6Z   !Wyświetl wszystkie urządzenia6y   �� 5      -   5        $��btn_AddDevice��5      $	��200��6F   .��6R   Dodaj nowe urządzenie6i   5      9� 5      $��Wyszukiwanie zaawansowane��6   .��5      �� -   5        $��expanderSearchSection��5      $��10,4,0,0q�6:   .+�5      �� .��6   ID:6!   � 5      .+�5      �� -   5        $
��tbId��5   "   $	��120��6.   $��0 0 15 0q�6:   6N   �� 5      -   5        $��
btnGetById��5   !   .��6R   
Wyszukaj6\   5      �� 5      .��6   	Rodzaj:6%   � 5      .+�5      � .+�5      �� -   5        $��ComboBox_Devies��5   6   $��	0 0 15 10q�6#   $	��120��6M     �� Text$   Wybierz rodzaj urządzenia��5      6=   5      � 5      .+�5      �� -   5        $��btnGetByPeripheralDevice��5   !   .��6`   
Wyszukaj6j   5      5      �� 5      .��6   Numer seryjny:6,   � 5      .+�5       �� -   5        $��tbSerialNumber��5    "   $	��120��68   $��0 0 15 0q�6D   6X   �� 5!      -	   5        $��btnGetBySerialNumber��5!   !   .��6\   
Wyszukaj6f   5"      �� 5#      .��6   	Adres IP:6'   � 5$      .+�5%      �� -
   5        $
��tbIP��5%   "   $	��120��6.   $��0 0 15 0q�6:   6N   �� 5&      -   5        $��
btnGetByIP��5&   !   .��6R   
Wyszukaj6\   5'      �� 5(      .��6   
Adres MAC:6(   � 5)      .+�5*      �� -   5        $��tbMAC��5*   "   $	��120��6/   $��0 0 15 0q�6;   6O   �� 5+      -   5        $��btnGetByMac��5+   !   .��6S   
Wyszukaj6]   5,      �� 5-      .��6   
Producent:6(   � 5.      .+�5/      �� -   5        $��
tbProducer��5/   "   $	��120��64   $��0 0 15 0q�6@   6T   �� 50      -   5        $��btnGetByProducer��50   !   .��6X   
Wyszukaj6b   51      �� 52      .��6   Model:6$   � 53      .+�54      �� -   5        $��tbModel��54   "   $	��120��61   $��0 0 15 0q�6=   6Q   �� 55      -   5        $��btnGetByModel��55   !   .��6U   
Wyszukaj6_   56      �� 57      .��6   ID Środka trwałego:61   � 58      .+�59      �� -   5        $��tbIDFixedAsset��59   "   $	��120��68   $��0 0 15 0q�6D   6X   �� 5:      -   5        $��btnGetByIDFixedAsset��5:   !   .��6\   
Wyszukaj6f   5;      �� 5<      $����6    �� 5=      $����6    5>      5?      5@      &   System.Windows.Controls.DataGrid  5B   
   -   5        $��dataGridDevices��5B         AutoGenerateColumns .     AlternatingRowBackground
 �����$	��Top=�5C       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .     Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      
IsReadOnly . 	   Header$	 ID��6D   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6P   �� *id+ �� Mode$ TwoWay=�6v     5G      $ * 6%    . $	 Nazwa��6A   
 6P   �� *name_peripheral_device+$ TwoWay=�6�     5H      $
 Auto 6%    . $	 Numer Seryjny��6D   
 6[   �� *serial_number+$ TwoWay=�6�     5I      $
 Auto 6%    . $	 IP��6D   
 6P   �� *
ip_address+$ TwoWay=�6     5J      $
 Auto 6%    . $		 MAC��6D   
 6Q   �� *mac_address+$ TwoWay=�6�     5K      $
 Auto 6%    . $	 	Producent��6D   
 6W   �� *
producer+$ TwoWay=�6�     5L      $
 Auto 6%    . $	 Model��6D   
 6S   �� *model+$ TwoWay=�6}     5M      $
 Auto 6%    . $	 ID środka trwałego��6D   
 6`   �� *id_fixed_asset+$ TwoWay=�6�     5N      $
 Auto 6%    . $	 	Komentarz��6D   
 6W   �� *	comment+$ TwoWay=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5O      $
 Auto 6*   $	 Usuń��67      CellTemplate 5P      �� 5Q      .R�5R      �� $��	btnDelete��5S   4   $��Delete��5R   %   $��Usuń��5S   %   6G   5T      5V        5W      $
 Auto 6)   $	 Edytuj��66    5X      �� 5Y      .R�5Z      �� $��	btnUpdate��66   -   5        $��Edytuj��5Z   %   6a   5[      5]      5_      5`      5a      